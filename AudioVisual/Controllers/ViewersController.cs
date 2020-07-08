using System.Collections.Generic;
using System.Threading.Tasks;
using AudioVisual.Domain.Contracts;
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

            List<string> genres = JsonConvert.DeserializeObject<List<string>>(options.genres);
            List<string> keywords = JsonConvert.DeserializeObject<List<string>>(options.keywords);

            return Ok(new List<Movie>());
        }

        [HttpGet]
        public async Task<IActionResult> GetUpcomingMovies([FromQuery] SearchOptions options)
        {
            // Example: https://localhost:44367/api/Viewers/GetUpcomingMovies?options.genres=[1,2]&options.keywords=['bank','assault','robbery']&options.daysFromNow=15

            List<string> genres = JsonConvert.DeserializeObject<List<string>>(options.genres);
            List<string> keywords = JsonConvert.DeserializeObject<List<string>>(options.keywords);
            int daysFromNow = options.daysFromNow;

            return Ok(new List<Movie>());
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTimeRecommendedDocumentaries([FromQuery] SearchOptions options)
        {
            // Example: https://localhost:44367/api/Viewers/GetUpcomingMovies?options.genres=[1,2]&options.keywords=['bank','assault','robbery']&options.daysFromNow=15

            List<string> topics = JsonConvert.DeserializeObject<List<string>>(options.topics);

            return Ok(new List<Documentary>());
        }
    }
}
