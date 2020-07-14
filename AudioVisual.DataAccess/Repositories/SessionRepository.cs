
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AudioVisual.Core.Domain;
using AudioVisual.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AudioVisual.DataAccess.Repositories
{
    public class SessionRepository : Repository<Session>, ISessionRepository
    {
        public SessionRepository(BeezyCinemaContext context) : base(context)
        {
        }


        public BeezyCinemaContext BeezycinemaContext
        {
            get { return Context as BeezyCinemaContext; }
        }

        public int GetSeatsSoldForBigRoomsByMovieInCity(int movieId, int cityId)
        {
            var seats = BeezycinemaContext.Session.Find(movieId, cityId);
            return 0;
        }

        public int GetSeatsSoldForSmallRoomsByMovieInCity(int movieId, int cityId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Session>> GetSessionsWithRoom()
        {
            return BeezycinemaContext.Session
                .Include(s => s.Room)
                .Include(s => s.Room.Cinema)
                .Where(s => s.Room.Size == "Big");
        }
    }
}