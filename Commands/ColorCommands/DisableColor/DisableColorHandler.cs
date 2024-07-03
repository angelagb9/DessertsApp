using AutoMapper;
using DessertsApp.Exceptions;
using DessertsApp.Models;
using DessertsApp.Repositories;
using MediatR;

namespace DessertsApp.Commands.ColorCommands.DisableColor
{
    public class DisableColorHandler : IRequestHandler<DisableColorCommand, DisableColorResponse>
    {
        private ColorRepository _colorRepository;
        private IMapper _mapper;

        public DisableColorHandler(ColorRepository colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }
        public async Task<DisableColorResponse> Handle(DisableColorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var color = await _colorRepository.dbSet.FindAsync(request.Id);

                if (color == null)
                    throw new NotFoundException("Color with id: " + request.Id + " is not found");

                color.IsActive = false;
                _colorRepository.Update(color);
                await _colorRepository.context.SaveChangesAsync(cancellationToken);

                return _mapper.Map<Color, DisableColorResponse>(color);
            }
            catch (ApplicationException ex)
            {
                throw new ApplicationException("Error updating color", ex);
            }
        }
    }
}
