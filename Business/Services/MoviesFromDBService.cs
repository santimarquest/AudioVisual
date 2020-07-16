using AudioVisual.Business.Interfaces;
using AudioVisual.Contracts.DTO;
using AudioVisual.Core.Domain;
using AudioVisual.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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
                select new MovieDTO
                {
                   Id = m.Id,
                   Title = m.OriginalTitle,
                   SeatsSold = s.SeatsSold,
                   CityId = cityId,
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
                Genres = _movieRepository.GetMovieGenres(movieGroup.Key).ToList()
            };

            return groupSeatsSold
                .OrderByDescending(x => x.SeatsSold)
                .Take(numberOfMovies * 3);
        }

        public async Task<IEnumerable<Genre>> GetGenresFromSuccesfullMovies(IEnumerable<MovieDTO> successfullMovies)
        {
            var resultGenres = new List<Genre>();

            foreach (var movie in successfullMovies) 
            {
                // var genres = await Task.Run(() => _movieRepository.GetMovieGenres(movie.Id));
                var genres = movie.Genres;
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

        public async Task<IEnumerable<Genre>> GetGenresForSmallRooms(IEnumerable<Genre> genresForBigRooms)
        {
            var genresForSmallRooms = await _movieRepository.GetGenresForSmallRooms(genresForBigRooms);

            var rnd = new Random();
            var genres = genresForSmallRooms.OrderBy(x => rnd.Next()).Take(3);

            return genres;
           
        }

        public async Task<List<GenreDTO>> MapGenresAPIToGenresDB(object genresAPI)
        {
            var genresDTO = new List<GenreDTO>();

            using var jsonDoc = JsonDocument.Parse(genresAPI.ToString());
            var root = jsonDoc.RootElement;

            var genres = root.GetProperty("genres").EnumerateArray().ToList();

            var genresDB = await _movieRepository.GetGenres();

            foreach (var genre in genres)
            {
                var genreDTO = new GenreDTO
                {
                    // genres[0].GetProperty("id").TryGetInt32(out int value)

                    APIId = (genre.GetProperty("id").TryGetInt32(out int value)) ? value : 0,
                    Name = genre.GetProperty("name").ToString(),
                    Id = _movieRepository.GetGenreIdInDBByName(genre.GetProperty("name").ToString())
                };

                genresDTO.Add(genreDTO);
            }

            return genresDTO;
        }

        public async Task<IEnumerable<MovieDTO>> GetSuccessfullMoviesInCity(int cityId, string sizeRoom, int numberOfMoviesForSmallRooms, IEnumerable<Genre> genresForBigRooms)
        {
            var resultMovies = new List<MovieDTO>();
            var successfullMovies = await GetSuccessfullMoviesInCity(cityId, sizeRoom, numberOfMoviesForSmallRooms);

            foreach (var movie in successfullMovies) 
            {

                var genresToRemove = new HashSet<Genre>(genresForBigRooms);
                //authorsList.RemoveAll(x => setToRemove.Contains(x));

                var movieDTO = new MovieDTO();

                movieDTO.Id = movie.Id;
                movieDTO.Title = movie.Title;
                movieDTO.CityId = movie.CityId;
                movieDTO.SeatsSold = movie.SeatsSold;
                movieDTO.Genres = movie.Genres.Where(m => !genresToRemove.Any(g => g.Id == m.Id)).ToList();
                resultMovies.Add(movieDTO);
            }

            return resultMovies;             
        }
    }
}
