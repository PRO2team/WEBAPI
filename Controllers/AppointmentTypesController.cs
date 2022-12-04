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
    public class AppointmentTypesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AppointmentTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentType>>> GetAppointmentTypes()
        {
            return await _context.AppointmentTypes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentType>> GetAppointmentType(int id)
        {
            var appointmentType = await _context.AppointmentTypes.FindAsync(id);

            if (appointmentType == null)
            {
                return NotFound();
            }

            return appointmentType;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointmentType(int id, AppointmentType appointmentType)
        {
            if (id != appointmentType.AppointmentTypeID)
            {
                return BadRequest();
            }

            _context.Entry(appointmentType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentTypeExists(id))
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
        public async Task<ActionResult<AppointmentType>> PostAppointmentType(AppointmentType appointmentType)
        {
            _context.AppointmentTypes.Add(appointmentType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppointmentType", new { id = appointmentType.AppointmentTypeID }, appointmentType);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointmentType(int id)
        {
            var appointmentType = await _context.AppointmentTypes.FindAsync(id);
            if (appointmentType == null)
            {
                return NotFound();
            }

            _context.AppointmentTypes.Remove(appointmentType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppointmentTypeExists(int id)
        {
            return _context.AppointmentTypes.Any(e => e.AppointmentTypeID == id);
        }
    }
}
