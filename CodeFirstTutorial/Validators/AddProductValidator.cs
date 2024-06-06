using CodeFirstTutorial.RequestModels;
using FluentValidation;

namespace CodeFirstTutorial.Validators;

public class AddProductValidator : AbstractValidator<AddProductRequestModel>
{
    public AddProductValidator()
    {
        RuleFor(e => e.ProductName).NotEmpty().NotNull().MaximumLength(100);
        RuleFor(e => e.ProductWeight).NotEmpty().NotNull().PrecisionScale(5,2,false);
        RuleFor(e => e.ProductWidth).NotEmpty().NotNull().PrecisionScale(5,2,false);
        RuleFor(e => e.ProductHeight).NotEmpty().NotNull().PrecisionScale(5,2,false);
        RuleFor(e => e.ProductDepth).NotEmpty().NotNull().PrecisionScale(5,2,false);
        RuleFor(e => e.ProductCategories).NotEmpty().NotNull();
    }

}