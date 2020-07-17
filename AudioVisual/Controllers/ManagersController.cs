﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AudioVisual.Business.Interfaces;
using AudioVisual.Contracts;
using AudioVisual.Contracts.DTO;
using AudioVisual.Core.Domain;
using AudioVisual.Domain.Contracts;
using AudioVisual.Domain.Contracts.Enum;
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

            // Create empty billboard, with all needed properties and settings
            var billboard = BillboardBuilder.CreateBillboard()
                .WithStartDate(billboardOptions.Startdate)
                .WithNumberOfBigRooms(billboardOptions.BigRooms)
                .WithNumberOfSmallRooms(billboardOptions.SmallRooms)
                .ForTheNextWeeks(billboardOptions.Weeks)
                .ForCity(billboardOptions.CityId)
                .Build();

            // Mapping Genres beetween public API and database
            List<GenreDTO> genresDB = await MapGenresAPIDB();

            // Get successfull movies for big rooms in a city, and from them, get successfull genres for big rooms in that city
            var moviesForBigRooms = await _moviesFromDBService.GetSuccessfullMoviesInCity(billboard.CityId, sizeRoom: "Big", billboard.NumberOfMoviesForBigRooms);
            var genresForBigRooms = await _moviesFromDBService.GetGenresFromSuccesfullMovies(moviesForBigRooms);

            // All genres not suitable for big rooms, are suitable for small rooms. And we choose 2 of them randomly to build the billboard
            var genresForSmallRooms = await _moviesFromDBService.GetGenresForSmallRooms(genresForBigRooms);

            // Now we are starting to create the billboard, taking into account the billboardOptions and the genres for big and small rooms
            billboard.MoviesForBigRooms = await GenerateMovies(billboard.NumberOfMoviesForBigRooms, genresDB, genresForBigRooms, RoomSize.BIG);
            billboard.MoviesForSmallRooms = await GenerateMovies(billboard.NumberOfMoviesForSmallRooms, genresDB, genresForSmallRooms, RoomSize.SMALL);

            return Ok(billboard);
        }

        private async Task<List<string>> GenerateMovies(int numberOfMovies, List<GenreDTO> genresDB, IEnumerable<Core.Domain.Genre> genres, RoomSize roomSize)
        {
            var result = new List<string>();
            
            var filter = _moviesFromAPIService.SetFilter(genres, genresDB, roomSize);
            var moviesAPI = await _moviesFromAPIService.GetMoviesFromAPI(filter);
            using (var jsonDoc = JsonDocument.Parse(moviesAPI.ToString()))
            {
                var root = jsonDoc.RootElement;
                var movies = root.GetProperty("results").EnumerateArray().Take(numberOfMovies).ToList();

                foreach (var movie in movies)
                {
                    result.Add(movie.GetProperty("title").GetString());
                }
            }

            return result;
        }

        private async Task<List<GenreDTO>> MapGenresAPIDB()
        {
            var genresAPI = await _moviesFromAPIService.GetGenres();
            List<GenreDTO> genresDB = await _moviesFromDBService.MapGenresAPIToGenresDB(genresAPI);
            return genresDB;
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
