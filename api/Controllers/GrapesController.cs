using api.Data;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Mapper;
using Microsoft.EntityFrameworkCore;
using api.Repository;
using api.Interfaces;
using api.Dtos;
using api.Dtos.Grapes;

namespace api.Controllers
{
    [Route("api/grapes")]
    [ApiController]
    public class GrapesController : ControllerBase 
    {
        private readonly ApplicationDbContext _context;
        private readonly GrapesInterface _grapesRepo;
        public GrapesController(ApplicationDbContext context, GrapesInterface grapesRepo)
        {
            _context = context;
            _grapesRepo = grapesRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var grapes = await _grapesRepo.GetAllAsync();

            var GrapesDto = grapes.Select(s => s.ToGrapesDto());

            return Ok(GrapesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var grapes = await _grapesRepo.GetById(id);

            if (grapes == null)
            {
                return NotFound();
            }

            return Ok(grapes.ToGrapesDto());
        }

        [HttpPost("{VinesId}")]
        public async Task<IActionResult> Create([FromRoute] int VinesId, CreateGrapesDto createGrapesDto)
        {   
            if(!await _grapesRepo.VinesExistsAsync(VinesId))
            {
                return BadRequest("Not Found!");
            }


            var grapesModel = createGrapesDto.ToGrapesFromCreate(VinesId);
            await _grapesRepo.CreateAsync(grapesModel);
            return CreatedAtAction(nameof(GetById), new {id = grapesModel.Id},grapesModel.ToGrapesDto()); 
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateGrapesDto updateGrapes)
        {
            var grapesModel = await _grapesRepo.UpdateAsync(id, updateGrapes);

            if (grapesModel == null)
            {
                return NotFound();
            }

            return Ok(grapesModel.ToGrapesDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delte([FromRoute] int id)
        {
            var grapesModel = await _grapesRepo.DeleteAsync(id);

            if (grapesModel == null)
            {
                return NotFound();
            }

             return NoContent();
        }
    }
}
