using DataLayer.Models;
using Shared.DTOs;

namespace BLL.Interfaces;

public interface IGenreService
{
    Task<List<GenreDto>> GetAllGenres();
    Task<GenreDto> GetGenresById(int genreId);
    public IQueryable<VinylGenre> GetAllVinylGenres();
    public void CreateVinylGenre(int VinylId, int GenreId);
    Task CreateGenre(GenreDto genreDto);
    Task UpdateGenre(GenreDto genreDto);
    Task UpdateVinylGenreLink(int vinylId, int genreId);
    Task<bool> DeleteGenre(int id);
}