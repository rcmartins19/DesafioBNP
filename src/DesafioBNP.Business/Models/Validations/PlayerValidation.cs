using FluentValidation;

namespace DesafioBNP.Business.Models.Validations
{
    public class PlayerValidation : AbstractValidator<Player>
    {
        public PlayerValidation()
        {
            RuleFor(f => f.Name)
                .NotEmpty().WithMessage("The field {PropertyName} is mandatory")
                .Length(3, 100)
                .WithMessage("The field {PropertyName} must have between {MinLength} and {MaxLength} characters");

            RuleFor(f => f.Age)
                .NotNull().WithMessage("The field {PropertyName} is mandatory")
                .InclusiveBetween(15, 80)
                .WithMessage("The field {PropertyName} must be a value between {From} and {To}");

            RuleFor(f => f.ShirtNumber)
                .NotNull().WithMessage("The field {PropertyName} is mandatory")
                .InclusiveBetween(1, 99)
                .WithMessage("The field {PropertyName} must be a value between {From} and {To}");
        }
    }
}