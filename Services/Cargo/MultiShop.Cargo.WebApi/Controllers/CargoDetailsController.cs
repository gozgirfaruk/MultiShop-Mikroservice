using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.CargoDetailDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _detailService;

        public CargoDetailsController(ICargoDetailService detailService)
        {
            _detailService = detailService;
        }

        [HttpGet]
        public IActionResult GetAllCargoDetail()
        {
            var values = _detailService.TGetAllList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoDetailById(int id)
        {
            var value = _detailService.TGetById(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto createDetail)
        {
            _detailService.TInsert(new CargoDetail
            {
                ReceiverCustomer = createDetail.ReceiverCustomer,
                SenderCustomer = createDetail.SenderCustomer,
                Barcode = createDetail.Barcode,
                CargoCompanyID = createDetail.CargoCompanyID

            });
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto updateDetail)
        {
            _detailService.TUpdate(new CargoDetail
            {
              CargoDetailID = updateDetail.CargoDetailID,
              ReceiverCustomer = updateDetail.ReceiverCustomer, 
              SenderCustomer= updateDetail.SenderCustomer,
              Barcode = updateDetail.Barcode,
              CargoCompanyID= updateDetail.CargoCompanyID
            });
            return Ok("Detay güncelleme işlemi başarı ile gerçekleştirildi.");
        }
        [HttpDelete]
        public IActionResult DeleteCargoDetail(int id)
        {
            _detailService.TDelete(id);
            return Ok();
        }
    }
}

