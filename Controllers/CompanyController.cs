using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XecurityAPI.Data;
using XecurityAPI.Models;

namespace XecurityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly XecurityContext _context;

        public CompanyController(XecurityContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await _context.Companies.ToListAsync();

            return Ok(companies);
        }

        [HttpPost]
        public async Task<ActionResult<Company>> PostCompanies(Company company)
        {
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();
            return Ok(await _context.Companies.ToListAsync());
        }
    }
}
