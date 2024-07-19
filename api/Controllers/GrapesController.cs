using api.Data;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Mapper;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/grapes")]
    [ApiController]
    public class GrapesController : ControllerBase 
    {
        private readonly ApplicationDbContext _context;
        public GrapesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var grapes = await _context.Grapes.ToListAsync();

            var GrapesDto = grapes.Select(s => s.ToGrapesDto());

            return Ok(GrapesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var grapes = await _context.Grapes.FindAsync(id);

            if (grapes == null)
            {
                return NotFound();
            }

            return Ok(grapes.ToGrapesDto());
        }
    }
}
