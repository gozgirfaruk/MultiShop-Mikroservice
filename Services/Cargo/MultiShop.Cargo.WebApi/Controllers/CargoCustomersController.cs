using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _customerService;

        public CargoCustomersController(ICargoCustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult GetAllCargoCustomer()
        {
            var values = _customerService.TGetAllList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoCustomerById(int id)
        {
            var value = _customerService.TGetById(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCustomer)
        {
            _customerService.TInsert(new CargoCustomer
            {
                Address = createCustomer.Address,
                City = createCustomer.City,
                District = createCustomer.District,
                Email = createCustomer.Email,
                Name = createCustomer.Name,
                Phone = createCustomer.Phone,
                Surname = createCustomer.Surname
            });
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCustomer)
        {
            _customerService.TUpdate(new CargoCustomer
            {
                Address = updateCustomer.Address,
                City = updateCustomer.City,
                District = updateCustomer.District,
                Email = updateCustomer.Email,
                Name = updateCustomer.Name,
                Phone = updateCustomer.Phone,
                Surname = updateCustomer.Surname,
                CargoCustomerID = updateCustomer.CargoCustomerID
            });
            return Ok("Müşteri güncelleme işlemi başarı ile gerçekleştirildi.");
        }
        [HttpDelete]
        public IActionResult DeleteCargoCustomer(int id)
        {
            _customerService.TDelete(id);
            return Ok();
        }
    }
}
