using AutoMapper;
using DessertsApp.Commands.ColorCommands.CreateColor;
using DessertsApp.Commands.ColorCommands.UpdateColor;
using DessertsApp.Exceptions;
using DessertsApp.Models;
using DessertsApp.Repositories;
using MediatR;

namespace DessertsApp.Commands.ColorCommands.ActivateColor
{
    public class ActivateColorHandler : IRequestHandler<ActivateColorCommand, ActivateColorResponse>
    {
        private ColorRepository _colorRepository;
        private IMapper _mapper;

        public ActivateColorHandler(ColorRepository colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }
        public async Task<ActivateColorResponse> Handle(ActivateColorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var color = await _colorRepository.dbSet.FindAsync(request.Id);

                if (color == null)
                    throw new NotFoundException("Color with id: " + request.Id + " is not found");

                color.IsActive = true;
                _colorRepository.Update(color);
                await _colorRepository.context.SaveChangesAsync(cancellationToken);

                return _mapper.Map<Color, ActivateColorResponse>(color);
            }
            catch (ApplicationException ex)
            {
                throw new ApplicationException("Error updating color", ex);
            }
        }
    }
}
