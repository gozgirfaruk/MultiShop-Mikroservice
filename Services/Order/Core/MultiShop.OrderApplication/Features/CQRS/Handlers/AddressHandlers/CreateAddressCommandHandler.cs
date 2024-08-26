using AutoMapper;
using MultiShop.OrderApplication.Features.CQRS.Commands.AddressCommands;
using MultiShop.OrderApplication.Interfaces;
using MultiShop.OrderDomain.Entities;

namespace MultiShop.OrderApplication.Features.CQRS.Handlers.AddressHandlers
{
    public class CreateAddressCommandHandler 
    {
        private readonly IRepository<Address> _repository;
        private readonly IMapper _mapper;
        public CreateAddressCommandHandler(IRepository<Address> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateAddressCommand createAddressCommand)
        {
            var values = _mapper.Map<Address>(createAddressCommand);
            await _repository.CreateAsync(values);
          
        }
    }
}
