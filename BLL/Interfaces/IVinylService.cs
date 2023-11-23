using Shared.DTOs;
using DataLayer.Models;

namespace BLL.Interfaces;

public interface IVinylService
{
    Vinyl CreateVinyl(VinylDto vinylDto);
    bool DeleteVinylById(int VinylId);
    VinylDto GetVinylById(int id);
    void UpdateVinylBy(int vinylId, VinylDto newVinylDTO);
    IQueryable<VinylDto> GetAllVinyls();
    IQueryable<VinylDto> GetAllVinylsPaged(int currentPage, int pageSize);
    IQueryable<VinylDto> GetAllFullVinylsPaged(int currentPage, int pageSize);
    IQueryable<VinylDto> FilterVinylsPaged(int currentPage, int pageSize, string? SearchTerm, int? GenreId, string? FilterTitle, string? Price);
    PaginatedResult<VinylDto> GetPaginatedVinyls(int currentPage, int pageSize, string searchTerm, int? genreId, string titleSort, string priceSort);

    // Both used in GetPaginatedVinyls
    IQueryable<VinylDto> GetAllFullVinyls();
    IQueryable<VinylDto> FilterVinyls(
        string searchTerm,
        int? genreId,
        string titleSort,
        string priceSort);
}