using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using DataLayer.Models;

public class Order
{
    public int OrderId { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; }

    public DateTime BuyDate { get; set; }

    [Required]
    public int AddressId { get; set; }

    // Navigation properties
    [JsonIgnore]
    public ICollection<OrderProductDetails> OrderProductDetails { get; set; }
    public Address Address { get; set; }
}