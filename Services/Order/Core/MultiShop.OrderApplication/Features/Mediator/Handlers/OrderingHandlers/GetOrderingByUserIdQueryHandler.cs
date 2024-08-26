using AutoMapper;
using MediatR;
using MultiShop.OrderApplication.Features.Mediator.Queries.OrderingQueries;
using MultiShop.OrderApplication.Features.Mediator.Results.OrderingResult;
using MultiShop.OrderApplication.Interfaces;
using MultiShop.OrderDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.OrderApplication.Features.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingByUserIdQueryHandler : IRequestHandler<GetOrderingByUserIdQuery, List<GetOrderingByUserIdQueryResult>>
    {
        private readonly IRepository<Ordering> _repository;
        private readonly IMapper _mapper;
        private readonly IOrderingRepository _orderingRepository;
        public GetOrderingByUserIdQueryHandler(IRepository<Ordering> repository, IMapper mapper, IOrderingRepository orderingRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _orderingRepository = orderingRepository;
        }

        public async Task<List<GetOrderingByUserIdQueryResult>> Handle(GetOrderingByUserIdQuery request, CancellationToken cancellationToken)
        {
            var values =  _orderingRepository.GetOrderingsByUserId(request.Id);
            return _mapper.Map<List<GetOrderingByUserIdQueryResult>>(values);

        }
    }
}
