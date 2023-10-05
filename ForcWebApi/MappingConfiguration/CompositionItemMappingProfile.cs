using AutoMapper;
using Forc.WebApi.Dto;
using Forc.Infrastructure.Models;

namespace Forc.WebApi.MappingConfiguration
{
    public class CompositionItemMappingProfile : Profile
    {
        public CompositionItemMappingProfile()
        {
            CreateMap<CompositionItem, CompositionItemViewModel>()
                .ForMember(x => x.Id, i => i.MapFrom(u => u.Id))
                .ForMember(x => x.ResourceSpecificationId, i => i.MapFrom(u => u.ResourceSpecificationId))
                .ForMember(x => x.ResourceSpecification, i => i.MapFrom(u => u.ResourceSpecification))
                .ForMember(x => x.ProductId, i => i.MapFrom(u => u.ProductId))
                .ForMember(x => x.Product, i => i.MapFrom(u => u.Product))
                .ForMember(x => x.ProductWeightG, i => i.MapFrom(u => u.ProductWeightG))
                .ReverseMap();
        }
    }
}
