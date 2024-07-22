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
    public class CreateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateOrderDetailCommand command)
        {
            await _repository.CreateAsync(new OrderDetail
            {
                OrderingID = command.OrderingID,
                ProductAmount = command.ProductAmount,
                ProductName = command.ProductName,
                ProductTotalPrice = command.ProductTotalPrice,
                ProductPrice = command.ProductPrice,
                ProductID = command.ProductID,
            });
        }
    }
}
