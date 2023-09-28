using AutoMapper;
using Forc.WebApi.Dto;
using Forc.WebApi.Infrastructure.Entities;

namespace Forc.WebApi.MappingConfiguration
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserViewModel>()
                .ForMember(x => x.Id, i => i.MapFrom(u => u.Id))
                .ForMember(x => x.Name, i => i.MapFrom(u => u.Name))
                .ForMember(x => x.BirthDate, i => i.MapFrom(u => u.BirthDate))
                .ForMember(x => x.Gender, i => i.MapFrom(u => u.Gender))
                .ForMember(x => x.Sex, i => i.MapFrom(u => u.Sex))
                .ForMember(x => x.PhysicalActivityId, i => i.MapFrom(u => u.PhysicalActivityId))
                .ForMember(x => x.PhysicalActivity, i => i.MapFrom(u => u.PhysicalActivity))
                .ForMember(x => x.WeightConditions, i => i.MapFrom(u => u.WeightConditions))
                .ForMember(x => x.Targets, i => i.MapFrom(u => u.Targets))
                .ForMember(x => x.Meals, i => i.MapFrom(u => u.Meals))
                .ForMember(x => x.UserDishCollectionId, i => i.MapFrom(u => u.UserDishCollectionId))
                .ForMember(x => x.UserDishCollection, i => i.MapFrom(u => u.UserDishCollection))
                .ForMember(x => x.Height, i => i.MapFrom(u => u.Height))
                .ReverseMap();
        }
    }
}
