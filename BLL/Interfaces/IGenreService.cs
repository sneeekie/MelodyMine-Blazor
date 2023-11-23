using DataLayer.Models;
using Shared.DTOs;

namespace BLL.Interfaces;

public interface IGenreService
{
    Task<List<GenreDto>> GetAllGenres();
    Task<GenreDto> GetGenresById(int genreId);
    Task CreateGenre(GenreDto genreDto);
    Task UpdateGenre(GenreDto genreDto);
    Task<bool> DeleteGenre(int id);
}