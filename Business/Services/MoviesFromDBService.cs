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

        public async Task<IEnumerable<MovieDTO>> GetSuccessfullMoviesInCity(int cityId, string sizeRoom, int numberOfMovies)
        {
            var sessions = _sessionRepository.GetSessionsWithRoomAndCinema(sizeRoom);
            var movies = _movieRepository.GetAll();

            var moviesForSizeRooms = 
                from m in movies
                join s in sessions on m.Id equals s.MovieId
                where (s.Room.Cinema.CityId == cityId)
               // orderby m.Id, s.SeatsSold descending
                // group m by m.Id into movieGroup
                select new MovieDTO
                {
                   Id = m.Id,
                   Title = m.OriginalTitle,
                   SeatsSold = s.SeatsSold,
                   CityId = cityId
                };

            var groupSeatsSold =
            from movie in moviesForSizeRooms
            group movie by movie.Id into movieGroup
            select new MovieDTO
            {
                Id = movieGroup.Key,
                Title = movieGroup.First().Title,
                CityId = movieGroup.First().CityId,
                SeatsSold = movieGroup.Sum(x => x.SeatsSold),
            };

            return groupSeatsSold
                .OrderByDescending(x => x.SeatsSold)
                .Take(numberOfMovies);
        }

        public async Task<IEnumerable<Genre>> GetGenresFromSuccesfullMovies(IEnumerable<MovieDTO> successfullMovies)
        {
            var resultGenres = new List<Genre>();

            foreach (var movie in successfullMovies) 
            {
                var genres = await Task.Run(() => _movieRepository.GetMovieGenres(movie.Id));
                foreach (var genre in genres)
                {
                    if (!resultGenres.Any(rg => rg.Id == genre.Id))
                    {
                        resultGenres.Add(genre);
                    }
                }
            }

            return resultGenres;
        }
    }
}
