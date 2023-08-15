using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XecurityAPI.Data;
using XecurityAPI.Models;

namespace XecurityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        private readonly XecurityContext _context;

        public TemperatureController(XecurityContext context)
        {
            _context = context;
        }

        [HttpGet, Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetTemperature()
        {
            var temperatures = await _context.TemperatureData.ToListAsync();
            
            var temperature = temperatures.OrderByDescending(x => x.Id).FirstOrDefault();

            return Ok(temperature);
        }

        [Route("GetTemperaturesFromTheLastHour")]
        [HttpGet]
        public async Task<IActionResult> GetTemperaturesFromTheLastHour()
        {
            DateTime filter = new DateTime();
            filter = DateTime.UtcNow.AddHours(-1);
            var temperatures = await _context.TemperatureData.ToListAsync();
            var temperaturesFiltered = new List<TemperatureDatum>();

            foreach(var temperature in temperatures)
            {
                if(temperature.DateUploaded > filter)
                {
                    temperaturesFiltered.Add(temperature);
                }
            }

            return Ok(temperaturesFiltered);
        }

        [HttpPost]
        public async Task<ActionResult<TemperatureDatum>> PostTemperatures(TemperatureDatum temperature)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

/*            if (temperature.Humidity == null || temperature.Temperature == null || temperature.DateUploaded == null || temperature.SensorId == null)
            {
                return BadRequest(ModelState);
            }*/

            try
            {
                _context.TemperatureData.Add(temperature);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.GetBaseException().Message);
                return StatusCode(500, ModelState);
            }

            return CreatedAtAction("GetTemperature", new { id = temperature.Id }, temperature);
        }
    }
}
