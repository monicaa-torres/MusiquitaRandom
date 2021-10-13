using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusiquitaRandom.Data;
using MusiquitaRandom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusiquitaRandom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomController : ControllerBase
    {
        private readonly AppDbContext _context;


        public RandomController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<Musiquita>> GetMusiquita()
        {
            var list = await _context.Musiquita.ToListAsync();

            var max = list.Count;
            int index = new Random().Next(0, max);
            var musiquita = list[index];

            if (musiquita == null)
            {
                return NoContent();
            }

            return musiquita;
        }
    }
}
