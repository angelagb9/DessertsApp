using AutoMapper;
using DessertsApp.Commands.ColorCommands.CreateColor;
using DessertsApp.Models;

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
        
        }
    }
}
