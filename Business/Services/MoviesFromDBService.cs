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

        public async Task<IEnumerable<MovieDTO>> GetSuccessfullMoviesForBigRoomsInCity(int cityId)
        {
            var sessions = _sessionRepository.GetSessionsWithBigRoomAndCinema();
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

        public async Task<IEnumerable<Genre>> GetGenresFromSuccesfullMovies(IEnumerable<MovieDTO> successfullMovies)
        {
            var resultGenres = new List<Genre>();

            foreach (var movie in successfullMovies) 
            {
                var genres = await Task.Run(() => _movieRepository.GetMovieGenres(movie.Id));
                foreach (var genre in genres)
                {
                    if (!resultGenres.Contains(genre))
                    {
                        resultGenres.Add(genre);
                    }
                }
            }

            return resultGenres;
        }
    }
}
