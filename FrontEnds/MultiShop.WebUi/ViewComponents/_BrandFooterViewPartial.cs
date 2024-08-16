﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUi.ViewComponents
{
    public class _BrandFooterViewPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BrandFooterViewPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:7186/api/Brands");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();   
                var jsonObject = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
                return View(jsonObject);
            }
            return View();
        }
    }
}
