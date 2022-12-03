using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webapi.Contexts;
using Webapi.Models;

namespace Webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _dbContext = applicationDbContext;
        }

        [HttpGet]
        public ActionResult<Review> GetReview()
        {
            return Ok(_dbContext.Appointments.FirstOrDefault());
        }

        [HttpPost]
        public ActionResult AddReview()
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