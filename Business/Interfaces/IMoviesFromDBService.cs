using AudioVisual.Contracts.DTO;
using AudioVisual.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AudioVisual.Business.Interfaces
{
    public interface IMoviesFromDBService
    {
        Task <IEnumerable<MovieDTO>> GetSuccessfullMoviesForBigRoomsInCity(int cityId);
        Task<IEnumerable<Genre>> GetGenresFromSuccesfullMovies(IEnumerable<MovieDTO> successfullMovies);
    }
}