using iMovie.Core.Movie.Interface;
using System.Threading.Tasks;
using iMovie.Domain;
using iMovie.Facade.Omdb.Interface;
using iMovie.Domain.Service.Omdb;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace iMovie.Core.Movie
{
    public class SearchMovie : ISearchMovie
    {

        private readonly IMapper _mapper;
        private readonly IOmdbApi _omdbApi;

        public SearchMovie(IMapper mapper, IOmdbApi omdbApi)
        {

            _mapper = mapper;
            _omdbApi = omdbApi;
        }

        public async Task<MovieData> GetMovie(string name, string id)
        {
            var parameter = new ParameterIdTitle(id, name);
            var data = await _omdbApi.GetByIdOrTitleAsync(parameter);

            if (data != null)
            {
                var movieData = _mapper.Map<MovieData>(data);                
                return movieData;
            }
            else {
                throw new Exception("Não encontrado nenhum título");
            }
            

            
        }

        public async Task<IEnumerable<MovieShortDetail>> GetMovieByTerm(string term)
        {
            var parameter = new ParameterSearch(term);
            var data = await _omdbApi.GetBySearchAsync(parameter);

            if (data != null)
            {
                var movieData = _mapper.Map<IEnumerable<MovieShortDetail>>(data.Search);                
                return movieData;
            }
            else
            {
                throw new Exception("Não encontrado nenhum título");
            }
        }
    }
}