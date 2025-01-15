using Microsoft.AspNetCore.Identity;

namespace API.Domain.Entities;

public class AppUser:IdentityUser<int>
{
    public string FullName { get; set; } = null!;
    public DateTime DateAdded { get; set; }
}