﻿using AudioVisual.Contracts.DTO;
using AudioVisual.Domain.Contracts.Enum;
using System.Collections.Generic;
using System.Threading.Tasks;
using Genre = AudioVisual.Core.Domain.Genre;

namespace AudioVisual.Business.Interfaces
{
    public interface IMoviesFromAPIService
    {
        Task<object> GetMoviesFromAPI(FilterDTO filter);
        Task<object> GetGenresFromAPI();
        FilterDTO SetFilter(IEnumerable<Genre> genres, IEnumerable<GenreDTO> genresDB, RoomSize roomSize);
    }
}