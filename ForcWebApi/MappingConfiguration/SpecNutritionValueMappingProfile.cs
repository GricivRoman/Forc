using AutoMapper;
using Forc.WebApi.Dto;
using Forc.Infrastructure.Models;

namespace Forc.WebApi.MappingConfiguration
{
    public class SpecNutritionValueMappingProfile : Profile
    {
        public SpecNutritionValueMappingProfile()
        {
            CreateMap<SpecNutritionValue, SpecNutritionValueViewModel>()
                .ForMember(x => x.Id, i => i.MapFrom(u => u.Id))
                .ForMember(x => x.ResourceSpecificationId, i => i.MapFrom(u => u.ResourceSpecificationId))
                .ForMember(x => x.ResourceSpecification, i => i.MapFrom(u => u.ResourceSpecification))
                .ForMember(x => x.Calories, i => i.MapFrom(u => u.Calories))
                .ForMember(x => x.Carbohydrate, i => i.MapFrom(u => u.Carbohydrate))
                .ForMember(x => x.Fat, i => i.MapFrom(u => u.Fat))
                .ForMember(x => x.Protein, i => i.MapFrom(u => u.Protein))
                .ReverseMap();
        }
    }
}
