using MediatR;

namespace DessertsApp.Commands.ColorCommands.DisableColor
{
    public class DisableColorCommand : IRequest<DisableColorResponse>
    {
        public int Id { get; set; }
    }
}
