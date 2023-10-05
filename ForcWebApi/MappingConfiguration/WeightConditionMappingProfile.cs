using AutoMapper;
using Forc.WebApi.Dto;
using Forc.Infrastructure.Models;

namespace Forc.WebApi.MappingConfiguration
{
    public class WeightConditionMappingProfile : Profile
    {
        public WeightConditionMappingProfile()
        {
            CreateMap<WeightCondition, WeightConditionViewModel>()
                .ForMember(x => x.Id, i => i.MapFrom(u => u.Id))
                .ForMember(x => x.UserId, i => i.MapFrom(u => u.UserId))
                .ForMember(x => x.User, i => i.MapFrom(u => u.User))
                .ForMember(x => x.Date, i => i.MapFrom(u => u.Date))
                .ForMember(x => x.BodyWeight, i => i.MapFrom(u => u.BodyWeight))
                .ReverseMap();
        }
    }
}
