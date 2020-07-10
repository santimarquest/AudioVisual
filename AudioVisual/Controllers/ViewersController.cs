using System.Collections.Generic;
using System.Threading.Tasks;
using AudioVisual.Domain.Contracts;
using AudioVisual.Domain.Contracts.FilterOptions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace AudioVisual.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ViewersController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllTimeRecommendedMovies([FromQuery] SearchOptions options)
        {
            // Example: https://localhost:44367/api/Viewers/GetAllTimeRecommendedMovies?options.genres=[1,2]&options.keywords=['bank','assault','robbery']

            List<string> genres = JsonConvert.DeserializeObject<List<string>>(options.Genres);
            List<string> keywords = JsonConvert.DeserializeObject<List<string>>(options.Keywords);

            return Ok(new List<Movie>());
        }

        [HttpGet]
        public async Task<IActionResult> GetUpcomingMovies([FromQuery] SearchOptions options)
        {
            // Example: https://localhost:44367/api/Viewers/GetUpcomingMovies?options.genres=[1,2]&options.keywords=['bank','assault','robbery']&options.daysFromNow=15

            List<string> genres = JsonConvert.DeserializeObject<List<string>>(options.Genres);
            List<string> keywords = JsonConvert.DeserializeObject<List<string>>(options.Keywords);
            int daysFromNow = options.DaysFromNow;

            return Ok(new List<Movie>());
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTimeRecommendedDocumentaries([FromQuery] SearchOptions options)
        {
            // Example: https://localhost:44367/api/Viewers/GetUpcomingMovies?options.genres=[1,2]&options.keywords=['bank','assault','robbery']&options.daysFromNow=15

            List<string> topics = JsonConvert.DeserializeObject<List<string>>(options.Topics);

            // Filter database documentaries by this list of topics

            return Ok(new List<Documentary>());
        }
    }
}
