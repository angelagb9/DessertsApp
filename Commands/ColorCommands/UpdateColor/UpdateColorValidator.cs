using FluentValidation;

namespace DessertsApp.Commands.ColorCommands.UpdateColor
{
    public class UpdateColorValidator : AbstractValidator<UpdateColorCommand>
    {
        public UpdateColorValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Color name is required.");
        }
    }
}
