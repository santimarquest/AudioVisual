using AudioVisual.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AudioVisual.Business.Interfaces
{
    public interface IMoviesFromDBService
    {
        Task<IEnumerable<Movie>> GetAllMoviesFromDB();
        Task< IEnumerable<Movie>> GetCriteriaRecommendationsFromDB();
    }
}