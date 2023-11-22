using Shared.DTOs;
using DataLayer.Models;
using DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;

namespace BLL.Repositories;
public class GenreService : IGenreService
{
    private readonly EfDbContext _context;

    public GenreService(EfDbContext melodyMineService)
    {
        _context = melodyMineService;
    }

    public async Task<List<GenreDto>> GetAllGenres()
    {
        return await _context.Genres
            .Select(g => new GenreDto { GenreId = g.GenreId, GenreName = g.GenreName })
            .ToListAsync();
    }

    public async Task<GenreDto> GetGenresById(int genreId)
    {
        var genre = await _context.Genres.FindAsync(genreId);
        if (genre == null) return null;

        return new GenreDto { GenreId = genre.GenreId, GenreName = genre.GenreName };
    }

    public async Task CreateGenre(GenreDto genreDto)
    {
        var genre = new Genre { GenreName = genreDto.GenreName };
        _context.Genres.Add(genre);
        await _context.SaveChangesAsync();

        genreDto.GenreId = genre.GenreId;
    }

    public async Task UpdateGenre(GenreDto genreDto)
    {
        var genre = await _context.Genres.FindAsync(genreDto.GenreId);
        if (genre == null) return;

        genre.GenreName = genreDto.GenreName;
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteGenre(int id)
    {
        var genre = await _context.Genres.FindAsync(id);
        if (genre == null) return false;

        _context.Genres.Remove(genre);
        await _context.SaveChangesAsync();

        return true;
    }

    public IQueryable<VinylGenre> GetAllVinylGenres()
    {
        throw new NotImplementedException();
    }

    public void CreateVinylGenre(int VinylId, int GenreId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateVinylGenreLink(int vinylId, int genreId)
    {
        throw new NotImplementedException();
    }
}
