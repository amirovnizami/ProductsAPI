using FluentValidation;

namespace API.Domain.Entities;

public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = null!;
    public decimal Price { get; set; }
    public bool IsActive { get; set; }
}
public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(x => x.ProductName).NotEmpty().WithMessage("Full Name cannot be empty.")
            .MinimumLength(3).WithMessage("Full Name must be at least 3 characters.")
            .Matches(@"^[a-zA-Z]+$").WithMessage("You can only enter string values.");
        RuleFor(x => x.Price).NotEmpty().WithMessage("Full Name cannot be empty.")
            .GreaterThanOrEqualTo(1)
            .WithMessage("Status unique identifier must be greater or equal to 1");

    }

}