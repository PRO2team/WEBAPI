using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webapi.Contexts;
using Webapi.Helpers;
using Webapi.Models;
using Webapi.Models.Requests;

namespace Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalonsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public SalonsController(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Salon>>> GetSalons()
        {
            return await _dbContext.Salons.IncludeAll().ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Salon>> GetSalon(int id)
        {
            var salon = await _dbContext.Salons.IncludeAll().FirstOrDefaultAsync(e => e.SalonID == id);

            if (salon == null)
            {
                return NotFound();
            }

            return salon;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalon(int id, AddSalonRequest addSalonRequest)
        {
            var salon = await _dbContext.Salons.IncludeAll().FirstOrDefaultAsync(e => e.SalonID == id);

            if (salon is null) return NotFound();
            if (addSalonRequest.Address is null || addSalonRequest.OpenHours is null || addSalonRequest.OpenHours.Any(e => e.DayName.IsDayOfWeek() == false)) return BadRequest();

            salon.Name = addSalonRequest.Name;
            salon.Description = addSalonRequest.Description;
            salon.OwnerPhoneNumber = addSalonRequest.OwnerPhoneNumber;
            salon.WebsiteURL = addSalonRequest.WebsiteURL;
            salon.Address = addSalonRequest.Address;
            salon.OpenHours = addSalonRequest.OpenHours;

            _dbContext.Entry(salon).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
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
        public async Task<ActionResult<Salon>> PostSalon(AddSalonRequest addSalonRequest)
        {
            if (addSalonRequest.Address is null || addSalonRequest.OpenHours is null || addSalonRequest.OpenHours.Any(e => e.DayName.IsDayOfWeek() == false)) return BadRequest();

            var salon = new Salon()
            {
                Name = addSalonRequest.Name,
                Description = addSalonRequest.Description,
                OwnerPhoneNumber = addSalonRequest.OwnerPhoneNumber,
                WebsiteURL = addSalonRequest.WebsiteURL,
                Address = addSalonRequest.Address,
                OpenHours = addSalonRequest.OpenHours,
                AppointmentTypes = new List<AppointmentType>(),
                Amentities = new List<Amentity>(),
            };

            _dbContext.Salons.Add(salon);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction("GetSalon", new { id = salon.SalonID }, salon);
        }

        [HttpPost("picture/{salonId}")]
        public async Task<ActionResult<Salon>> AssignSalonPicture(int salonId, Picture picture)
        {
            var salon = await _dbContext.Salons.IncludeAll().FirstOrDefaultAsync(e => e.SalonID == salonId);

            if (salon == null)
            {
                return NotFound();
            }

            var currentSalonPicture = salon.SalonPicture;
            salon.SalonPicture = picture;

            if(currentSalonPicture != null)
                _dbContext.Pictures.Remove(currentSalonPicture);

            _dbContext.Entry(salon).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalonExists(salonId))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalon(int id)
        {
            var salon = await _dbContext.Salons.FindAsync(id);
            if (salon == null)
            {
                return NotFound();
            }

            _dbContext.Salons.Remove(salon);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool SalonExists(int id)
        {
            return _dbContext.Salons.Any(e => e.SalonID == id);
        }
    }
}
