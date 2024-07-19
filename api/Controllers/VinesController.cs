using api.Data;
using api.Dtos;
using api.Mapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/vines")]
    [ApiController] 
    public class VinesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public VinesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vines = await _context.Vines.ToListAsync();

            var vinesDto = vines.Select(s => s.ToVinesDto());

            return Ok(vinesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var vines = await _context.Vines.FindAsync(id);

            if (vines == null)
            {
                return NotFound();
            }

            return Ok(vines.ToVinesDto());
        }
    }
}
