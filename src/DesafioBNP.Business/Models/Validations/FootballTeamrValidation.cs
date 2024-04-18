using FluentValidation;

namespace DesafioBNP.Business.Models.Validations
{
    public class FootballTeamValidation : AbstractValidator<FootballTeam>
    {
        public FootballTeamValidation()
        {
            RuleFor(f => f.TeamName)
                .NotEmpty().WithMessage("The field {PropertyName} is mandatory")
                .Length(3, 100)
                .WithMessage("The field {PropertyName} must have between {MinLength} and {MaxLength} characters");

            RuleFor(f => f.City)
                .NotEmpty().WithMessage("The field {PropertyName} is mandatory")
                .Length(3, 100)
                .WithMessage("The field {PropertyName} must have between {MinLength} and {MaxLength} characters");

            RuleFor(f => f.FoundationYear)
                .NotNull().WithMessage("The field {PropertyName} is mandatory")
                .InclusiveBetween(1900, 2024)
                .WithMessage("The field {PropertyName} must be a value between {From} and {To}");
        }
    }
}