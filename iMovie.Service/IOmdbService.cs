using iMovie.Domain.Service.Omdb;
using RestEase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iMovie.Service
{
    public interface IOmdbService
    {

        [Get]
        Task<OmdbModel> GetByIdOrTitle([Query(Name = "apikey")]string apikey,  [Query(Name = "i")]string id, 
            [Query(Name = "t")]string title, [Query(Name = "type")]string type, [Query(Name ="y")]int? year, 
            [Query(Name = "plot")]string plot = "short", [Query(Name = "r")]string returnDocument = "json",
            [Query(Name ="v")]string version = "1");

        [Get]
        Task<OmdbSearchModel> GetBySearch([Query(Name = "apikey")]string apikey, [Query(Name = "s")]string search,
            [Query(Name = "type")]string type, [Query(Name = "y")]int? year, [Query(Name = "r")]string returnDocument = "json", 
            [Query(Name = "page")]int? page = 1, [Query(Name = "v")]string version = "1");
    }
}
