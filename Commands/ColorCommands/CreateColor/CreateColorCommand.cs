using MediatR;

namespace DessertsApp.Commands.ColorCommands.CreateColor
{
    public class CreateColorCommand : IRequest<CreateColorResponse>
    {
        public string Name { get; set; }
    }
}
