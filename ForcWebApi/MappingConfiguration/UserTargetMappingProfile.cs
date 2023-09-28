using AutoMapper;
using Forc.WebApi.Dto;
using Forc.WebApi.Infrastructure.Entities;

namespace Forc.WebApi.MappingConfiguration
{
    public class UserTargetMappingProfile : Profile
    {
        public UserTargetMappingProfile()
        {
            CreateMap<UserTarget, UserTargetViewModel>()
                .ForMember(x => x.Id, i => i.MapFrom(u => u.Id))
                .ForMember(x => x.UserId, i => i.MapFrom(u => u.UserId))
                .ForMember(x => x.User, i => i.MapFrom(u => u.User))
                .ForMember(x => x.Relevance, i => i.MapFrom(u => u.Relevance))
                .ForMember(x => x.DateStart, i => i.MapFrom(u => u.DateStart))
                .ForMember(x => x.DateFinish, i => i.MapFrom(u => u.DateFinish))
                .ForMember(x => x.CurrentBodyWeight, i => i.MapFrom(u => u.CurrentBodyWeight))
                .ForMember(x => x.TargetBodyWeight, i => i.MapFrom(u => u.TargetBodyWeight))
                .ForMember(x => x.DailyRateId, i => i.MapFrom(u => u.DailyRateId))
                .ForMember(x => x.DailyRate, i => i.MapFrom(u => u.DailyRate))
                .ReverseMap();
        }
    }
}
