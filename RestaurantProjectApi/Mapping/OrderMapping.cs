using AutoMapper;
using RestaurantProject.DtoLayer.OrderDto;
using RestaurantProject.EntityLayer.Entities;

namespace RestaurantProjectApi.Mapping
{
    public class OrderMapping : Profile
    {
        public OrderMapping()
        {
            CreateMap<Order, ResultOrderDto>().ReverseMap();
        }
    }
}
