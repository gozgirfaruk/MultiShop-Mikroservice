using MultiShop.OrderApplication.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.OrderApplication.Interfaces;
using MultiShop.OrderDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.OrderApplication.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderDetailCommand command)
        {
            var values = await _repository.GetByIdAsync(command.OrderDetailID);
            values.OrderingID = command.OrderDetailID;
            values.ProductID = command.ProductID;
            values.ProductName = command.ProductName;
            values.ProductPrice = command.ProductPrice;
            values.ProductAmount = command.ProductAmount;
            values.ProductTotalPrice = command.ProductTotalPrice;
            await _repository.UpdateAsync(values);

        }
    }
}
