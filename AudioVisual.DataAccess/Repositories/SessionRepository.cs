using AudioVisual.Core.Domain;
using AudioVisual.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AudioVisual.DataAccess.Repositories
{
    public class SessionRepository : Repository<Session>, ISessionRepository
    {
        public SessionRepository()
        {
        }

        public SessionRepository(BeezyCinemaContext context) : base(context)
        {
        }


        public BeezyCinemaContext BeezycinemaContext
        {
            get { return Context as BeezyCinemaContext; }
        }

        public IEnumerable<Session> GetSessionsWithRoomAndCinema(string sizeRoom)
        {
            return BeezycinemaContext.Session
                .Include(s => s.Room)
                .Include(s => s.Room.Cinema)
                .Where(s => s.Room.Size == sizeRoom);
        }
    }
}