using AudioVisual.Business.Interfaces;
using AudioVisual.Contracts.DTO;
using AudioVisual.Core.Domain;
using AudioVisual.Core.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AudioVisual.Business.Services
{
    public class MoviesFromAPIService : IMoviesFromAPIService
    {
        public async Task<object> GetAllMoviesFromAPIWithGenres()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.themoviedb.org/3/discover/movie");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync("?api_key=7c28b31e1e8bb72816e17cf705ae2e32&language=en-US&sort_by=popularity.desc&include_adult=false&include_video=false&page=50").Result;  // Blocking call!    

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<object>
                     (await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            }

            return null;
        }
    }
}
