using FluentValidation;

namespace DessertsApp.Commands.ColorCommands.CreateColor
{
    public class CreateColorValidator : AbstractValidator<CreateColorCommand>
    {
        public CreateColorValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Color name is required.");
        }
    }
}
