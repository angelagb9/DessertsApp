using MediatR;

namespace DessertsApp.Commands.ColorCommands.UpdateColor
{
    public class UpdateColorCommand : IRequest<UpdateColorResponse>
    {
        public int Id { get; set; }
        public String Name { get; set; }
    }
}
