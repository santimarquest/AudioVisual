using System.Collections.Generic;
using System.Threading.Tasks;
using AudioVisual.Business.Interfaces;
using AudioVisual.Domain.Contracts;
using AudioVisual.Domain.Contracts.FilterOptions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace AudioVisual.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ManagersController : ControllerBase
    {
        private readonly IMoviesFromAPIService _moviesFromAPIService;

        public ManagersController (IMoviesFromAPIService moviesFromAPIService)
        {
            _moviesFromAPIService = moviesFromAPIService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMoviesFromAPI()
        {
            var result = await _moviesFromAPIService.GetAllMoviesFromAPI();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetUpcomingMovies([FromQuery] SearchOptions options)
        {
            // Example: https://localhost:44367/api/Viewers/GetUpcomingMovies?options.genres=[1,2]&options.ageRates=3&options.daysFromNow=15

            List<string> genres = JsonConvert.DeserializeObject<List<string>>(options.Genres);
            List<string> ageRates = JsonConvert.DeserializeObject<List<string>>(options.AgeRates);
            int daysFromNow = options.DaysFromNow;

            return Ok(new List<Movie>());
        }

        [HttpGet]
        public async Task<IActionResult> BuildBillboard([FromQuery] BillboardOptions options)
        {
            // Example: https://localhost:44367/api/Viewers/GetUpcomingMovies?options.genres=[1,2]&options.keywords=['bank','assault','robbery']&options.daysFromNow=15

           // List<string> topics = JsonConvert.DeserializeObject<List<string>>(options.topics);

            // Filter database documentaries by this list of topics

            return Ok(new List<Documentary>());
        }
    }
}
