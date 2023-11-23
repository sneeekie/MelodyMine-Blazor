using BLL.Interfaces;
using DAL;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Shared.DTOs;

namespace BLL.Repositories;

public class VinylService : IVinylService
{
    private readonly EfDbContext _context;

    public VinylService(EfDbContext context)
    {
        _context = context;
    }

    public Vinyl CreateVinyl(VinylDto vinylDTO)
    {
        var vinyl = new Vinyl
        {
            Artist = vinylDTO.Artist,
            Title = vinylDTO.Title,
            Price = vinylDTO.Price,
            ImagePath = vinylDTO.ImagePath,
            GenreId = vinylDTO.GenreId
        };

        _context.Vinyls.Add(vinyl);
        _context.SaveChanges();

        return vinyl;
    }

    public bool DeleteVinylById(int vinylId)
    {
        var vinyl = _context.Vinyls.Find(vinylId);
        if (vinyl != null)
        {
            _context.Vinyls.Remove(vinyl);
            _context.SaveChanges();
        }

        return false;
    }

    public VinylDto GetVinylById(int id)
    {
        var vinyl = _context.Vinyls
            .Include(v => v.Genre)
            .FirstOrDefault(v => v.VinylId == id);

        if (vinyl == null)
        {
            return null;
        }

        return new VinylDto
        {
            VinylId = vinyl.VinylId,
            Artist = vinyl.Artist,
            Title = vinyl.Title,
            Price = vinyl.Price,
            ImagePath = vinyl.ImagePath,
            GenreName = vinyl.Genre.GenreName,
            GenreId = vinyl.GenreId
        };
    }

    public void UpdateVinylBy(int vinylId, VinylDto newVinylDTO)
    {
        var vinyl = _context.Vinyls.Find(vinylId);
        if (vinyl != null)
        {
            vinyl.Title = newVinylDTO.Title;
            vinyl.Artist = newVinylDTO.Artist;
            vinyl.Price = newVinylDTO.Price;
            vinyl.ImagePath = newVinylDTO.ImagePath;
            _context.SaveChanges();
        }
    }

    public IQueryable<VinylDto> GetAllVinyls()
    {
        return _context.Vinyls
            .Include(v => v.Genre)
            .Select(v => new VinylDto
            {
                VinylId = v.VinylId,
                Artist = v.Artist,
                Title = v.Title,
                Price = v.Price,
                ImagePath = v.ImagePath,
                GenreName = v.Genre.GenreName,
                GenreId = v.GenreId
            });
    }

    public IQueryable<VinylDto> GetAllVinylsPaged(int currentPage, int pageSize)
    {
        var vinyls = _context.Vinyls
            .Include(v => v.Genre)
            .ToList();

        return vinyls.Select(v => new VinylDto
        {
            VinylId = v.VinylId,
            Artist = v.Artist,
            Title = v.Title,
            Price = v.Price,
            ImagePath = v.ImagePath,
            GenreName = v.Genre.GenreName,
            GenreId = v.GenreId
        })
        .AsQueryable()
        .OrderBy(v => v.VinylId)
        .Skip((currentPage - 1) * pageSize)
        .Take(pageSize);
    }

    public IQueryable<VinylDto> GetAllFullVinyls()
    {
        return _context.Vinyls
            .Include(v => v.Genre)
            .Select(v => new VinylDto
            {
                VinylId = v.VinylId,
                Artist = v.Artist,
                Title = v.Title,
                Price = v.Price,
                ImagePath = v.ImagePath,
                GenreName = v.Genre.GenreName,
                GenreId = v.GenreId
            });
    }

    public IQueryable<VinylDto> GetAllFullVinylsPaged(int currentPage, int pageSize)
    {
        var vinyls = _context.Vinyls
            .Include(v => v.Genre)
            .ToList();

        return vinyls.Select(v => new VinylDto
        {
            VinylId = v.VinylId,
            Artist = v.Artist,
            Title = v.Title,
            Price = v.Price,
            ImagePath = v.ImagePath,
            GenreName = v.Genre.GenreName,
            GenreId = v.GenreId
        })
        .AsQueryable()
        .OrderBy(v => v.VinylId)
        .Skip((currentPage - 1) * pageSize)
        .Take(pageSize);
    }

