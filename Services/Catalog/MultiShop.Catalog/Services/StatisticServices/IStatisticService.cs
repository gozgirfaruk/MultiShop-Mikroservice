﻿namespace MultiShop.Catalog.Services.StatisticServices
{
    public interface IStatisticService
    {
        Task<long> GetCategoryCount();
        Task<long> GetProductCount();
        Task<long> GetBrandCount();
       Task<decimal> GetProductAvgPrice();
        Task<string> GetProductMaxPrice();
        Task<string> GetProductMinPrice();
    }
}
