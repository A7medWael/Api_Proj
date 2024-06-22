using AutoMapper;
using FirstProj.Models;

namespace FirstProj.Helper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MovieDetails>();
            CreateMap<MovieDetails, Movie>().ForMember(src => src.Poster, opt => opt.Ignore());
        }
    }
}
