﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using XecurityAPI.Data;
using XecurityAPI.Models;

namespace XecurityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorController : ControllerBase
    {
        private readonly XecurityContext _context;

        public SensorController(XecurityContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSensor(int id)
        {
            var sensor = await _context.Sensors.FindAsync(id);

            if (sensor == null)
            {
                return BadRequest("Sensor not found!");
            }

            return Ok(sensor);
        }

        [Route("GetSensors")]
        [HttpGet]
        public async Task<IActionResult> GetSensors()
        {
            var sensors = await _context.Sensors.ToListAsync();

            return Ok(sensors);
        }

        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<ActionResult<Sensor>> PostSensor(Sensor sensor)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _context.Sensors.Add(sensor);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.GetBaseException().Message);
                return StatusCode(500, ModelState);
            }

            return CreatedAtAction("GetSensor", new { id = sensor.Id }, sensor);
        }
    }
}
