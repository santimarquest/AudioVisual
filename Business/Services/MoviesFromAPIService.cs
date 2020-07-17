using AudioVisual.Business.Interfaces;
using AudioVisual.Contracts.DTO;
using AudioVisual.Core.Domain;
using AudioVisual.Domain.Contracts.Enum;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Genre = AudioVisual.Core.Domain.Genre;

namespace AudioVisual.Business.Services
{
    public class MoviesFromAPIService : IMoviesFromAPIService
    {
        private readonly IConfiguration _config;

        public MoviesFromAPIService ( IConfiguration config)
        {
            _config = config;
        }

        public async Task<object> GetMoviesFromAPI(FilterDTO filter)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.themoviedb.org/3/discover/movie");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var queryString = $"?api_key=7c28b31e1e8bb72816e17cf705ae2e32&language=en-US&sort_by=popularity.desc&include_adult=false" +
                $"&include_video=false&page=1" +
                $"&vote_count.gte={filter.VoteCount}" +
                $"&vote_average.gte={filter.VoteAverage}" +
                $"&with_genres={filter.Genres}";

            var response = await Task.Run(() => client.GetAsync(queryString));   

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<object>
                     (await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            }

            return null;
        }

        private string GetWithGenres(IEnumerable<Genre> genresForRooms, IEnumerable<GenreDTO> genresDTO)
        {
            var withGenres =
                from gdto in genresDTO
                join gfr in genresForRooms on gdto.Id equals gfr.Id
                select new
                {
                    genre = gdto.APIId.ToString() + ","
                };

            var result = new StringBuilder();
            foreach (var item in withGenres)
            {
                result.Append(item.genre);
            }

            return result.ToString();           
        }

        public async Task<object> GetGenres()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.themoviedb.org/3/genre/movie/list");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await Task.Run(() => client.GetAsync("?api_key=7c28b31e1e8bb72816e17cf705ae2e32&language=en-US"));

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<object>
                     (await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            }

            return null;
        }

        public FilterDTO SetFilter(IEnumerable<Genre> genres, List<GenreDTO> genresDB, RoomSize roomSize)
        {
            var moviCriteria = _config.GetSection($"MovieCriteria:{roomSize}").GetChildren();
            var appsettings = moviCriteria.ToDictionary(v => v.Key, v => v.Value);

            var filter = new FilterDTO();
            filter.VoteCount = appsettings["Vote_Count"];
            filter.VoteAverage = appsettings["Vote_Average"];
            filter.Genres = GetWithGenres(genres, genresDB);

            return filter;
        }
    }
}
