using AudioVisual.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AudioVisual.Core.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
        IEnumerable<Genre> GetMovieGenres(int id);
        Task<IEnumerable<Genre>> GetGenresForSmallRooms(IEnumerable<Genre> genresForBigRooms);
    }
}