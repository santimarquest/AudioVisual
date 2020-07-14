using AudioVisual.Core.Domain;
using System.Collections.Generic;

namespace AudioVisual.Core.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
        IEnumerable<Genre> GetMovieGenres(int id);
    }
}