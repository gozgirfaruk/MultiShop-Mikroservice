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
    public class GetOrderingByIdQueryHandler : IRequestHandler<GetOrderingByIdQuery, GetOrderingByIdQueryResult>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Ordering> _repository;

        public GetOrderingByIdQueryHandler(IMapper mapper, IRepository<Ordering> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<GetOrderingByIdQueryResult> Handle(GetOrderingByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.OrderingID);
            return _mapper.Map<GetOrderingByIdQueryResult>(values);
        }


    }
}
