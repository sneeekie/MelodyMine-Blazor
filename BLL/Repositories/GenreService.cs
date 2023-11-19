using BLL.Interfaces;
using DAL;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BLL.Repositories;

public class GenreService : IGenreService
{
    private readonly EfDbContext _context;

    public GenreService(EfDbContext melodyMineService)
    {
        _context = melodyMineService;
    }
    
    public IQueryable<Genre> GetAllGenres()
    {
        IQueryable<Genre> tempGenres = _context.Genres.Distinct();
        
        return tempGenres;
    }

    
    public IQueryable<Genre> GetGenresById(int genreId)
    {
        IQueryable<Genre> tempGenres = _context.Genres.Where(c => c.GenreId == genreId);

        return tempGenres;
    }
    
    public IQueryable<VinylGenre> GetAllVinylGenres()
    {
        IQueryable<VinylGenre> tempGenres = _context.VinylGenres;
            
        return tempGenres;
    }
    
    public void CreateVinylGenre(int VinylId, int GenreId)
    {
        _context.VinylGenres.Add(new VinylGenre { VinylId = VinylId, GenreId = GenreId });
        _context.SaveChanges();
    }
    
    public void CreateGenre(Genre genre)
    {
        _context.Genres.Add(genre);
        _context.SaveChanges();
    }
    
    public void UpdateGenre(Genre genre)
    {
        var existingGenre = _context.Genres.Find(genre.GenreId);
        if (existingGenre != null)
        {
            existingGenre.GenreName = genre.GenreName;
            _context.SaveChanges();
        }
    }

    public bool DeleteGenre(int genreId)
    {
        var genre = _context.Genres.Find(genreId);
        if (genre != null)
        {
            _context.Genres.Remove(genre);
            _context.SaveChanges();
            return true;
        }
        return false;
    }
    
    public async Task UpdateVinylGenreLink(int vinylId, int genreId)
    {
        var vinyl = _context.Vinyls.Include(v => v.VinylGenres).FirstOrDefault(v => v.VinylId == vinylId);
        if (vinyl.VinylGenres.Any())
        {
            vinyl.VinylGenres.Clear();
        }
        
        var newVinylGenre = new VinylGenre { VinylId = vinylId, GenreId = genreId };
        vinyl.VinylGenres.Add(newVinylGenre);
        
        await _context.SaveChangesAsync();
    }
}