using AudioVisual.Business.Interfaces;
using AudioVisual.Contracts.DTO;
using AudioVisual.Core.Domain;
using AudioVisual.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioVisual.Business.Services
{
    public class MoviesFromDBService : IMoviesFromDBService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ISessionRepository _sessionRepository;

        public MoviesFromDBService (IMovieRepository movieRepository, ISessionRepository sessionRepository)
        {
            _movieRepository = movieRepository;
            _sessionRepository = sessionRepository;
        }

        public async Task<IEnumerable<Movie>> GetSuccessfullMoviesForBigScreenFromDB()
        {
            var movies = _movieRepository.GetAll();


            return null;
        }

        public async Task<IEnumerable<Movie>> GetSuccessfullMoviesForSmallScreenFromDB()
        {
            return _movieRepository.GetAll();
        }

        public async Task<IEnumerable<Movie>> GetCriteriaRecommendationsFromDB()
        {
            return null;
        }

        public Task<IEnumerable<Movie>> GetAllMoviesFromDB()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MovieDTO>> GetSuccessfullMoviesForBigRoomsInCity(int cityId)
        {
            var sessions = _sessionRepository.GetSessionsWithRoom().Result;
            var movies = _movieRepository.GetAll();

            var moviesForBigRooms =
                from m in movies
                join s in sessions on m.Id equals s.MovieId
                orderby s.SeatsSold descending
                select new MovieDTO
                {
                   Id = m.Id,
                   Title = m.OriginalTitle,
                   SeatsSold  = s.SeatsSold,
                   CityId = (s?.Room?.Cinema?.CityId == cityId) ? cityId : 0
                };

            return moviesForBigRooms;
        }
    }
}
