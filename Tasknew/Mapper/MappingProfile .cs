using AutoMapper;
using Tasknew.Models;

namespace Tasknew.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Define your mappings here
            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();
            CreateMap<OrderItemDto, OrderItem>();
            CreateMap<OrderItem, OrderItemDto>();
        }
    }
}
