using AudioVisual.Business.Interfaces;
using AudioVisual.Contracts.DTO;
using AudioVisual.Core.Domain;
using AudioVisual.Core.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AudioVisual.Business.Services
{
    public class MoviesFromAPIService : IMoviesFromAPIService
    {
        public async Task<object> GetAllMoviesFromAPIWithGenres(IEnumerable<Genre> genresForRooms, IEnumerable<GenreDTO> genresDB)
        {

            string with_genres = GetWithGenres(genresForRooms, genresDB);
            // string without_genres = GetWithoutGenres(genresForRooms, genresDB);

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.themoviedb.org/3/discover/movie");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var queryString = $"?api_key=7c28b31e1e8bb72816e17cf705ae2e32&language=en-US&sort_by=popularity.desc&include_adult=false&include_video=false&page=1" +
                $"&with_genres={with_genres}";
               // $"&without_genres={without_genres}";
            var response = await Task.Run(() => client.GetAsync(queryString));   

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<object>
                     (await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            }

            return null;
        }

        private string GetWithoutGenres(IEnumerable<Genre> genresForRooms, IEnumerable<GenreDTO> genresDTO)
        {
            var result = new StringBuilder();

            foreach (var gdto in genresDTO)
            {
                if (!genresForRooms.Any(gfr => gfr.Id == gdto.Id))
                {
                    result.Append(gdto.APIId.ToString());
                    result.Append(",");
                };
            }

            return result.ToString();

        }

        private string GetWithGenres(IEnumerable<Genre> genresForRooms, IEnumerable<GenreDTO> genresDTO)
        {
            var result = new StringBuilder();

            foreach (var gdto in genresDTO)
            {
                if (genresForRooms.Any(gfr => gfr.Id == gdto.Id))
                {
                    result.Append(gdto.APIId.ToString());
                    result.Append(",");
                };
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
    }
}
