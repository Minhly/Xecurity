using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XecurityAPI.Data;
using XecurityAPI.Dtos;
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
            var keyCardHistory = await _context.KeyCardDataHistories
            .Select(e => new KeyCardHistoryDto
            {
                Id = e.Id,
                DateUploaded = e.DateUploaded,
                ImageData = e.ImageData,
                Status = e.Status,
                ServerRoomName = e.ServerRoomName,
                KeyCardId = e.KeyCard.Id,
                AddressName = e.KeyCard.KeycardServerrooms.FirstOrDefault().ServerRoom.Location.Address.Addresse,
                LocationName = e.KeyCard.KeycardServerrooms.FirstOrDefault().ServerRoom.Location.Name,
                User = e.KeyCard.User.Name
            })
            .OrderByDescending(e => e.Id)
            .ToListAsync();

            return Ok(keyCardHistory);
        }
    }
}
