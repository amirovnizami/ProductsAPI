using System.ComponentModel.DataAnnotations;

namespace ProductsAPI.Application.DTO;

public class ProductDto
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = null!;
    public decimal Price { get; set; }
}