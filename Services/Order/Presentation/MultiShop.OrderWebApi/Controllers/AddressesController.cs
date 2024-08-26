using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.OrderApplication.Features.CQRS.Commands.AddressCommands;
using MultiShop.OrderApplication.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.OrderApplication.Features.CQRS.Queries.AddressQueries;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MultiShop.OrderWebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
     
      private readonly IMediator _mediator;

        public AddressesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAddressList()
        {
            var values = await _mediator.Send(new GetAddressListQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressById(int id)
        {
            var values = await _mediator.Send(new GetAddressByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            await _mediator.Send(new RemoveAddressCommand(id));
      
            return Ok();
        }

    }
}
