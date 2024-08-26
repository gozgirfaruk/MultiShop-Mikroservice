using MediatR;
using MultiShop.OrderApplication.Features.CQRS.Results.AddressResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.OrderApplication.Features.CQRS.Queries.AddressQueries
{
    public class GetAddressByIdQuery : IRequest<GetAddressByIdQueryResult>
    {
        public int Id{ get; set; }

        public GetAddressByIdQuery(int id)
        {
            Id = id;
        }
    }
}
