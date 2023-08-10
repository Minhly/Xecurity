using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XecurityAPI.Data;

namespace XecurityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        private readonly XecurityDevDbContext _context;

        public TemperatureController(XecurityDevDbContext context)
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
