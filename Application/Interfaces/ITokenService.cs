using API.Domain.Entities;

namespace ProductsAPI.Application.Interfaces;

public interface ITokenService
{
    string GenerateJWT(AppUser user);
}