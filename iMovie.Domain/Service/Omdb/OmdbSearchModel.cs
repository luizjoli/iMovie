using System.Collections.Generic;

namespace iMovie.Domain.Service.Omdb
{
    public class OmdbSearchModel
    {
        public IEnumerable<OmdbItemModel> Search { get; set; }
    }
}