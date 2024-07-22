using AutoMapper;
using MediatR;
using MultiShop.OrderApplication.Features.Mediator.Queries.OrderingQueries;
using MultiShop.OrderApplication.Features.Mediator.Results.OrderingResult;
using MultiShop.OrderApplication.Interfaces;
using MultiShop.OrderDomain.Entities;

namespace MultiShop.OrderApplication.Features.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingQueryHandler : IRequestHandler<GetOrderingListQuery, List<GetOrderingQueryResult>>
    {
        private readonly IRepository<Ordering> _repository;
        private readonly IMapper _mapper;

        public GetOrderingQueryHandler(IRepository<Ordering> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetOrderingQueryResult>> Handle(GetOrderingListQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return _mapper.Map<List<GetOrderingQueryResult>>(values);
        }
    }
}
