
using AudioVisual.Contracts.DTO;
using AudioVisual.Core.Domain;
using AudioVisual.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudioVisual.DataAccess.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(BeezyCinemaContext context) : base(context)
        {
        }

        public MovieRepository()
        {
        }

        public IEnumerable<Genre> GetMovieGenres(int movieId)
        {
            var movieGenres = BeezycinemaContext.MovieGenre
              .Where(s => s.MovieId == movieId)
              .Select(s => s.GenreId).ToList();

            var genres = BeezycinemaContext.Genre;

            var resultGenres =
            from m in movieGenres
            join g in genres on m equals g.Id
            select new Genre
            {
                Id = g.Id,
                Name = g.Name
            };

            return resultGenres;
        }

        public IEnumerable<MovieDTO> GetMoviesWithGenres()
        {

            var movies = BeezycinemaContext.Movie;

            var moviesWithGenres =
                from m in movies
                select new MovieDTO
                {
                    Id = m.Id,
                    Title = m.OriginalTitle,
                    Genres = GetMovieGenres(m.Id).ToList()
                };

            return moviesWithGenres;
        }

        public async Task<IEnumerable<Genre>> GetGenresForSmallRooms(IEnumerable<Genre> genresForBigRooms)
        {
            var genres = BeezycinemaContext.Genre.Where(g => !g.Name.Contains("TV")).ToList();
            return await Task.Run(() => genres.Where(g => !genresForBigRooms.Any(gbr => gbr.Id == g.Id)));
        }

        public async Task<IEnumerable<Genre>> GetGenres()
        {
            return await Task.Run(() => BeezycinemaContext.Genre);
        }

        public int GetGenreIdInDBByName(string genreName)
        {
            return BeezycinemaContext.Genre.FirstOrDefault(g => g.Name == genreName).Id;
        }

        public BeezyCinemaContext BeezycinemaContext
        {
            get { return Context as BeezyCinemaContext; }
        }
    }
}