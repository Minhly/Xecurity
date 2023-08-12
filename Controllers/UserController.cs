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

/*        [HttpGet]
        public async Task<IActionResult> GetTemperature()
        {
        }

        [HttpPost]
        public async Task<ActionResult<TemperatureDatum>> PostTemperatures(TemperatureDatum temperature)
        {
        }*/
    }
}
