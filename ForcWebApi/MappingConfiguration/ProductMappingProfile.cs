using AutoMapper;
using Forc.WebApi.Dto;
using Forc.Infrastructure.Models;

namespace Forc.WebApi.MappingConfiguration
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductViewModel>()
                .ForMember(x => x.Id, i => i.MapFrom(u => u.Id))
                .ForMember(x => x.Name, i => i.MapFrom(u => u.Name))
                .ForMember(x => x.CompositionItems, i => i.MapFrom(u => u.CompositionItems))
                .ForMember(x => x.ProductGroupId, i => i.MapFrom(u => u.ProductGroupId))
                .ForMember(x => x.ProductGroup, i => i.MapFrom(u => u.ProductGroup))
                .ForMember(x => x.Calories, i => i.MapFrom(u => u.Calories))
                .ForMember(x => x.Carbohydrate, i => i.MapFrom(u => u.Carbohydrate))
                .ForMember(x => x.Fat, i => i.MapFrom(u => u.Fat))
                .ForMember(x => x.Protein, i => i.MapFrom(u => u.Protein))
                .ReverseMap();
        }
    }
}
