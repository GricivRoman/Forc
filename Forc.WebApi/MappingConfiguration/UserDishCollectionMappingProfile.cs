using AutoMapper;
using Forc.WebApi.Dto;
using Forc.Infrastructure.Models;

namespace Forc.WebApi.MappingConfiguration
{
    public class UserDishCollectionMappingProfile : Profile
    {
        public UserDishCollectionMappingProfile()
        {
            CreateMap<UserDishCollection, UserDishCollectionViewModel>()
                .ForMember(x => x.Id, i => i.MapFrom(u => u.Id))
                .ForMember(x => x.UserId, i => i.MapFrom(u => u.UserId))
                .ForMember(x => x.User, i => i.MapFrom(u => u.User))
                .ForMember(x => x.Dishes, i => i.MapFrom(u => u.Dishes))
                .ReverseMap();
        }
    }
}
