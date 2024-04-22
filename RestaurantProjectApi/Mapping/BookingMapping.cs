using AutoMapper;
using RestaurantProject.DtoLayer.BookingDto;
using RestaurantProject.EntityLayer.Entities;

namespace RestaurantProjectApi.Mapping
{
    public class BookingMapping:Profile
    {
        public BookingMapping()
        {
            CreateMap<Booking ,ResultBookingDto>().ReverseMap();
            CreateMap<Booking ,CreateBookingDto>().ReverseMap();
            CreateMap<Booking ,GetBookingDto>().ReverseMap();
            CreateMap<Booking ,UpdateBookingDto>().ReverseMap();
        }
    }
}
