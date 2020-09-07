using System.Collections.Generic;
using System.Threading.Tasks;
using iMovie.Domain;

namespace iMovie.Core.Movie.Interface
{
    public interface ISearchMovie
    {
        public Task<MovieData> GetMovie(string name, string id);

        public Task<IEnumerable<MovieShortDetail>> GetMovieByTerm(string search);
    }
}