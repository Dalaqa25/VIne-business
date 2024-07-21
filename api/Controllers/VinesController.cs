using api.Data;
using api.Dtos;
using api.Interfaces;
using api.Mapper;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/vines")]
    [ApiController] 
    public class VinesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly VinesInterface _vinesRepo;
        public VinesController(ApplicationDbContext context, VinesInterface vinesRepo)
        {
            _context = context;
            _vinesRepo = vinesRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vines = await _vinesRepo.GetAllAsync();

            var vinesDto = vines.Select(s => s.ToVinesDto());

            return Ok(vinesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var vines = await _vinesRepo.GetByIdAsync(id);

            if (vines == null)
            {
                return NotFound();
            }

            return Ok(vines.ToVinesDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateVinesDto createVinesDto)
        {
            var vinesModel = createVinesDto.ToVinesFromCreate();
            await _vinesRepo.CreateAsync(vinesModel);
            return CreatedAtAction(nameof(GetById), new {id = vinesModel.Id}, vinesModel.ToVinesDto());
        }
    }
}
