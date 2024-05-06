using AutoMapper;
using RestaurantProject.DtoLayer.SliderDto;
using RestaurantProject.EntityLayer.Entities;

namespace RestaurantProjectApi.Mapping
{
	public class SliderMapping:Profile
	{
        public SliderMapping()
        {
			CreateMap<Slider, ResultSliderDto>().ReverseMap();
			//CreateMap<Slider, CreateSliderDto>().ReverseMap();
			//CreateMap<Slider, UpdateSliderDto>().ReverseMap();
		}
    }
}
