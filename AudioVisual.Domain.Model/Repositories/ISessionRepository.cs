using AudioVisual.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AudioVisual.Core.Repositories
{
    public interface ISessionRepository : IRepository<Session>
    {
        IEnumerable<Session> GetSessionsWithBigRoomAndCinema();
    }
}