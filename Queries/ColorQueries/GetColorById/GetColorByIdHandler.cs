using AutoMapper;
using DessertsApp.Exceptions;
using DessertsApp.Models;
using DessertsApp.Repositories;
using MediatR;

namespace DessertsApp.Queries.ColorQueries.GetColorById
{
    public class GetColorByIdHandler : IRequestHandler<GetColorByIdQuery,GetColorByIdResponse>
    {
        private ColorRepository _colorRepository;
        private IMapper _mapper;
        public GetColorByIdHandler(ColorRepository colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }

        public async Task<GetColorByIdResponse> Handle(GetColorByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var color = await _colorRepository.dbSet.FindAsync(request.Id, cancellationToken);

                if (color == null)
                {
                    throw new NotFoundException("Color with id: " + request.Id +" is not found");
                }

                return _mapper.Map<Color, GetColorByIdResponse>(color);

            }
            catch (ApplicationException ex)
            {
                throw new ApplicationException("Error getting color", ex);
            }
        }
    }
}
