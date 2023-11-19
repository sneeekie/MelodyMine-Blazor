using BLL.Interfaces;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers;

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
    public ActionResult<IEnumerable<Vinyl>> GetVinyls()
    {
        return Ok(_vinylService.GetAllVinyls().ToList());
    }
    
    // GET: api/Vinyls/{id}
    [HttpGet("{id}")]
    public ActionResult<Vinyl> GetVinyl(int id)
    {
        var vinyl = _vinylService.GetVinylById(id);
        if (vinyl == null)
        {
            return NotFound();
        }
        return Ok(vinyl);
    }

    // POST: api/Vinyls
    [HttpPost]
    public ActionResult<Vinyl> CreateVinyl(Vinyl vinyl)
    {
        _vinylService.CreateVinyl(vinyl);
        return CreatedAtAction(nameof(GetVinyl), new { id = vinyl.VinylId }, vinyl);
    }

    // PUT: api/Vinyls/{id}
    [HttpPut("{id}")]
    public IActionResult UpdateVinyl(int id, Vinyl vinyl)
    {
        if (id != vinyl.VinylId)
        {
            return BadRequest();
        }
        _vinylService.UpdateVinylBy(id, vinyl);
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
}