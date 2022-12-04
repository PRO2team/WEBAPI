using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webapi.Contexts;
using Webapi.Models;

namespace Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalonsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SalonsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Salon>>> GetSalons()
        {
            return await _context.Salons.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Salon>> GetSalon(int id)
        {
            var salon = await _context.Salons.FindAsync(id);

            if (salon == null)
            {
                return NotFound();
            }

            return salon;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalon(int id, Salon salon)
        {
            if (id != salon.SalonID)
            {
                return BadRequest();
            }

            _context.Entry(salon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalonExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Salon>> PostSalon(Salon salon)
        {
            _context.Salons.Add(salon);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetSalon", new { id = salon.SalonID }, salon);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalon(int id)
        {
            var salon = await _context.Salons.FindAsync(id);
            if (salon == null)
            {
                return NotFound();
            }

            _context.Salons.Remove(salon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalonExists(int id)
        {
            return _context.Salons.Any(e => e.SalonID == id);
        }
    }
}
