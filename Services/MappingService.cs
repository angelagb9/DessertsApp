﻿using AutoMapper;
using DessertsApp.Commands.ColorCommands.CreateColor;
using DessertsApp.Commands.ColorCommands.UpdateColor;
using DessertsApp.Models;
using DessertsApp.Queries.ColorQueries.GetColorById;

namespace DessertsApp.Services
{
    public class MappingService : Profile
    {
        public MappingService() 
        {
            //Color
            CreateMap<CreateColorCommand, Color>()
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true));
            CreateMap<Color, CreateColorResponse>();
            CreateMap<Color, GetColorByIdResponse>();
            CreateMap<Color, UpdateColorResponse>();
        
        }
    }
}
