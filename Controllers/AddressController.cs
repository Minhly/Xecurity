using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XecurityAPI.Data;
using XecurityAPI.Models;

namespace XecurityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly XecurityContext _context;

        public AddressController(XecurityContext context)
        {
            _context = context;
        }

        [Route("GetAllAddressTempData")]
        [HttpGet]
        public async Task<ActionResult<List<ServerRoom>>> GetAllAddressTempData()
        {
            var addresses = await _context.ServerRooms
            .Include(q => q.Location)
            .Include(e => e.Location.Address)
            .ToListAsync();

            return addresses;
        }

    }
}
