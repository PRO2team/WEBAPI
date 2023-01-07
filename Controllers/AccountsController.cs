using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Webapi.Contexts;
using Webapi.Exceptions;
using Webapi.Helpers;
using Webapi.Models;
using Webapi.Models.DTO;
using Webapi.Models.Requests;
using static Webapi.Models.UserCredentials;

namespace Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private const int ACCESS_TOKEN_LIFETIME = 20; //minutes
        private const int REFRESH_TOKEN_LIFETIME = 1; //days
        private const int SALT_LENGTH = 32; //bytes
        
        private static readonly byte[] DefaultImageBytes = Convert.FromBase64String(@"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");

        private readonly ApplicationDbContext _dbContext;
        private readonly IConfiguration _config;

        public AccountsController(ApplicationDbContext context, IConfiguration config)
        {
            _dbContext = context;
            _config = config;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _dbContext.Users.IncludeAll().ToListAsync();
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserDto>> GetUser(int userId)
        {
            var user = await _dbContext.Users.IncludeAll().FirstOrDefaultAsync(e => e.UserID == userId);
            if (user == null)
            {
                return NotFound();
            }

            var ownedSalons = _dbContext.Salons.Where(e => e.Owner.UserID == user.UserID).Select(e => new SalonDto(e)).ToList();
            var appointments = _dbContext.Appointments.Include(e => e.User).Include(e => e.AppointmentType).Where(e => e.User.UserID == userId).ToList();
            var totalSpent = appointments.Sum(e => e.AppointmentType.Price);

            var userDto = new UserDto(user);
            userDto.OwnedSalons = ownedSalons;
            userDto.Appointments = appointments;
            userDto.TotalSpent = totalSpent;

            return userDto;
        }

        [HttpGet("{userId}/appointments/")]
        public async Task<ActionResult<List<Appointment>>> GetUserAppointments(int userId)
        {
            var user = await _dbContext.Users.IncludeAll().FirstOrDefaultAsync(e => e.UserID == userId);
            if (user == null)
            {
                return NotFound();
            }

            var appointments = await _dbContext.Appointments.Where(e => e.User.UserID == userId).Include(e => e.AppointmentType).ToListAsync();

            return appointments;
        }
        [HttpGet("{userId}/favourites")]
        public async Task<ActionResult> GetUserFavouriteSalons(int userId)
        {
            var user = await _dbContext.Users.Include(e => e.FavouriteSalons).FirstOrDefaultAsync(e => e.UserID == userId);
            if (user == null)
            {
                return NotFound();
            }

            var salons = _dbContext.Salons.Where(e => user.FavouriteSalons.Select(e => e.SalonID).Contains(e.SalonID)).Select(e => new {
                e.SalonID,
                e.Name,
                e.Description,
                e.OwnerPhoneNumber,
                e.Amentities,
                e.AppointmentTypes,
                e.OpenHours,
                e.Owner,
                e.Reviews,
                e.WebsiteURL,
                e.SalonType,
                e.Address,
                e.SalonPicture
            });

            return Ok(salons);
        }

        [HttpPost("favourites/{userId}/{salonId}")]
        public async Task<ActionResult<User>> FavouritesAddSalon(int userId, int salonId)
        {
            var user = await _dbContext.Users.IncludeAll().FirstOrDefaultAsync(e => e.UserID == userId);
            if (user == null)
            {
                return NotFound($"User id {userId} could not be found");
            }

            var salon = await _dbContext.Salons.FirstOrDefaultAsync(e => e.SalonID == salonId);
            if (salon == null)
            {
                return NotFound($"Salon id {salonId} could not be found");
            }

            if(user.FavouriteSalons.Select(e => e.SalonID).Contains(salonId))
            {
                return StatusCode(409, "Such salon has already been added to favourites");
            }

            var favouriteSalon = new UserFavouriteSalon()
            {
                SalonID = salonId
            };

            user.FavouriteSalons.Add(favouriteSalon);

            _dbContext.Entry(user).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();

            return Ok();
        }
        
        [HttpDelete("favourites/{userId}/{salonId}")]
        public async Task<ActionResult<User>> FavouritesDeleteSalon(int userId, int salonId)
        {
            var user = await _dbContext.Users.IncludeAll().FirstOrDefaultAsync(e => e.UserID == userId);
            if (user == null)
            {
                return NotFound($"User id {userId} could not be found");
            }

            var salon = await _dbContext.Salons.FirstOrDefaultAsync(e => e.SalonID == salonId);
            if (salon == null)
            {
                return NotFound($"Salon id {salonId} could not be found");
            }

            if(!user.FavouriteSalons.Select(e => e.SalonID).Contains(salonId))
            {
                return NotFound("User does not have such a salon on the favorites list");
            }

            var favouriteSalon = user.FavouriteSalons.FirstOrDefault(e => e.SalonID == salonId);
            user.FavouriteSalons.Remove(favouriteSalon);

            _dbContext.Entry(user).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginRequest loginRequest)
        {
            User user = _dbContext.Users.Include(e => e.UserCredentials).Where(user => user.UserCredentials.Login == loginRequest.Login).FirstOrDefault();

            if (user == default) return StatusCode(401, "No such user was found");
            if (!user.UserCredentials.PasswordHashed.SequenceEqual(loginRequest.Password.Encrypt(user.UserCredentials.Salt))) return StatusCode(401, "Wrong password");

            var creds = _config["SecretKey"].ToSigningCredentials();
            var accessToken = GetNewJwtToken(creds, user);

            var refreshToken = user.RenewRefreshToken(REFRESH_TOKEN_LIFETIME);
            _dbContext.Update(user);
            await _dbContext.SaveChangesAsync();

            return Ok(new
            {
                accessToken = new JwtSecurityTokenHandler().WriteToken(accessToken),
                user.UserID,
                user.UserCredentials.Login,
                user.UserCredentials.UserRole,
                RefreshToken = user.UserCredentials.RefreshTokenExpirationDate > DateTime.Now ? user.UserCredentials.RefreshToken : null,
                user.Name,
                user.Surname,
                user.PhoneNumber,
                user.TotalSpent,
                user.Birthdate,
                user.ProfilePicture
            });
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterRequest registerRequest)
        {
            User user = _dbContext.Users.Include(e => e.UserCredentials).Where(user => user.UserCredentials.Login == registerRequest.Login).FirstOrDefault();
            if (user != default) return StatusCode(409, "Such user already exists");
            try
            {
                user = CreateUser(registerRequest);

                await _dbContext.AddAsync(user);
                await _dbContext.SaveChangesAsync();
            }
            catch (UndefinedUserRoleException)
            {
                return StatusCode(422, "Undefined user role occured");
            }catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

            return Ok(user);
        }

        [HttpPut("{userId}")]
        public async Task<ActionResult> UpdateUser(int userId, UpdateUserRequest updateRequest)
        {
            var user = _dbContext.Users.FirstOrDefault(user => user.UserID == userId);
            if (user == default) return NotFound();
            try
            {
                user.Name = updateRequest.Name;
                user.Surname = updateRequest.Surname;
                user.PhoneNumber = updateRequest.PhoneNumber;
                user.Birthdate = updateRequest.Birthdate;
                user.ProfilePicture = updateRequest.ProfilePicture;

                _dbContext.Entry(user).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

            return Ok(user);
        }

        [HttpPost("refresh")]
        public ActionResult RefreshAccessToken([FromHeader] string login, [FromHeader] byte[] refreshToken)
        {
            User user = _dbContext.Users.Include(e => e.UserCredentials).Where(user => user.UserCredentials.Login == login).FirstOrDefault();
            if (user == default) return StatusCode(401, "No such user was found");
            if (!user.UserCredentials.RefreshToken.SequenceEqual(refreshToken)) return StatusCode(401, "Wrong refresh token");
            if (user.UserCredentials.RefreshTokenExpirationDate.CompareTo(DateTime.Now) < 0) return StatusCode(401, "Refresh token has expired");

            var creds = _config["SecretKey"].ToSigningCredentials();
            var accessToken = GetNewJwtToken(creds, user);

            return Ok(new JwtSecurityTokenHandler().WriteToken(accessToken));
        }

        #region Utility
        private static User CreateUser(RegisterRequest registerRequest)
        {
            string userRole;
            if (Enum.IsDefined(typeof(UserCredentials.UserRoles), registerRequest.UserRole)) userRole = registerRequest.UserRole;
            else throw new UndefinedUserRoleException();

            var salt = GetSalt();
            var newUserCredentials = new UserCredentials()
            {
                Login = registerRequest.Login,
                PasswordHashed = registerRequest.Password.Encrypt(salt),
                UserRole = userRole,
                Salt = salt,
                RefreshToken = Guid.NewGuid().ToByteArray(),
                RefreshTokenExpirationDate = DateTime.Now.AddDays(REFRESH_TOKEN_LIFETIME)
            };
            var newUser = new User()
            {
                UserCredentials = newUserCredentials,
                Name = registerRequest.Name,
                Surname = registerRequest.Surname,
                Birthdate = registerRequest.Birthdate,
                PhoneNumber = registerRequest.PhoneNumber,
                ProfilePicture = new Picture()
                {
                    Bytes = DefaultImageBytes
                }
            };

            return newUser;
        }

        private static byte[] GetSalt()
        {
            var salt = new byte[SALT_LENGTH];
            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetNonZeroBytes(salt);
            }

            return salt;
        }

        private static JwtSecurityToken GetNewJwtToken(SigningCredentials creds, User user)
        {
            var userClaims = new[]
            {
                new Claim(ClaimTypes.Name, user.UserCredentials.Login),
                new Claim(ClaimTypes.Role, user.UserCredentials.UserRole)
            };

            return new
            (
                claims: userClaims,
                issuer: "http://localhost:7229",
                audience: "http://localhost:7229",
                expires: DateTime.Now.AddMinutes(ACCESS_TOKEN_LIFETIME),
                signingCredentials: creds
            );
        }
        #endregion
    }
}
