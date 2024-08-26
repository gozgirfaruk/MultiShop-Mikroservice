
using AutoMapper;
using MediatR;
using MultiShop.OrderApplication.Features.CQRS.Queries.AddressQueries;
using MultiShop.OrderApplication.Features.CQRS.Results.AddressResults;
using MultiShop.OrderApplication.Interfaces;
using MultiShop.OrderDomain.Entities;

namespace MultiShop.OrderApplication.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressQueryHandler : IRequestHandler<GetAddressListQuery,List<GetAddressQueryResult>>
    {
        private readonly IRepository<Address> _repository;
        private readonly IMapper _mapper;

        public GetAddressQueryHandler(IRepository<Address> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetAddressQueryResult>> Handle(GetAddressListQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return _mapper.Map<List<GetAddressQueryResult>>(values);
        }
    }
}
