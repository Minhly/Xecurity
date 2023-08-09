using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XecurityAPI.Models;

namespace XecurityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        private readonly XecurityDbContext _context;

        public TemperatureController(XecurityDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetTemperatures()
        {
            return Ok(await _context.TemperatureData.ToListAsync());
        }
    }
}
