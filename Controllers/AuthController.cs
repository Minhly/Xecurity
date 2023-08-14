using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using XecurityAPI.Data;
using XecurityAPI.Dtos;
using XecurityAPI.Models;

namespace XecurityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new User();

        private readonly XecurityContext _context;

        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration, XecurityContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpGet, Authorize]
        public ActionResult<object> GetUserClaims()
        {
            var userName = User?.Identity?.Name;
            var userName2 = User.FindFirstValue(ClaimTypes.Name);
            var role = User.FindFirstValue(ClaimTypes.Role);

            return Ok(new { userName, userName2, role });
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(User request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.Name = request.Name;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.UserTypeId = request.UserTypeId;

            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
            foreach (var user in _context.Users)
            {
                if (request.Username == user.Name)
                {
                    if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
                    {
                        return BadRequest("Wrong password!");
                    }
                    string token = CreatToken(user);
                    return Ok(token);
                }
            }

            return BadRequest("User not found.");
        }

        private string CreatToken(User user)
        {
            var userType = (UserTypeEnum)user.UserTypeId;

            List<Claim> claims = new List<Claim> { 
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, userType.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(100),
                    signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
