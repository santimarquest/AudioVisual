using AudioVisual.Core.Domain;

namespace AudioVisual.Core.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Movie GetMovieWithGenres(int id);
    }
}