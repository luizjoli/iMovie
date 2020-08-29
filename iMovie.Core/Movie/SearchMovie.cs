using iMovie.Core.Movie.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using iMovie.Domain;
using Microsoft.Extensions.Configuration;
using iMovie.Facade.Omdb.Interface;
using iMovie.Facade.Omdb.Domain;

namespace iMovie.Core.Movie {
    public class SearcMovie : ISearchMovie {

        private readonly IConfiguration _config;
        private readonly IOmdbApi _omdbApi;

        public SearcMovie(IConfiguration config, IOmdbApi omdbApi){
            _config = config;             
            _omdbApi = omdbApi;
        }

        public async Task<MovieData> GetMovie(string name, string id){
            
            var parameter = new ParameterIdTitle(id, name);
            var data = _omdbApi.GetByIdOrTitleAsync(parameter);

            //Mapper.CreateMap<OmdbModel,MovieData>();

            //var movieData = Mapper.Map<>

            return new MovieData();
        }

        public async Task<List<MovieData>> GetMovies(string search){
            return new List<MovieData>();
        }
    }
}