using AutoMapper;
using TestTechniqueC_.DTOs;
using TestTechniqueC_.Models;

namespace TestTechniqueC_
{
    public static class MapperConfig
    {
        public static Mapper Initialize()
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<Project, ProjectDTO>()
                .ForMember(dest => dest.WorkingHours, act => act.MapFrom(src => src.Horaires))
                .ForMember(dest => dest.WorkAt, act => act.MapFrom(src => src.Travail))
                .ForMember(dest => dest.TemperatureMorning, act => act.MapFrom(src => src.Temp1))
                .ForMember(dest => dest.TemperatureAfterNoon, act => act.MapFrom(src => src.Temp2))
                .ForMember(dest => dest.Weather, act => act.MapFrom(src => src.Meteo)));
            var mapper = new Mapper(config);

            return mapper;
        }
    }
}
