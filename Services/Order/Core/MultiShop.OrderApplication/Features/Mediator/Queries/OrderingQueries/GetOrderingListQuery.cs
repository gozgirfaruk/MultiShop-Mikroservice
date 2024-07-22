using MediatR;
using MultiShop.OrderApplication.Features.Mediator.Results.OrderingResult;

namespace MultiShop.OrderApplication.Features.Mediator.Queries.OrderingQueries
{
    public class GetOrderingListQuery : IRequest<List<GetOrderingQueryResult>>
    {
    }
}
