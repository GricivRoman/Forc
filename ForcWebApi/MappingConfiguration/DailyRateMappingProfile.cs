using AutoMapper;
using Forc.WebApi.Dto;
using Forc.Infrastructure.Models;

namespace Forc.WebApi.MappingConfiguration
{
    public class DailyRateMappingProfile : Profile
    {
        public DailyRateMappingProfile()
        {
            CreateMap<DailyRate, DailyRateViewModel>()
                .ForMember(x => x.Id, i => i.MapFrom(u => u.Id))
                .ForMember(x => x.UserTargetId, i => i.MapFrom(u => u.UserTargetId))
                .ForMember(x => x.UserTarget, i => i.MapFrom(u => u.UserTarget))
                .ForMember(x => x.CaloriesRate, i => i.MapFrom(u => u.CaloriesRate))
                .ForMember(x => x.CarbohydrateRate, i => i.MapFrom(u => u.CarbohydrateRate))
                .ForMember(x => x.FatRate, i => i.MapFrom(u => u.FatRate))
                .ForMember(x => x.ProteinRate, i => i.MapFrom(u => u.ProteinRate))
                .ReverseMap();
        }
    }
}
