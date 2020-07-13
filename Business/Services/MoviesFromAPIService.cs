using AudioVisual.Business.Interfaces;
using AudioVisual.Core.Domain;
using AudioVisual.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AudioVisual.Business.Services
{
    public class MoviesFromAPIService : IMoviesFromAPIService
    {
        private readonly IMovieRepository _movieRepository;

        public MoviesFromAPIService (IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public async Task<IEnumerable<Movie>> GetAllMoviesFromAPI()
        {
           return _movieRepository.GetAll();
        }
    }
}
