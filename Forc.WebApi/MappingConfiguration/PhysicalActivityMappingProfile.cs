using AutoMapper;
using Forc.WebApi.Dto;
using Forc.Infrastructure.Models;

namespace Forc.WebApi.MappingConfiguration
{
    public class PhysicalActivityMappingProfile : Profile
    {
        public PhysicalActivityMappingProfile()
        {
            CreateMap<PhysicalActivity, PhysicalActivityViewModel>()
                .ForMember(x => x.Id, i => i.MapFrom(u => u.Id))
                .ForMember(x => x.Name, i => i.MapFrom(u => u.Name))
                .ForMember(x => x.Description, i => i.MapFrom(u => u.Description))
                .ForMember(x => x.PhysicalActivityMultiplier, i => i.MapFrom(u => u.PhysicalActivityMultiplier))
                .ForMember(x => x.Users, i => i.MapFrom(u => u.Users))
                .ReverseMap();
        }
    }
}
