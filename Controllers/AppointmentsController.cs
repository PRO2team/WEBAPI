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
        public ActionResult<IEnumerable<Review>> Get()
        {
            return Ok(_dbContext.Appointments);
        }

        [HttpGet("/{appointmentId}")]
        public ActionResult<Review> Get(int appointmentId)
        {
            _dbContext.Appointments.Load();
            return Ok(_dbContext.Appointments.FirstOrDefault(e => e.AppointmentID == appointmentId));
        }
        
        [HttpDelete("/{appointmentId}")]
        public ActionResult<Review> Delete(int appointmentId)
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
        public ActionResult<Review> Add()
        {
            var review = new Review()
            {
                Rating = 5,
                Comment = "Very cool",
                PostedTimestamp = DateTime.Now,
                Appointment = new Appointment() { CalendarAppointmentURL = "google.com", Date = DateTime.Now, IsConfirmed = true, AppointmentType = new AppointmentType() { LengthMinutes = 33, Name = "Haircut", Price = 55 }, User = new User() { Name = "Hlib", Surname = "Pivniev2", Birthdate = DateTime.Today.AddYears(-20), Selfie = new Picture() { Filepath = "E:/Pictures/defaultAvatar.png" }, UserCredentials = new UserCredentials() { Email = "gl.pvn2@gmail.com", PasswordHashed = "test123" } } }
            };
            _dbContext.Reviews.Add(review);
            _dbContext.SaveChanges();
            return Ok(_dbContext.Reviews.FirstOrDefault());
        }
    }
}