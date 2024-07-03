using AutoMapper;
using DessertsApp.Models;
using DessertsApp.Repositories;
using MediatR;

namespace DessertsApp.Commands.ColorCommands.CreateColor
{
    public class CreateColorHandler : IRequestHandler<CreateColorCommand, CreateColorResponse>
    {
        private ColorRepository _colorRepository;
        private IMapper _mapper;

        public CreateColorHandler(ColorRepository colorRepository, IMapper mapper) 
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }
        public async Task<CreateColorResponse> Handle(CreateColorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var newColor = _mapper.Map<CreateColorCommand, Color>(request);

                _colorRepository.Insert(newColor);
                await _colorRepository.context.SaveChangesAsync(cancellationToken);

                return _mapper.Map<Color, CreateColorResponse>(newColor);
            }
            catch (Exception ex) 
            {
                throw new ApplicationException("Error creating color", ex);
            }
        }
    }
}