    public IQueryable<VinylDto> FilterVinylsPaged(
    int currentPage,
    int pageSize,
    string? searchTerm,
    int? genreId,
    string? filterTitle,
    string? price)
    {
        var query = _context.Vinyls
            .Include(v => v.Genre)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            query = query.Where(v => v.Title.Contains(searchTerm));
        }

        if (genreId.HasValue && genreId.Value > 0)
        {
            query = query.Where(v => v.GenreId == genreId.Value);
        }

        if (!string.IsNullOrWhiteSpace(filterTitle))
        {
            query = filterTitle == "+"
                ? query.OrderBy(v => v.Title)
                : query.OrderByDescending(v => v.Title);
        }

        if (!string.IsNullOrWhiteSpace(price))
        {
            query = price == "+"
                ? query.OrderBy(v => v.Price)
                : query.OrderByDescending(v => v.Price);
        }

        return query
        .Select(v => new VinylDto
        {
            VinylId = v.VinylId,
            Artist = v.Artist,
            Title = v.Title,
            Price = v.Price,
            ImagePath = v.ImagePath,
            GenreName = v.Genre.GenreName,
            GenreId = v.GenreId
        })
        .Skip((currentPage - 1) * pageSize)
        .Take(pageSize);
    }

    public enum SortDirection
    {
        Ascending,
        Descending
    }

    public IQueryable<VinylDto> FilterVinyls(
    string searchTerm,
    int? genreId,
    string titleSort,
    string priceSort)
    {
        SortDirection? titleSortDirection = ParseSortDirection(titleSort);
        SortDirection? priceSortDirection = ParseSortDirection(priceSort);

        IQueryable<Vinyl> query = _context.Vinyls
            .Include(v => v.Genre);

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            query = query.Where(v => EF.Functions.Like(v.Title, $"%{searchTerm}%"));
        }

        if (genreId.HasValue && genreId.Value > 0)
        {
            query = query.Where(v => v.GenreId == genreId.Value);
        }

        if (titleSortDirection.HasValue)
        {
            query = titleSortDirection == SortDirection.Ascending
                ? query.OrderBy(v => v.Title)
                : query.OrderByDescending(v => v.Title);
        }

        if (priceSortDirection.HasValue)
        {
            query = priceSortDirection == SortDirection.Ascending
                ? query.OrderBy(v => v.Price)
                : query.OrderByDescending(v => v.Price);
        }

        return query.Select(v => new VinylDto
        {
            VinylId = v.VinylId,
            Artist = v.Artist,
            Title = v.Title,
            Price = v.Price,
            ImagePath = v.ImagePath,
            GenreName = v.Genre.GenreName,
            GenreId = v.GenreId
        });
    }

    private SortDirection? ParseSortDirection(string sortParameter)
    {
        return sortParameter switch
        {
            "Ascending" => SortDirection.Ascending,
            "Descending" => SortDirection.Descending,
            _ => null
        };
    }

    public PaginatedResult<VinylDto> GetPaginatedVinyls(int currentPage, int pageSize, string searchTerm, int? genreId, string titleSort, string priceSort)
    {
        var query = FilterVinyls(searchTerm, genreId, titleSort, priceSort);
        var totalRecords = query.Count();

        var items = query
            .Skip((currentPage - 1) * pageSize)
            .Take(pageSize)
            .Select(v => new VinylDto
            {
                VinylId = v.VinylId,
                Artist = v.Artist,
                Title = v.Title,
                Price = v.Price,
                ImagePath = v.ImagePath,
                GenreName = v.GenreName,
                GenreId = v.GenreId
            })
            .ToList();

        return new PaginatedResult<VinylDto>
        {
            Items = items,
            CurrentPage = currentPage,
            TotalPages = (int)Math.Ceiling(totalRecords / (double)pageSize)
        };
    }
}