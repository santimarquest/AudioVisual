using AudioVisual.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AudioVisual.Business.Interfaces
{
    public interface IMoviesFromAPIService
    {
       Task< IEnumerable<Movie>> GetAllMoviesFromAPI();
    }
}