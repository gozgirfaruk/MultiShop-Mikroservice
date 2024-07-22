using MultiShop.OrderApplication.Features.CQRS.Queries.AddressQueries;
using MultiShop.OrderApplication.Features.CQRS.Results.AddressResults;
using MultiShop.OrderApplication.Interfaces;
using MultiShop.OrderDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.OrderApplication.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressByIdQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressByIdQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.ID);
            return new GetAddressByIdQueryResult
            {
                AddressID = values.AddressID,
                City = values.City,
                Detail = values.Detail,
                Disctrict = values.Disctrict,
                UserID = values.UserID
            };
        }
    }
}
