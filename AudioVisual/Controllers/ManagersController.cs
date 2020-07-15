using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AudioVisual.Business.Interfaces;
using AudioVisual.Contracts.DTO;
using AudioVisual.Core.Domain;
using AudioVisual.Domain.Contracts;
using AudioVisual.Domain.Contracts.FilterOptions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Movie = AudioVisual.Core.Domain.Movie;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace AudioVisual.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ManagersController : ControllerBase
    {
        private readonly IMoviesFromAPIService _moviesFromAPIService;
        private readonly IMoviesFromDBService _moviesFromDBService;

        public ManagersController (IMoviesFromAPIService moviesFromAPIService, IMoviesFromDBService moviesFromDBService)
        {
            _moviesFromAPIService = moviesFromAPIService;
            _moviesFromDBService = moviesFromDBService;
        }

        [HttpGet]
        public async Task<IActionResult> CreateIntelligentBillBoard([FromQuery] BillboardOptions billboardOptions)
        {
            // Example: https://localhost:44367/api/Managers/CreateIntelligentBillBoard?
            // billboardOptions.startDate=01-01-2020&billboardOptions.weeks=3&billboardOptions.BigRooms=5&billboardOptions.SmallRooms=3&
            // billboardOptions.cityId=9

            var startdate = billboardOptions.Startdate;
            var weeks = billboardOptions.Weeks;
            var bigRooms = billboardOptions.BigRooms;
            var smallRooms = billboardOptions.SmallRooms;
            var cityId = billboardOptions.CityId;

            // So to create the Billboard, we need these number of movies:
            var numberOfMoviesForBigRooms = bigRooms * weeks;
            var numberOfMoviesForSmallRooms = smallRooms * weeks;

            // Get genres for big rooms
            var moviesForBigRooms = await _moviesFromDBService.GetSuccessfullMoviesInCity(cityId, sizeRoom:"Big", numberOfMoviesForBigRooms);
            var genresForBigRooms = await _moviesFromDBService.GetGenresFromSuccesfullMovies(moviesForBigRooms);

            // // Get genres for small rooms
            var moviesForSmallRooms = await _moviesFromDBService.GetSuccessfullMoviesInCity(cityId, sizeRoom: "Small", numberOfMoviesForSmallRooms);
            var genresForSmallRooms = await _moviesFromDBService.GetGenresFromSuccesfullMovies(moviesForSmallRooms);

            // var successfullGenres = new List<int>();
            //var moviesFromAPI = await _moviesFromAPIService.GetAllMoviesFromAPIWithGenres();

            //using var jsonDoc = JsonDocument.Parse(moviesFromAPI.ToString());
            //var root = jsonDoc.RootElement;

            //var movieResults = root.GetProperty("results").EnumerateArray();

            //foreach (var result in movieResults)
            //{
            //    var resultDoc = JsonDocument.Parse(result.ToString());
            //    var resultRoot = resultDoc.RootElement;
            //    var genres = resultRoot.GetProperty("genre_ids").EnumerateArray();

            //    foreach (var genre in genres)
            //    {
            //        var value = genre.TryGetInt32(out int genreId);
            //        if (!successfullGenres.Contains(genreId)) {
            //            successfullGenres.Add(genreId);
            //        }
            //    }
            // }

            // var genresForBigRooms =
            //from mfbr in moviesForBigRooms
            //join mfapi in moviesFromAPI on mfbr.Title equals mfapi.Title
            //select new MovieDTO
            //{
            //  genres = mfapi.genres
            //};

            // return Ok(genresForBigRooms);
            return null;
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
