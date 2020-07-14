using AudioVisual.Core.Domain;

namespace AudioVisual.Core.Repositories
{
    public interface ISessionRepository : IRepository<Session>
    {
        int GetSeatsSoldForBigRoomsByMovieInCity(int movieId, int cityId);
        int GetSeatsSoldForSmallRoomsByMovieInCity(int movieId, int cityId);
    }
}