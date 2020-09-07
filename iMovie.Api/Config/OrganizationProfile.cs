using AutoMapper;
using iMovie.Domain;
using iMovie.Domain.Service.Omdb;

namespace iMovie.Api.Config
{
    public class OrganizationProfile : Profile
    {
        public OrganizationProfile()
        {
            CreateMap<OmdbModel, MovieData>().ForMember(dest => dest.Source, src => src.MapFrom<string>( value => "Omdb"));
            CreateMap<OmdbItemModel, MovieShortDetail>().ForMember(dest => dest.Source, src => src.MapFrom<string>(value => "Omdb"));
        }
    }
}
