using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Webapi.Contexts;
using Webapi.Exceptions;
using Webapi.Helpers;
using Webapi.Models;
using Webapi.Models.Requests;

namespace Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private const int ACCESS_TOKEN_LIFETIME = 20; //minutes
        private const int REFRESH_TOKEN_LIFETIME = 1; //days

        private const int SALT_LENGTH = 32; //bytes

        private readonly ApplicationDbContext _dbContext;
        private readonly IConfiguration _config;

        public AccountsController(ApplicationDbContext context, IConfiguration config)
        {
            _dbContext = context;
            _config = config;
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
                refreshToken = refreshToken
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
            }
            catch (UndefinedUserRoleException)
            {
                return StatusCode(422, "Undefined user role occured");
            }


            await _dbContext.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return Ok();
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

        [HttpPost("picture/{userId}")]
        public async Task<ActionResult<Salon>> AssignProfilePicture(int userId, Picture picture)
        {
            var user = await _dbContext.Users.IncludeAll().FirstOrDefaultAsync(e => e.UserID == userId);

            if (user == null)
            {
                return NotFound();
            }

            var currentProfilePicture = user.ProfilePicture;
            user.ProfilePicture = picture;

            if (currentProfilePicture != null)
                _dbContext.Pictures.Remove(currentProfilePicture);

            _dbContext.Entry(user).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();

            return NoContent();
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
                PhoneNumber = registerRequest.PhoneNumber
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
