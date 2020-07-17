using AudioVisual.Core.Domain;
using System.Collections.Generic;

namespace AudioVisual.Core.Repositories
{
    public interface ISessionRepository : IRepository<Session>
    {
        IEnumerable<Session> GetSessionsWithRoomAndCinema(string sizeRoom);
    }
}