using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicAPI.Repositories.Interface;
using MusicAPI.ViewModel;

namespace MusicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayListController : ControllerBase
    {
        private readonly IPlaylistRepositories _repo;

        public PlayListController(IPlaylistRepositories repository)
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

        public async Task<IActionResult> Create(PlaylistVM model)
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

        public async Task<IActionResult> Update(int id, [FromBody] PlaylistVM model)
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
