using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XecurityAPI.Data;
using XecurityAPI.Models;

namespace XecurityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly XecurityContext _context;

        public LocationController(XecurityContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetLocations()
        {
            var locations = await _context.Locations.ToListAsync();

            return Ok(locations);
        }

        [HttpPost]
        public async Task<ActionResult<Location>> PostLocations(Location location)
        {
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();
            return Ok(await _context.Locations.ToListAsync());
        }
    }
}
