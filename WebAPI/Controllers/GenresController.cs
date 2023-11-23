using BLL.Interfaces;
using Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        // GET: api/Genres
        [HttpGet]
        public async Task<ActionResult<List<GenreDto>>> GetGenres()
        {
            var genres = await _genreService.GetAllGenres();
            if (genres == null)
            {
                return NotFound();
            }
            return Ok(genres);
        }

        // GET: api/Genres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GenreDto>> GetGenre(int id)
        {
            var genre = await _genreService.GetGenresById(id);
            if (genre == null)
            {
                return NotFound();
            }
            return Ok(genre);
        }

        // POST: api/Genres
        [HttpPost]
        public async Task<ActionResult<GenreDto>> PostGenre(GenreDto genre)
        {
            await _genreService.CreateGenre(genre);
            return CreatedAtAction(nameof(GetGenre), new { id = genre.GenreId }, genre);
        }

        // PUT: api/Genres/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenre(int id, GenreDto genre)
        {
            if (id != genre.GenreId)
            {
                return BadRequest();
            }

            await _genreService.UpdateGenre(genre);

            return NoContent();
        }

        // DELETE: api/Genres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            var success = await _genreService.DeleteGenre(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}