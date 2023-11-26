namespace Shared.DTOs;

public class OrderProductDetailsDto
{
    public int OrderProductDetailsId { get; set; }
    public int VinylId { get; set; }
    public int OrderId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
