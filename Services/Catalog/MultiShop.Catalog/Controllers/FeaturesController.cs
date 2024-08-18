using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShop.Catalog.Services.FeatureServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IFeatureService _featureService;

        public FeaturesController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        [HttpGet]
        public async Task<IActionResult> FeatureList()
        {
            var values = await _featureService.GetFeatureListAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeatureById(string id)
        {
            var valeus = await _featureService.GetFeaureByIdAsync(id);
            return Ok(valeus);
        }
        [HttpPost]
        public async Task<IActionResult> CreatedFeature(CreateFeatureDto dto)
        {
            await _featureService.CreateFeatureAsync(dto);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult>  UpdatedFeature(UpdateFeatureDto dto)
        {
            await _featureService.UpdateFeatureAsync(dto);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeletedFeature(string id)
        {
            await _featureService.DeleteFeatureAsync(id);
            return Ok();
        }
    }
}
