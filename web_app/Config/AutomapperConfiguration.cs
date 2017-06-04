using AutoMapper;
using web_app.Gateways.Responses;
using web_app.ViewModels;

namespace web_app.Config
{
    public class AutomapperConfiguration
    {
        public MapperConfiguration Configuration
        {
            get
            {
                MapperConfiguration configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<MovieDbSerchResponse, MovieDbSearchViewModel>()
                       .ForMember(dest => dest.movieResults, opt => opt.MapFrom(src => src));
                    //.ForMember(dest => dest.movieResults, opt => opt.MapFrom(src => src.results));
                    cfg.CreateMissingTypeMaps = true;
                });
                return configuration;
            }
        }
    }
}
