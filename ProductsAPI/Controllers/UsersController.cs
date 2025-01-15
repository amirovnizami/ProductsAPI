using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;
using API.Domain.Entities;
using ProductsAPI.Application.DTO;
using ProductsAPI.Application.Interfaces;

namespace productsAPI.Controllers
{
  
    [ApiController]
    [Route("api/Users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly ITokenService _tokenService;

        public UsersController(IUserRepository repository,ITokenService tokenService)
        {
            _repository = repository;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> CreateUser(UserDto model)
        {
            var validator = new UserDtoValidator();
            var results = validator.Validate(model);
            if (!results.IsValid)
            {
                foreach (var error in results.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return BadRequest(ModelState);
            }

            var result = await _repository.RegisterUserAsync(model);
            if (result.Succeeded)
            {
                return StatusCode(201);
            }
            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var user = await _repository.FindUserByEmailAsync(model.Email);
            if (user == null)
            {
                return BadRequest(new { message = "Email is invalid" });
            }

            var isPasswordValid = await _repository.CheckPasswordAsync(user, model.Password);
            if (!isPasswordValid)
            {
                return Unauthorized();
            }

            return Ok(new { token = _tokenService.GenerateJWT(user) });
        }
    }
}
