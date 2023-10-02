using AutoMapper;
using Forc.WebApi.Dto;
using Forc.WebApi.Infrastructure.Entities;

namespace Forc.WebApi.MappingConfiguration
{
    public class MealMappingProfile : Profile
    {
        public MealMappingProfile()
        {
            CreateMap<Meal, MealViewModel>()
                .ForMember(x => x.Id, i => i.MapFrom(u => u.Id))
                .ForMember(x => x.UserId, i => i.MapFrom(u => u.UserId))
                .ForMember(x => x.User, i => i.MapFrom(u => u.User))
                .ForMember(x => x.MealTime, i => i.MapFrom(u => u.MealTime))
                .ForMember(x => x.MealItems, i => i.MapFrom(u => u.MealItems))
                .ReverseMap();
        }
    }
}
