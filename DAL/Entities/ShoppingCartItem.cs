using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models;

public class ShoppingCartItem
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int VinylId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
    public int Quantity { get; set; }

    public string Title { get; set; }
    public decimal Price { get; set; }
}