﻿using AutoMapper;
using Forc.WebApi.Dto;
using Forc.WebApi.Infrastructure.Models;

namespace Forc.WebApi.MappingConfiguration
{
    public class ProductGroupMappingProfile : Profile
    {
        public ProductGroupMappingProfile()
        {
            CreateMap<ProductGroup, ProductGroupViewModel>()
                .ForMember(x => x.Id, i => i.MapFrom(u => u.Id))
                .ForMember(x => x.GroupName, i => i.MapFrom(u => u.GroupName))
                .ForMember(x => x.Products, i => i.MapFrom(u => u.Products))
                .ReverseMap();
        }
    }
}