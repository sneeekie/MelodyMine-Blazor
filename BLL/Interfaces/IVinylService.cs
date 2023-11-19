using DataLayer.Models;

namespace BLL.Interfaces;

public interface IVinylService
{
    public void CreateVinyl(Vinyl vinyl);
    public bool DeleteVinylById(int VinylId);
    public Vinyl GetVinylById(int id);
    public void UpdateVinylBy(int vinylId, Vinyl newVinyl);
    public IQueryable<Vinyl> GetAllVinyls();
    public IQueryable<Vinyl> GetAllVinylsPaged(int currentPage, int pageSize);
    public IQueryable<Vinyl> GetAllFullVinylsPaged(int currentPage, int pageSize);
    public IQueryable<Vinyl> FilterVinylsPaged(int currentPage, int pageSize, string? SearchTerm, int? GenreId, string? FilterTitle, string? Price);
    PaginatedResult<Vinyl> GetPaginatedVinyls(int currentPage, int pageSize, string searchTerm, int? genreId, string titleSort, string priceSort);

    // Both used in GetPaginatedVinyls
    public IQueryable<Vinyl> GetAllFullVinyls();
    public IQueryable<Vinyl> FilterVinyls(
        string searchTerm,
        int? genreId,
        string titleSort,
        string priceSort);
}