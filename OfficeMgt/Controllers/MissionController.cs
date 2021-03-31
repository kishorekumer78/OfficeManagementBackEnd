using System;
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
    public class MissionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MissionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Mission
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mission>>> GetMissions()
        {
            return await _context.Missions.Include(x=>x.Type).Include(x=>x.Phase).ToListAsync();
        }

        // GET: api/Mission/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mission>> GetMission(int id)
        {
            var mission = await _context.Missions.FindAsync(id);

            if (mission == null)
            {
                return NotFound();
            }

            return mission;
        }

        // PUT: api/Mission/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMission(int id, Mission mission)
        {
            if (id != mission.Id)
            {
                return BadRequest();
            }

            _context.Entry(mission).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MissionExists(id))
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

        // POST: api/Mission
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MissionProto>> PostMission(MissionProto mission)
        {
            
            var msn = new Mission()
            {
                Id = mission.Id,
                Name = mission.MissionName,
                Aircraft =mission.MissionAircraft,
                Syllabus = mission.Syllabus,
                
            };

            // MissionProto class contains the the duration as string format. convertingthe string into timespan ans saving it in the database as seconds
            TimeSpan duration = TimeSpan.Parse(mission.MissionDuration);
            msn.Duration = (long)duration.TotalSeconds;
            
            _context.Missions.Add(msn);
            await _context.SaveChangesAsync();
            //object to send to front end
            var addedMission = ConvertToProto(msn.Id);

            return CreatedAtAction("GetMission", new { id = msn.Id }, addedMission);
        }

        // DELETE: api/Mission/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMission(int id)
        {
            var mission = await _context.Missions.FindAsync(id);
            if (mission == null)
            {
                return NotFound();
            }

            _context.Missions.Remove(mission);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MissionExists(int id)
        {
            return _context.Missions.Any(e => e.Id == id);
        }

        private async Task<MissionProto> ConvertToProto(int Id)
        {
            var addedMission = await _context.Missions.FindAsync(Id);
            var msn = new MissionProto
            {
                Id = addedMission.Id,
                MissionName = addedMission.Name,
                MissionDuration = TimeSpan.FromSeconds(addedMission.Duration).ToString(),
                MissionAircraft = addedMission.Aircraft,
                Syllabus = addedMission.Syllabus
            };
            return msn;
        }
    }
}
