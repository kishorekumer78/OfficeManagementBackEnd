using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeMgt.Data;
using OfficeMgt.Models.Flg;

namespace OfficeMgt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhaseController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PhaseController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Phase
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Phase>>> GetPhases()
        {
            return await _context.Phases.ToListAsync();
        }

        // GET: api/Phase/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Phase>> GetPhase(int id)
        {
            var phase = await _context.Phases.FindAsync(id);

            if (phase == null)
            {
                return NotFound();
            }

            return phase;
        }

        // PUT: api/Phase/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhase(int id, Phase phase)
        {
            if (id != phase.PhaseId)
            {
                return BadRequest();
            }

            _context.Entry(phase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhaseExists(id))
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

        // POST: api/Phase
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Phase>> PostPhase(Phase phase)
        {
            _context.Phases.Add(phase);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhase", new { id = phase.PhaseId }, phase);
        }

        // DELETE: api/Phase/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhase(int id)
        {
            var phase = await _context.Phases.FindAsync(id);
            if (phase == null)
            {
                return NotFound();
            }

            _context.Phases.Remove(phase);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PhaseExists(int id)
        {
            return _context.Phases.Any(e => e.PhaseId == id);
        }
    }
}
