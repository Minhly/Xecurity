using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XecurityAPI.Data;
using XecurityAPI.Models;

namespace XecurityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeyCardController : ControllerBase
    {
        private readonly XecurityContext _context;

        public KeyCardController(XecurityContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetKeyCards()
        {
            var keyCards = await _context.KeyCards.ToListAsync();

            return Ok(keyCards);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetKeyCard(int id)
        {
            var keyCard = await _context.KeyCards.FindAsync(id);

            if(keyCard == null)
            {
                return BadRequest("Keycard not found!");
            }

            return Ok(keyCard);
        }

        /*
        [Route("PostKeyCardDataHistory")]
        [HttpPost]
        public async Task<ActionResult<KeyCardDataHistory>> PostKeyCardDataHistory(KeyCardDataHistory cardHistory, IFormFile image) {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (cardHistory.DateUploaded == null || cardHistory.Status == null || cardHistory.DateUploaded == null || cardHistory.KeyCardId == null) // imagedata isn't testet as its always null
            {
                return BadRequest(ModelState);
            }

            if (image == null || image.Length == 0)
            {
                return BadRequest("No image uploaded");
            }
            try
            {
                // create new filepath and save it in cardHistory
                var filePath = Path.Combine("C:/Users/HFGF/Desktop/Billeder_xecurity", image.FileName);
                cardHistory.ImageData = filePath;

                //save image
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
            _context.KeyCardDataHistories.Add(cardHistory);
            await _context.SaveChangesAsync();
            return Ok("Key card history updated");

        }*/

        
        [Route("PostKeyCardDataHistory2")]
        [HttpPost]
        public async Task<ActionResult<KeyCardDataHistory>> PostKeyCardDataHistory2(KeyCardDataHistory cardHistory) {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (cardHistory.DateUploaded == null || cardHistory.Status == null || cardHistory.DateUploaded == null || cardHistory.KeyCardId == null) // imagedata isn't testet as its always null
            {
                return BadRequest(ModelState);
            }

            _context.KeyCardDataHistories.Add(cardHistory);
            await _context.SaveChangesAsync();
            return Ok("Key card history updated");

        }


        [Route("PostKeyCardDataHistory")]
        [HttpPost]
        public async Task<ActionResult<KeyCardDataHistory>> PostKeyCardDataHistory(IFormFile image)
        {

            if (image == null || image.Length == 0)
            {
                return BadRequest("No image uploaded");
            }

            try
            {
                // create new filepath and save it in cardHistory
                var filePath = Path.Combine("C:/Users/HFGF/Desktop/Billeder_xecurity", image.FileName);

                //save image
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }
                return Ok(filePath);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            

        }

        [HttpPost]
        public async Task<ActionResult<KeyCard>> PostKeycard(KeyCard keyCard)
        {
            _context.KeyCards.Add(keyCard);
            await _context.SaveChangesAsync();
            return Ok(await _context.TemperatureData.ToListAsync());
        }

        [HttpDelete, Authorize(Roles = "Admin")]
        public async Task<ActionResult<KeyCard>> DeleteKeyCard(int id)
        {
            try
            {
                KeyCard keyCard = _context.KeyCards.First(x => x.Id == id);
                _context.KeyCards.Remove(keyCard);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Deleted");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<KeyCard>> UpdateKeycard(int id, KeyCard updatedKeyCard)
        {
            var keyCard = _context.KeyCards.FirstOrDefault(c => c.Id == id);

            keyCard.Password = updatedKeyCard.Password;
            keyCard.ExpDate = updatedKeyCard.ExpDate;
            keyCard.Active = updatedKeyCard.Active;
            keyCard.UserId = updatedKeyCard.UserId;

            await _context.SaveChangesAsync();

            return Ok(keyCard);

        }
        
    }
}
