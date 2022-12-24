using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webapi.Contexts;
using Webapi.Models.Requests;
using Webapi.Models;
using static Webapi.Models.UserCredentials;
using Webapi.Helpers;
using System.Security.Cryptography;
using System.Text;

namespace Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public TestController(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        [HttpPost]
        public async Task<ActionResult> FulfillDatabaseWithTestData()
        {
            var user1 = CreateUser();
            var salon1 = new Salon()
            {
                Name = "Don Capelli",
                Description = "Najlepszy barber w Wawie",
                OwnerPhoneNumber = "+48793123456",
                WebsiteURL = "doncapelli.com",
                Amentities = new List<Amentity>()
                {
                    new Amentity()
                    {
                        Name = "Free parking",
                        Icon = new Picture()
                        {
                            Bytes = Encoding.UTF8.GetBytes("test")
                        }
                    }
                },
                Address = new Address()
                {
                    City = "Warszawa",
                    Street = "Szańcowa",
                    HouseNumber = "15",
                    FlatNumber = "",
                    PostalCode = "01-234",
                },
                AppointmentTypes = new List<AppointmentType>()
                {
                    new AppointmentType()
                    {
                        Name = "Haircut",
                        LengthMinutes = 45,
                        Price = 80,
                        Promotion = new Promotion()
                        {
                            DiscountInPercent = 20,
                            DateFrom = DateTime.Today,
                            DateTo = DateTime.Today.AddDays(7)
                        }
                    },
                    new AppointmentType()
                    {
                        Name = "Beard trim",
                        LengthMinutes = 30,
                        Price = 50
                    },
                    new AppointmentType()
                    {
                        Name = "Hair + beard",
                        LengthMinutes = 75,
                        Price = 110
                    }
                },
                OpenHours = new List<DayHours>()
                {
                    new DayHours()
                    {
                        DayName = "Monday",
                        OpenTime = DateTime.ParseExact("19000101T07:00", "yyyyMMddTHH:mm", null),
                        CloseTime = DateTime.ParseExact("19000101T21:00", "yyyyMMddTHH:mm", null)
                    },
                    new DayHours()
                    {
                        DayName = "Tuesday",
                        OpenTime = DateTime.ParseExact("19000101T07:00", "yyyyMMddTHH:mm", null),
                        CloseTime = DateTime.ParseExact("19000101T21:00", "yyyyMMddTHH:mm", null)
                    },
                    new DayHours()
                    {
                        DayName = "Wednesday",
                        OpenTime = DateTime.ParseExact("19000101T07:00", "yyyyMMddTHH:mm", null),
                        CloseTime = DateTime.ParseExact("19000101T21:00", "yyyyMMddTHH:mm", null)
                    },
                    new DayHours()
                    {
                        DayName = "Thursday",
                        OpenTime = DateTime.ParseExact("19000101T07:00", "yyyyMMddTHH:mm", null),
                        CloseTime = DateTime.ParseExact("19000101T21:00", "yyyyMMddTHH:mm", null)
                    },
                    new DayHours()
                    {
                        DayName = "Friday",
                        OpenTime = DateTime.ParseExact("19000101T07:00", "yyyyMMddTHH:mm", null),
                        CloseTime = DateTime.ParseExact("19000101T21:00", "yyyyMMddTHH:mm", null)
                    },
                    new DayHours()
                    {
                        DayName = "Saturday",
                        OpenTime = DateTime.ParseExact("19000101T07:00", "yyyyMMddTHH:mm", null),
                        CloseTime = DateTime.ParseExact("19000101T19:00", "yyyyMMddTHH:mm", null)
                    }
                },
                Reviews = new List<Review>()
                {
                    new Review()
                    {
                        PostedTimestamp = DateTime.Today,
                        Comment = "Decent",
                        Rating = 4,
                        User = user1
                    }
                }
            };

            var appointment = new Appointment()
            {
                Date = DateTime.Today,
                IsConfirmed = true,
                CalendarAppointmentURL = "todo",
                AppointmentType = salon1.AppointmentTypes.First(),
                User = user1
            };

            _dbContext.Salons.Add(salon1);
            _dbContext.Appointments.Add(appointment);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAll()
        {
            _dbContext.DayHours.RemoveRange(_dbContext.DayHours);
            _dbContext.Amentities.RemoveRange(_dbContext.Amentities);
            _dbContext.Pictures.RemoveRange(_dbContext.Pictures);
            _dbContext.Promotions.RemoveRange(_dbContext.Promotions);
            _dbContext.Addresses.RemoveRange(_dbContext.Addresses);
            _dbContext.UserCredentials.RemoveRange(_dbContext.UserCredentials);
            _dbContext.Users.RemoveRange(_dbContext.Users);
            _dbContext.Reviews.RemoveRange(_dbContext.Reviews);
            _dbContext.Appointments.RemoveRange(_dbContext.Appointments);
            _dbContext.AppointmentTypes.RemoveRange(_dbContext.AppointmentTypes);
            _dbContext.Salons.RemoveRange(_dbContext.Salons);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        private User CreateUser()
        {
            var salt = new byte[32];
            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetNonZeroBytes(salt);
            }

            var newUserCredentials = new UserCredentials()
            {
                Login = "andrew@gmail.com",
                PasswordHashed = "admin".Encrypt(salt),
                UserRole = "Admin",
                Salt = salt,
                RefreshToken = Guid.NewGuid().ToByteArray(),
                RefreshTokenExpirationDate = DateTime.Now.AddDays(1)
            };

            return new User()
            {
                UserCredentials = newUserCredentials,
                Name = "Andrew",
                PhoneNumber = "+48793123654"
            };
        }
    }
}
