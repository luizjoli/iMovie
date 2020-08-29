using System.Threading.Tasks;
using iMovie.Facade.Omdb.Domain;

namespace iMovie.Facade.Omdb.Interface
{
    public interface IOmdbApi
    {
        public Task<OmdbModel> GetByIdOrTitleAsync(ParameterIdTitle parameters);

        public Task<OmdbSearchModel> GetBySearchAsync(ParameterSearch parameters);
    }
}