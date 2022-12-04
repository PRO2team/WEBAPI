using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webapi.Contexts;
using Webapi.Models;

namespace Webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly ILogger<AppointmentsController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public AppointmentsController(ILogger<AppointmentsController> logger, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _dbContext = applicationDbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Review>> GetAppointments()
        {
            return Ok(_dbContext.Appointments);
        }

        [HttpGet("/{appointmentId}")]
        public ActionResult<Review> GetAppointment(int appointmentId)
        {
            _dbContext.Appointments.Load();
            return Ok(_dbContext.Appointments.FirstOrDefault(e => e.AppointmentID == appointmentId));
        }
        
        [HttpDelete("/{appointmentId}")]
        public ActionResult<Review> DeleteAppointment(int appointmentId)
        {
            var appointmentToDelete = _dbContext.Appointments.FirstOrDefault(e => e.AppointmentID == appointmentId);
            if(appointmentToDelete != null)
            {
                _dbContext.Appointments.Remove(appointmentToDelete);
                _dbContext.SaveChanges();
                return Ok(appointmentToDelete);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<Appointment>> PostAppointment(Appointment appointment)
        {
            _dbContext.Appointments.Add(appointment);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetAppointment", new { id = appointment.AppointmentID }, appointment);
        }
    }
}