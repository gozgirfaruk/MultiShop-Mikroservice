using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.CargoOperationDtos;
using MultiShop.Cargo.EntityLayer.Concrete;


namespace MultiShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _operationService;

        public CargoOperationsController(ICargoOperationService operationService)
        {
            _operationService = operationService;
        }
        [HttpGet]
        public IActionResult GetAllOperation()
        {
            var values = _operationService.TGetAllList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetOperationById(int id)
        {
            var value =_operationService.TGetById(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateOperation(CreateCargoOperationDto createOperation)
        {
            _operationService.TInsert(new CargoOperations
            {
                Barcode = createOperation.Barcode,
                Description = createOperation.Description,
                OperationDate = createOperation.OperationDate
            });
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateOperation(UpdateCargoOperationDto updateOperation)
        {
            _operationService.TUpdate(new CargoOperations
            {
                CargoOperationsID = updateOperation.CargoOperationsID,
                Barcode = updateOperation.Barcode,
                Description = updateOperation.Description,
                OperationDate = updateOperation.OperationDate
            });
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteOperation(int id)
        {
            _operationService.TDelete(id);
            return Ok();
        }
    }
}
