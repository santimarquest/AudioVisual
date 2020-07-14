using AudioVisual.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AudioVisual.Core.Repositories
{
    public interface ISessionRepository : IRepository<Session>
    {
        int GetSeatsSoldForBigRoomsByMovieInCity(int movieId, int cityId);
        int GetSeatsSoldForSmallRoomsByMovieInCity(int movieId, int cityId);
        Task<IEnumerable<Session>> GetSessionsWithRoom();
    }
}