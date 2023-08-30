using Microsoft.AspNetCore.Mvc;


[Route("api/[controller]")]
public class GenresController : Controller
{
    private readonly GenresService _context;
    public GenresController(GenresService context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<ActionResult> Get()
    {
        try
        {
            return Ok(await _context.GetAllGenresAsync());
        }
        catch
        {
            return BadRequest();
        }
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var model = await _context.GetGenresAsync(id);
        return model == null ? NotFound() : Ok(model);
    }

    [HttpPost]
    public async Task<IActionResult> Add(GenreVM model)
    {
        try
        {
            var newModelId = await _context.AddGenreAsync(model);
            var result = await _context.GetGenresAsync(newModelId);
            return result == null ? NotFound() : Ok(result);
        }
        catch
        {
            return BadRequest();
        }
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody]GenreVM model){
        if(id != model.IdGenre){
            return NotFound();
        }
        await _context.UpdateGenreAsync(model, id);
        return Ok();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id){
        await _context.DeleteGenreAsync(id);
        return Ok();
    }
}