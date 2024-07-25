using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.CargoCompanyDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompaniesController : ControllerBase
    {
        private readonly ICargoCompanyService _companyService;

        public CargoCompaniesController(ICargoCompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]   
        public IActionResult GetCargoCompanyList()
        {
            var values = _companyService.TGetAllList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoCompanyById(int id)
        {
            var value =_companyService.TGetById(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateCargoCompany(CreateCargoCompanyDto createCompany)
        {
            _companyService.TInsert(new CargoCompany
            {
                CompanyName = createCompany.CompanyName
            });
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateCargoCompany(UpdateCargoCompanyDto updateCompany)
        {
            _companyService.TUpdate(new CargoCompany
            {
                CargoCompanyID = updateCompany.CargoCompanyID,
                CompanyName = updateCompany.CompanyName
            });
            return Ok();
        }
    }
}
