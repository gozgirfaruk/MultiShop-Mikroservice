using AutoMapper;
using MediatR;
using MultiShop.OrderApplication.Features.Mediator.Commands.OrderingCommands;
using MultiShop.OrderApplication.Interfaces;
using MultiShop.OrderDomain.Entities;

namespace MultiShop.OrderApplication.Features.Mediator.Handlers.OrderingHandlers
{
    public class CreateOrderingCommandHandler : IRequestHandler<CreateOrderingCommand>
    {
        private readonly IRepository<Ordering> _repository;
        private readonly IMapper _mapper;

        public CreateOrderingCommandHandler(IRepository<Ordering> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateOrderingCommand request, CancellationToken cancellationToken)
        {
            var values = _mapper.Map<Ordering>(request);
            await _repository.CreateAsync(values);
        }
    }
}
