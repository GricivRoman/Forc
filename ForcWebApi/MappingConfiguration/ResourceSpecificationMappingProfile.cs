using AutoMapper;
using Forc.WebApi.Dto;
using Forc.WebApi.Infrastructure.Entities;

namespace Forc.WebApi.MappingConfiguration
{
    public class ResourceSpecificationMappingProfile : Profile
    {
        public ResourceSpecificationMappingProfile()
        {
            CreateMap<ResourceSpecification, ResourceSpecificationViewModel>()
                .ForMember(x => x.Id, i => i.MapFrom(u => u.Id))
                .ForMember(x => x.DishId, i => i.MapFrom(u => u.DishId))
                .ForMember(x => x.Dish, i => i.MapFrom(u => u.Dish))
                .ForMember(x => x.Composition, i => i.MapFrom(u => u.Composition))
                .ForMember(x => x.OutputDishWeightG, i => i.MapFrom(u => u.OutputDishWeightG))
                .ForMember(x => x.SpecNutritionValueId, i => i.MapFrom(u => u.SpecNutritionValueId))
                .ForMember(x => x.SpecNutritionValue, i => i.MapFrom(u => u.SpecNutritionValue))
                .ReverseMap();
        }
    }
}
