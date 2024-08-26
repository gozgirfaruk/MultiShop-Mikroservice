using MediatR;
using MultiShop.OrderApplication.Features.Mediator.Results.OrderingResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.OrderApplication.Features.Mediator.Queries.OrderingQueries
{
    public class GetOrderingByUserIdQuery : IRequest<List<GetOrderingByUserIdQueryResult>>
    {
        public string Id { get; set; }

        public GetOrderingByUserIdQuery(string id)
        {
            Id = id;
        }
    }
}
