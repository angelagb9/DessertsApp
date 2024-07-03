using MediatR;

namespace DessertsApp.Commands.ColorCommands.ActivateColor
{
    public class ActivateColorCommand : IRequest<ActivateColorResponse>
    {
        public int Id { get; set; }
    }
}
