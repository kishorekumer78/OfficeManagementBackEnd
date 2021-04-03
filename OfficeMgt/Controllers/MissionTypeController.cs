using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeMgt.Data;
using OfficeMgt.Models.Flg;

namespace OfficeMgt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionTypeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MissionTypeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/MissionType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MissionType>>> GetMissionTypes()
        {
            return await _context.MissionTypes.ToListAsync();
        }

        // GET: api/MissionType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MissionType>> GetMissionType(int id)
        {
            var missionType = await _context.MissionTypes.FindAsync(id);

            if (missionType == null)
            {
                return NotFound();
            }

            return missionType;
        }

        // PUT: api/MissionType/5       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMissionType(int id, MissionType missionType)
        {
            if (id != missionType.MissionTypeId)
            {
                return BadRequest();
            }

            _context.Entry(missionType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MissionTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MissionType        
        [HttpPost]
        public async Task<ActionResult<MissionType>> PostMissionType(MissionType missionType)
        {
            _context.MissionTypes.Add(missionType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMissionType", new { id = missionType.MissionTypeId }, missionType);
        }

        // DELETE: api/MissionType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMissionType(int id)
        {
            var missionType = await _context.MissionTypes.FindAsync(id);
            if (missionType == null)
            {
                return NotFound();
            }

            _context.MissionTypes.Remove(missionType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MissionTypeExists(int id)
        {
            return _context.MissionTypes.Any(e => e.MissionTypeId == id);
        }
    }
}
