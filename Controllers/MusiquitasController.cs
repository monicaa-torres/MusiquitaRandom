using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusiquitaRandom.Data;
using MusiquitaRandom.Models;

namespace MusiquitaRandom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusiquitasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MusiquitasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Musiquitas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Musiquita>>> GetMusiquita()
        {
            return await _context.Musiquita.ToListAsync();
        }

        // GET: api/Musiquitas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Musiquita>> GetMusiquita(string id)
        {
            var musiquita = await _context.Musiquita.FindAsync(id);

            if (musiquita == null)
            {
                return NotFound();
            }

            return musiquita;
        }

        // PUT: api/Musiquitas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMusiquita(string id, Musiquita musiquita)
        {
            if (id != musiquita.SongName)
            {
                return BadRequest();
            }

            _context.Entry(musiquita).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusiquitaExists(id))
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

        // POST: api/Musiquitas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Musiquita>> PostMusiquita(Musiquita musiquita)
        {
            _context.Musiquita.Add(musiquita);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MusiquitaExists(musiquita.SongName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMusiquita", new { id = musiquita.SongName }, musiquita);
        }

        // DELETE: api/Musiquitas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusiquita(string id)
        {
            var musiquita = await _context.Musiquita.FindAsync(id);
            if (musiquita == null)
            {
                return NotFound();
            }

            _context.Musiquita.Remove(musiquita);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MusiquitaExists(string id)
        {
            return _context.Musiquita.Any(e => e.SongName == id);
        }
    }
}
