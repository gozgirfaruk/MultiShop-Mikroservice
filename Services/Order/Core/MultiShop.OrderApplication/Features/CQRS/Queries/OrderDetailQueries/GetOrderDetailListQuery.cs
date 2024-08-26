using MediatR;
using MultiShop.OrderApplication.Features.CQRS.Results.OrderDetailResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.OrderApplication.Features.CQRS.Queries.OrderDetailQueries
{
    public class GetOrderDetailListQuery : IRequest<List<GetOrderDetailQueryResult>>
    {
    }
}
