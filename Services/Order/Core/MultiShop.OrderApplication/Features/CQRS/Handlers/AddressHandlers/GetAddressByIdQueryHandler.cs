using AutoMapper;
using MediatR;
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
    public class GetAddressByIdQueryHandler : IRequestHandler<GetAddressByIdQuery, GetAddressByIdQueryResult>
    {

        private readonly IMapper _mapper;
        private readonly IRepository<Address> _repository;

        public GetAddressByIdQueryHandler(IMapper mapper, IRepository<Address> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetAddressByIdQueryResult>(values);
        }


    }


}
