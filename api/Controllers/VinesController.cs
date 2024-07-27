using api.Data;
using api.Dtos;
using api.Helpers;
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
        public async Task<IActionResult> GetAll([FromQuery] VinesQuery vinesQuery)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vines = await _vinesRepo.GetAllAsync(vinesQuery);

            var vinesDto = vines.Select(s => s.ToVinesDto());

            return Ok(vinesDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

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
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vinesModel = createVinesDto.ToVinesFromCreate();
            await _vinesRepo.CreateAsync(vinesModel);
            return CreatedAtAction(nameof(GetById), new {id = vinesModel.Id}, vinesModel.ToVinesDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateVinesDto updateVinesDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vinesModel = await _vinesRepo.UpdateAsync(id,updateVinesDto);
            
            if (vinesModel == null)
            {
                return NotFound();
            }
            return Ok(vinesModel.ToVinesDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delte([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vinesModel = await _vinesRepo.DeleteAsync(id);

            if (vinesModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
