using iMovie.Domain.Service.Omdb;
using System.Threading.Tasks;

namespace iMovie.Facade.Omdb.Interface
{
    public interface IOmdbApi
    {
        public Task<OmdbModel> GetByIdOrTitleAsync(ParameterIdTitle parameters);

        public Task<OmdbSearchModel> GetBySearchAsync(ParameterSearch parameters);
    }
}