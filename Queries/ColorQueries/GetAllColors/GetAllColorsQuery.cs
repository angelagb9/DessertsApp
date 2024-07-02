using MediatR;

namespace DessertsApp.Queries.ColorQueries.GetAllColors
{
    public class GetAllColorsQuery : IRequest<List<GetAllColorsResponse>>
    {
    }
}
