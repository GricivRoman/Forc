using AutoMapper;
using Forc.WebApi.Dto;
using Forc.Infrastructure.Models.Base;

namespace Forc.WebApi.MappingConfiguration
{
    public class BaseMappingConfiguration : Profile
    {
        public BaseMappingConfiguration()
        {
            CreateMap<EntityWithName<Guid>, SelectItem<Guid>>()
                .ForMember(x => x.Id, i => i.MapFrom(u => u.Id))
                .ForMember(x => x.Value, i => i.MapFrom(u => u.Name));

            CreateMap<EntityWithName<int>, SelectItem<int>>()
                .ForMember(x => x.Id, i => i.MapFrom(u => u.Id))
                .ForMember(x => x.Value, i => i.MapFrom(u => u.Name));
        }
    }
}
