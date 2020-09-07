using iMovie.Core.Movie.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace iMovie.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly ISearchMovie _iSearchMovie;

        public MovieController(ISearchMovie iSearchMovie)
        {
            _iSearchMovie = iSearchMovie;
        }


        [HttpGet]
        public async Task<IActionResult> GetMovie(string name, string id) {
            var result = await _iSearchMovie.GetMovie(name, id);
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetMovieByTerm(string term)
        {
            var result = await _iSearchMovie.GetMovieByTerm(term);
            return Ok(result);
        }
    }
}