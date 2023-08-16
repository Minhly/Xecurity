using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XecurityAPI.Data;
using XecurityAPI.Models;

namespace XecurityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeyCardHistoryController : ControllerBase
    {
        private readonly XecurityContext _context;

        public KeyCardHistoryController(XecurityContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetKeyHistoryCards()
        {
            var keyCardHistories = await _context.KeyCardDataHistories.ToListAsync();

            return Ok(keyCardHistories);
        }
    }
}
