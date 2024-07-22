using MultiShop.OrderApplication.Features.CQRS.Results.AddressResults;
using MultiShop.OrderApplication.Interfaces;
using MultiShop.OrderDomain.Entities;

namespace MultiShop.OrderApplication.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }


        public async Task<List<GetAddressQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=>new GetAddressQueryResult
            {
                AddressID = x.AddressID,
                City = x.City,
                Detail=x.Detail,
                Disctrict=x.Disctrict,
                UserID=x.UserID
            }).ToList();
        }
    }
}
