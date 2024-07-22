using AutoMapper;
using MediatR;
using MultiShop.OrderApplication.Features.Mediator.Commands.OrderingCommands;
using MultiShop.OrderApplication.Interfaces;
using MultiShop.OrderDomain.Entities;

namespace MultiShop.OrderApplication.Features.Mediator.Handlers.OrderingHandlers
{
    public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommand>
    {
        private readonly IRepository<Ordering> _repository;
        private readonly IMapper _mapper;

        public UpdateOrderingCommandHandler(IRepository<Ordering> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
        {
           var valeus = _mapper.Map<Ordering>(request);
            await _repository.UpdateAsync(valeus);
        }
    }
}
