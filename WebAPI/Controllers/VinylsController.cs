using BLL.Interfaces;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Shared.DTOs;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VinylsController : ControllerBase
    {
        private readonly IVinylService _vinylService;

        public VinylsController(IVinylService vinylService)
        {
            _vinylService = vinylService;
        }

        // GET: api/Vinyls
        [HttpGet]
        public ActionResult<List<VinylDto>> GetVinyls()
        {
            var vinyls = _vinylService.GetAllVinyls().ToList();
            var vinylDTOs = vinyls.Select(vinyl => new VinylDto
            {
                VinylId = vinyl.VinylId,
                Artist = vinyl.Artist,
                Title = vinyl.Title,
                Price = vinyl.Price,
                ImagePath = vinyl.ImagePath,
                GenreId = vinyl.GenreId,
                GenreName = vinyl.GenreName
            }).ToList();

            return Ok(vinylDTOs);
        }

        // GET: api/Vinyls/{id}
        [HttpGet("{id}")]
        public ActionResult<VinylDto> GetVinyl(int id)
        {
            var vinyl = _vinylService.GetVinylById(id);
            if (vinyl == null)
            {
                return NotFound();
            }

            var vinylDTO = new VinylDto
            {
                VinylId = vinyl.VinylId,
                Artist = vinyl.Artist,
                Title = vinyl.Title,
                Price = vinyl.Price,
                ImagePath = vinyl.ImagePath
            };

            return Ok(vinylDTO);
        }

        // PUT: api/Vinyls/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateVinyl(int id, VinylDto vinylDTO)
        {
            if (id != vinylDTO.VinylId)
            {
                return BadRequest();
            }

            var vinyl = new Vinyl
            {
                VinylId = vinylDTO.VinylId,
                Artist = vinylDTO.Artist,
                Title = vinylDTO.Title,
                Price = vinylDTO.Price,
                ImagePath = vinylDTO.ImagePath
            };

            _vinylService.UpdateVinylBy(id, vinylDTO);
            return NoContent();
        }

        // DELETE: api/Vinyls/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteVinyl(int id)
        {
            var success = _vinylService.DeleteVinylById(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Vinyls
        [HttpPost]
        public ActionResult<VinylDto> CreateVinyl(VinylDto vinylDTO)
        {
            var vinyl = _vinylService.CreateVinyl(vinylDTO);

            var newVinyl = new VinylDto
            {
                VinylId = vinyl.VinylId,
                Artist = vinyl.Artist,
                Title = vinyl.Title,
                Price = vinyl.Price,
                ImagePath = vinyl.ImagePath,
                GenreId = vinyl.GenreId
            };
            return CreatedAtAction(nameof(GetVinyl), new { id = newVinyl.VinylId }, newVinyl);
        }
    }
}