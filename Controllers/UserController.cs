using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XecurityAPI.Data;
using XecurityAPI.Models;

namespace XecurityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly XecurityContext _context;

        public UserController(XecurityContext context)
        {
            _context = context;
        }

        [Route("GetUsers")]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _context.Users.ToListAsync();

            return Ok(users);
        }

    }
}
