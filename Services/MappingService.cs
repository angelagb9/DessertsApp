using AutoMapper;
using DessertsApp.Commands.ColorCommands.ActivateColor;
using DessertsApp.Commands.ColorCommands.CreateColor;
using DessertsApp.Commands.ColorCommands.UpdateColor;
using DessertsApp.Commands.ColorCommands.DisableColor;
using DessertsApp.Models;
using DessertsApp.Queries.ColorQueries.GetColorById;
using DessertsApp.Queries.ColorQueries.GetAllColors;

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
            CreateMap<Color, ActivateColorResponse>();
            CreateMap<Color, DisableColorResponse>();
            CreateMap<Color, GetAllColorsResponse>();

        }
    }
}
