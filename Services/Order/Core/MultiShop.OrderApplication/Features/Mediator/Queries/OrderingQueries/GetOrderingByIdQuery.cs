using MediatR;
using MultiShop.OrderApplication.Features.Mediator.Results.OrderingResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.OrderApplication.Features.Mediator.Queries.OrderingQueries
{
    public class GetOrderingByIdQuery : IRequest<GetOrderingByIdQueryResult>
    {
        public int OrderingID { get; set; }

        public GetOrderingByIdQuery(int orderingID)
        {
            OrderingID = orderingID;
        }
    }
}
