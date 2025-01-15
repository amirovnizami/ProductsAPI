using API.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using ProductsAPI.Application.DTO;
using ProductsAPI.Application.Interfaces;

namespace Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IConfiguration _configuration;

    public UserRepository(UserManager<AppUser> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task<IdentityResult> RegisterUserAsync(UserDto model)
    {
        var user = new AppUser
        {
            FullName = model.FullName,
            UserName = model.UserName,
            Email = model.Email,
            DateAdded = DateTime.Now,
        };
        return await _userManager.CreateAsync(user, model.Password);
    }

    public async Task<AppUser?> FindUserByEmailAsync(string email)
    {
        return await _userManager.FindByEmailAsync(email);
    }

    public async Task<bool> CheckPasswordAsync(AppUser user, string password)
    {
        return await _userManager.CheckPasswordAsync(user, password);
    }

   
    // public string GenerateJWT(AppUser user)
    // {
    //     var tokenHandler = new JwtSecurityTokenHandler();
    //     var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Secret").Value ?? "");
    //     var tokenDescriptor = new SecurityTokenDescriptor
    //     {
    //         Subject = new ClaimsIdentity(new[]
    //         {
    //             new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
    //             new Claim(ClaimTypes.Name, user.UserName ?? ""),
    //         }),
    //         Expires = DateTime.UtcNow.AddDays(1),
    //         SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
    //     };
    //     var token = tokenHandler.CreateToken(tokenDescriptor);
    //     return tokenHandler.WriteToken(token);
    // }
}