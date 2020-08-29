using System.Collections.Generic;
using System.Threading.Tasks;
using iMovie.Facade.Omdb.Interface;
using iMovie.Facade.Omdb.Domain;
using System.Net.Http;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace iMovie.Facade.Omdb
{
    public class OmdbApi : IOmdbApi
    {
        private readonly string _baseUrl;
        private readonly string _key;
        public OmdbApi(IConfiguration config)
        {
            _baseUrl = config.GetSection("baseUrl").ToString();
            _key = config.GetSection("key").ToString();
        }
        public async Task<OmdbModel> GetByIdOrTitleAsync(ParameterIdTitle parameters)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri(_baseUrl);

                var result = await client.GetAsync(MountQueryParameter(parameters));
                var resulStr = await result.Content.ReadAsStringAsync();
                var deserialized = JsonSerializer.Deserialize<OmdbModel>(resulStr);
                return deserialized;
            }
        }

        public async Task<OmdbSearchModel> GetBySearchAsync(ParameterSearch parameters)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri(_baseUrl);
                var result = await client.GetAsync(MountQueryParameter(parameters));
                var resulStr = await result.Content.ReadAsStringAsync();
                var deserialized = JsonSerializer.Deserialize<OmdbSearchModel>(resulStr);
                return deserialized;
            }
        }

        private string MountQueryParameter(ParameterSearch parameter)
        {
            var query = $"?apikey={_key}";
            query = $"&s={parameter.Search}";
            if (!string.IsNullOrEmpty(parameter.Type))
                query += $"&type={parameter.Type}";
            if (parameter.Year.HasValue)
                query += $"&y={parameter.Year}";
            if (!string.IsNullOrEmpty(parameter.Return))
                query += $"&r={parameter.Return}";
            if (parameter.Page.HasValue)
                query += $"&page={parameter.Page}";
            if (parameter.Version.HasValue)
                query += $"&v={parameter.Version}";
            return query;
        }

        private string MountQueryParameter(ParameterIdTitle parameter)
        {
            var query = $"?apikey={_key}";
            
            if (!string.IsNullOrEmpty(parameter.Id))
                query += $"&i={parameter.Id}";
            if (!string.IsNullOrEmpty(parameter.Title))
                query += $"&t={parameter.Title}";
            if (!string.IsNullOrEmpty(parameter.Type))
                query += $"&type={parameter.Type}";
            if (parameter.Year.HasValue)
                query += $"&y={parameter.Return}";
            if (!string.IsNullOrEmpty(parameter.Plot))
                query += $"&plot={parameter.Plot}";
            if (!string.IsNullOrEmpty(parameter.Return))
                query += $"&r={parameter.Return}";
            if (parameter.Version.HasValue)
                query += $"&v={parameter.Version}";
            return query;
        }
    }
}