using MediatR;

namespace DessertsApp.Queries.ColorQueries.GetColorById
{
    public class GetColorByIdQuery : IRequest<GetColorByIdResponse>
    {
        public int Id { get; set; }
    }
}
