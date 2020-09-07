using System.Threading.Tasks;
using iMovie.Facade.Omdb.Interface;
using System.Net.Http;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using iMovie.Domain.Service.Omdb;
using iMovie.Service;
using RestEase;

namespace iMovie.Facade.Omdb
{
    public class OmdbApi : IOmdbApi
    {
        private readonly string _baseUrl;
        private readonly string _key;
        public OmdbApi(IConfiguration config)
        {
            _baseUrl = config.GetValue<string>("omdb-baseUrl");
            _key = config.GetValue<string>("omdb-key");
        }
        public async Task<OmdbModel> GetByIdOrTitleAsync(ParameterIdTitle parameters)
        {
            var service = RestClient.For<IOmdbService>(_baseUrl);

            var result = await service.GetByIdOrTitle(_key, parameters.Id, parameters.Title, parameters.Type,
                parameters.Year, parameters.Plot, parameters.Return, parameters.Version);

            return result;

        }

        public async Task<OmdbSearchModel> GetBySearchAsync(ParameterSearch parameters)
        {

            var service = RestClient.For<IOmdbService>(_baseUrl);

            var result = await service.GetBySearch(_key, parameters.Search, parameters.Type,
                parameters.Year, parameters.Return, parameters.Page, parameters.Version);

            return result;

        }
    }
}