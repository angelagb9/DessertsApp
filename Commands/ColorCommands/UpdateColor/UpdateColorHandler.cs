using AutoMapper;
using DessertsApp.Exceptions;
using DessertsApp.Commands.ColorCommands.CreateColor;
using DessertsApp.Repositories;
using MediatR;
using DessertsApp.Models;

namespace DessertsApp.Commands.ColorCommands.UpdateColor
{
    public class UpdateColorHandler : IRequestHandler<UpdateColorCommand, UpdateColorResponse>
    {
        private ColorRepository _colorRepository;
        private IMapper _mapper;

        public UpdateColorHandler(ColorRepository colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }
        public async Task<UpdateColorResponse> Handle(UpdateColorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var color = await _colorRepository.dbSet.FindAsync(request.Id);

                if (color == null)
                    throw new NotFoundException("Color with id: " + request.Id + " is not found");

                color.Name = request.Name;
                _colorRepository.Update(color);
                await _colorRepository.context.SaveChangesAsync(cancellationToken);

                return _mapper.Map<Color, UpdateColorResponse>(color);
            }
            catch (ApplicationException ex)
            {
                throw new ApplicationException("Error updating color", ex);
            }
        }
    }
}
