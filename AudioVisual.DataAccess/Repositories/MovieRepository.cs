
using System.Collections.Generic;
using System.Linq;
using AudioVisual.Core.Domain;
using AudioVisual.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AudioVisual.DataAccess.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(BeezyCinemaContext context) : base(context)
        {
        }

        public Movie GetMovieWithGenres(int id)
        {
            // return BeezycinemaContext.Movie.Include(a => a.).SingleOrDefault(a => a.Id == id);
            return new Movie();
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

        public BeezyCinemaContext BeezycinemaContext
        {
            get { return Context as BeezyCinemaContext; }
        }
    }
}