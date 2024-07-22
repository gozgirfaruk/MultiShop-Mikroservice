using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.OrderApplication.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.OrderApplication.Features.CQRS.Handlers.OrderDetailHandlers;
using MultiShop.OrderApplication.Features.CQRS.Queries.OrderDetailQueries;

namespace MultiShop.OrderWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly GetOrderDetailByIdQueryHandler _getOrderDetailByIdQueryHandler;
        private readonly GetOrderDetailQueryHandler _getOrderDetailQueryHandler;
        private readonly CreateOrderDetailCommandHandler _createOrderDetailCommandHandler;
        private readonly UpdateOrderDetailQueryHandler _updateOrderDetailCommandHandler;
        private readonly RemoveOrderDetailQueryHandler _removeOrderDetailCommandHandler;

        public OrderDetailsController(GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryHandler, GetOrderDetailQueryHandler getOrderDetailQueryHandler, CreateOrderDetailCommandHandler createOrderDetailCommandHandler, UpdateOrderDetailQueryHandler updateOrderDetailCommandHandler, RemoveOrderDetailQueryHandler removeOrderDetailCommandHandler)
        {
            _getOrderDetailByIdQueryHandler = getOrderDetailByIdQueryHandler;
            _getOrderDetailQueryHandler = getOrderDetailQueryHandler;
            _createOrderDetailCommandHandler = createOrderDetailCommandHandler;
            _updateOrderDetailCommandHandler = updateOrderDetailCommandHandler;
            _removeOrderDetailCommandHandler = removeOrderDetailCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderDetailList()
        {
            var values = await _getOrderDetailQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetailById(int id)
        {
            var values = await _getOrderDetailByIdQueryHandler.Handle(new GetOrderDetailByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand command)
        {
            await _createOrderDetailCommandHandler.Handle(command);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand command)
        {
            await _updateOrderDetailCommandHandler.Handle(command);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            await _removeOrderDetailCommandHandler.Handle(new RemoveOrderDetailCommand(id));
            return Ok();
        }

    }
}
