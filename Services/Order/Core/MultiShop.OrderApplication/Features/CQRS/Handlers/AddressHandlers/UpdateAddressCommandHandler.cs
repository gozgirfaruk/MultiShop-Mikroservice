using AutoMapper;
using MultiShop.OrderApplication.Features.CQRS.Commands.AddressCommands;
using MultiShop.OrderApplication.Interfaces;
using MultiShop.OrderDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.OrderApplication.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;
        private readonly IMapper _mapper;
        public UpdateAddressCommandHandler(IRepository<Address> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateAddressCommand command)
        {
            var values = _mapper.Map<Address>(command);
           await _repository.UpdateAsync(values);
        }
    }
}
