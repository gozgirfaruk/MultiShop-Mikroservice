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

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAddressCommand command)
        {
            var value = await _repository.GetByIdAsync(command.AddressID);
            value.Detail = command.Detail;
            value.Disctrict = command.Disctrict;
            value.City = command.City;
            value.UserID = command.UserID;
            await _repository.UpdateAsync(value);
        }
    }
}
