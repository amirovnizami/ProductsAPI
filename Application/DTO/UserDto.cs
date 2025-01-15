using FluentValidation;

namespace ProductsAPI.Application.DTO;

public class UserDto
{
    public string FullName { get; set; } = null!;
    public string? UserName { get; set; } = null!;
    public string? Email { get; set; } = null!;
    public string? Password { get; set; } = null!;
}
public class UserDtoValidator : AbstractValidator<UserDto>
{
    public UserDtoValidator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("Full Name cannot be empty.")
            .MinimumLength(3).WithMessage("Full Name must be at least 3 characters.")
            .Matches(@"^[a-zA-Z]+$").WithMessage("You can only enter string values.");

        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("User Name cannot be empty.")
            .MinimumLength(3).WithMessage("User Name must be at least 3 characters.")
            .Matches(@"^[a-zA-Z]+$").WithMessage("You can only enter string values.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email format");
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters.");
    }

}