using System.ComponentModel.DataAnnotations;

namespace ProductsAPI.Application.DTO;

public class LoginDto
{
    [Required]
    public string? Email { get; set; } = null!;
    [Required]
    public string? Password { get; set; } = null!;
}