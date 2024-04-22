using AutoMapper;
using RestaurantProject.DtoLayer.CategoryDto;
using RestaurantProject.EntityLayer.Entities;

namespace RestaurantProjectApi.Mapping
{
    public class CategoryMapping:Profile
    {
        public CategoryMapping()
        {
                CreateMap<Category , ResultCategoryDto>().ReverseMap();
                CreateMap<Category , CreateCategoryDto>().ReverseMap();
                CreateMap<Category , GetCategoryDto>().ReverseMap();
                CreateMap<Category , UpdateCategoryDto>().ReverseMap();
        }
    }
}
