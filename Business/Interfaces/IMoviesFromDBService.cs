using AudioVisual.Contracts.DTO;
using AudioVisual.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AudioVisual.Business.Interfaces
{
    public interface IMoviesFromDBService
    {
        Task <IEnumerable<MovieDTO>> GetSuccessfullMoviesInCity(int cityId, string sizeRoom, int numberOfMovies);
        Task<IEnumerable<Genre>> GetGenresFromSuccesfullMovies(IEnumerable<MovieDTO> successfullMovies);
        Task<IEnumerable<Genre>> GetGenresForSmallRooms(IEnumerable<Genre> genresForBigRooms);
        Task<List<GenreDTO>> MapGenresAPIToGenresDB(object genresAPI);
    }
}