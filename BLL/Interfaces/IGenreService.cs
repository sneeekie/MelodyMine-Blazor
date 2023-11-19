using DataLayer.Models;

namespace BLL.Interfaces;

public interface IGenreService
{
    public IQueryable<Genre> GetAllGenres();
    public IQueryable<Genre> GetGenresById(int genreId);
    public IQueryable<VinylGenre> GetAllVinylGenres();
    public void CreateVinylGenre(int VinylId, int GenreId);
    void CreateGenre(Genre genre);
    void UpdateGenre(Genre genre);
    Task UpdateVinylGenreLink(int vinylId, int genreId);
    bool DeleteGenre(int genreId);

}