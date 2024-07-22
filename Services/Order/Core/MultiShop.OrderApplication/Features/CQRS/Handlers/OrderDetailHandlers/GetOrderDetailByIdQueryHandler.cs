using MultiShop.OrderApplication.Features.CQRS.Queries.OrderDetailQueries;
using MultiShop.OrderApplication.Features.CQRS.Results.OrderDetailResults;
using MultiShop.OrderApplication.Interfaces;
using MultiShop.OrderDomain.Entities;

namespace MultiShop.OrderApplication.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderDetailByIdResult> Handle(GetOrderDetailByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.OrderDetailID);
            return new GetOrderDetailByIdResult
            {
                OrderDetailID = values.OrderDetailID,
                OrderingID = values.OrderingID,
                ProductAmount = values.ProductAmount,
                ProductID = values.ProductID,
                ProductName = values.ProductName,
                ProductPrice = values.ProductPrice,
                ProductTotalPrice = values.ProductTotalPrice,
            };
        }
    }
}
