using AudioVisual.Contracts.DTO;
using AudioVisual.Core.Domain;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace AudioVisual.Business.Interfaces
{
    public interface IMoviesFromAPIService
    {
        Task<object> GetAllMoviesFromAPIWithGenres(IEnumerable<Genre> genresForRooms, IEnumerable<GenreDTO> genresDB);
        Task <object> GetGenres();
    }
}