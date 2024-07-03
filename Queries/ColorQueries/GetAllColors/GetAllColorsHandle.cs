using AutoMapper;
using DessertsApp.Models;
using DessertsApp.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DessertsApp.Queries.ColorQueries.GetAllColors
{
    public class GetAllColorsHandle : IRequestHandler<GetAllColorsQuery, List<GetAllColorsResponse>>
    {
        private ColorRepository _colorRepository;
        private IMapper _mapper;

        public GetAllColorsHandle(ColorRepository colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllColorsResponse>> Handle(GetAllColorsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var colors = await _colorRepository.dbSet.ToListAsync(); ;

                return colors.Select(_mapper.Map<Color, GetAllColorsResponse>).ToList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error getting colors", ex);
            }
        }
    }
}
