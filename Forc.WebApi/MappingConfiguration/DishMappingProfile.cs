﻿using AutoMapper;
using Forc.WebApi.Dto;
using Forc.Infrastructure.Models;

namespace Forc.WebApi.MappingConfiguration
{
    public class DishMappingProfile : Profile
    {
        public DishMappingProfile()
        {
            CreateMap<Dish, DishViewModel>()
                .ForMember(x => x.Id, i => i.MapFrom(u => u.Id))
                .ForMember(x => x.Name, i => i.MapFrom(u => u.Name))
                .ForMember(x => x.ResourceSpecificationId, i => i.MapFrom(u => u.ResourceSpecificationId))
                .ForMember(x => x.ResourseSpecification, i => i.MapFrom(u => u.ResourseSpecification))
                .ForMember(x => x.UserDishCollections, i => i.MapFrom(u => u.UserDishCollections))
                .ForMember(x => x.Categoties, i => i.MapFrom(u => u.Categoties))
                .ForMember(x => x.MealItems, i => i.MapFrom(u => u.MealItems))
                .ReverseMap();
        }
    }
}
