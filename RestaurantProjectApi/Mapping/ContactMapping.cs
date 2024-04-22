using AutoMapper;
using RestaurantProject.DtoLayer.ContactDto;
using RestaurantProject.EntityLayer.Entities;

namespace RestaurantProjectApi.Mapping
{
    public class ContactMapping:Profile
    {
        public ContactMapping()
        {
            CreateMap<Contact , ResultContactDto>().ReverseMap();
            CreateMap<Contact , CreateContactDto>().ReverseMap();
            CreateMap<Contact , GetContactDto>().ReverseMap();
            CreateMap<Contact , UpdateContactDto>().ReverseMap();
        }
    }
}
