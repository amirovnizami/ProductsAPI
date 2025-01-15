using API.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using ProductsAPI.Application.DTO;

namespace ProductsAPI.Application.Interfaces;

public interface IUserRepository
{
    Task<IdentityResult> RegisterUserAsync(UserDto model);
    Task<AppUser?> FindUserByEmailAsync(string email);
    Task<bool> CheckPasswordAsync(AppUser user, string password);

}