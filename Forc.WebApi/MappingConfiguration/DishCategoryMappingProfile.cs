using AutoMapper;
using Forc.WebApi.Dto;
using Forc.Infrastructure.Models;

namespace Forc.WebApi.MappingConfiguration
{
    public class DishCategoryMappingProfile : Profile
    {
        public DishCategoryMappingProfile()
        {
            CreateMap<DishCategory, DishCategoryViewModel>()
                .ForMember(x => x.Id, i => i.MapFrom(u => u.Id))
                .ForMember(x => x.Name, i => i.MapFrom(u => u.Name))
                .ForMember(x => x.Dishes, i => i.MapFrom(u => u.Dishes))
                .ReverseMap();
        }
    }
}
