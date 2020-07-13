
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

        public BeezyCinemaContext BeezycinemaContext
        {
            get { return Context as BeezyCinemaContext; }
        }
    }
}