using AutoMapper;
using MultiShop.OrderApplication.Features.CQRS.Commands.AddressCommands;
using MultiShop.OrderApplication.Features.CQRS.Queries.AddressQueries;
using MultiShop.OrderApplication.Features.CQRS.Results.AddressResults;
using MultiShop.OrderApplication.Features.Mediator.Commands.OrderingCommands;
using MultiShop.OrderApplication.Features.Mediator.Queries.OrderingQueries;
using MultiShop.OrderApplication.Features.Mediator.Results.OrderingResult;
using MultiShop.OrderDomain.Entities;

namespace MultiShop.OrderApplication.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Ordering,GetOrderingQueryResult>().ReverseMap();
            CreateMap<Ordering,GetOrderingByIdQueryResult>().ReverseMap();
            CreateMap<Ordering,CreateOrderingCommand>().ReverseMap();
            CreateMap<Ordering,UpdateOrderingCommand>().ReverseMap();
            CreateMap<Ordering,RemoveOrderingCommand>().ReverseMap();
            CreateMap<Ordering,GetOrderingByIdQuery>().ReverseMap();
            CreateMap<Ordering,GetOrderingListQuery>().ReverseMap();

            CreateMap<Ordering,GetOrderingByUserIdQuery>().ReverseMap();
            CreateMap<Ordering,GetOrderingByUserIdQueryResult>().ReverseMap();
                          
            CreateMap<Address,GetAddressQueryResult>().ReverseMap();
            CreateMap<Address,GetAddressListQuery>().ReverseMap();
            CreateMap<Address,CreateAddressCommand>().ReverseMap();
            CreateMap<Address,RemoveAddressCommand>().ReverseMap();
            CreateMap<Address,UpdateAddressCommand>().ReverseMap();
            CreateMap<Address,GetAddressByIdQuery>().ReverseMap();
            CreateMap<Address,GetAddressByIdQueryResult>().ReverseMap();

        }
    }
}
