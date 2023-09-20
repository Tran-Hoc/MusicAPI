using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicAPI.Models;
using MusicAPI.Repositories.Interface;
using MusicAPI.ViewModel;

namespace MusicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenresRepository _repo;

        public GenresController(IGenresRepository repository)
        {
            _repo = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Gets()
        {
            try
            {
                return Ok(await _repo.GetAllAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _repo.GetAsync(id);
            return model == null ? NotFound() : Ok(model);
        }

        [HttpPost]
    
        public async Task<IActionResult> Create(GenresVM model)
        {
            try
            {
                var newModelId = await _repo.AddAsync(model);
                var newmodel = await _repo.GetAsync(newModelId);
                return model == null ? NotFound() : Ok(newmodel);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
       
        public async Task<IActionResult> Update(int id, [FromBody] GenresVM model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }
            if (await _repo.UpdateAsync(id, model) == -1)
            {
                return BadRequest();
            }
            return Ok();
        }
       
        [HttpDelete("{id}")]
       
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (await _repo.DeleteAsync(id) == -1)
                return NotFound();
            return Ok();
        }
    }
}
