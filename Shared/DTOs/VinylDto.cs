using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs;

public class VinylDto
{
    public int VinylId { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string? Artist { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public string ImagePath { get; set; }

    public string GenreName { get; set; }
    public int GenreId { get; set; }
}