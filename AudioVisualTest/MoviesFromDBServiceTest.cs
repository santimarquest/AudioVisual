using AudioVisual.Business.Services;
using AudioVisual.Contracts.DTO;
using AudioVisual.Core.Domain;
using AudioVisual.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using Xunit;

namespace AudioVisualTest
{
    public class MoviesFromDBServiceTest
    {
        [Fact]
        public void GetGenresFromSuccesfullMoviesTest()
        {
            
            // Arrange
            var movieRepository = new MovieRepository();
            var sessionRepository = new SessionRepository();

            var moviesFromDBService = new MoviesFromDBService(movieRepository, sessionRepository);

            var successfullMoviesForBigRooms = new List<MovieDTO>()
            {
                 new MovieDTO() {Id =1, Title="Film1", SeatsSold = 100, CityId = 9,
                     Genres = new List<Genre>() {
                         new Genre() {Id=1, Name="Action" } ,
                         new Genre() {Id=3, Name="Thriller" }
                     }},
                  new MovieDTO() {Id =1, Title="Film2", SeatsSold = 100, CityId = 9,
                     Genres = new List<Genre>() {
                         new Genre() {Id=1, Name="Action" } ,
                         new Genre() {Id=2, Name="Adventure" }
                     }},
                   new MovieDTO() {Id =1, Title="Film3", SeatsSold = 100, CityId = 9,
                     Genres = new List<Genre>() {
                         new Genre() {Id=1, Name="Action" } ,
                         new Genre() {Id=2, Name="Adventure" }
                     } },
                  new MovieDTO() {Id =1, Title="Film4", SeatsSold = 100, CityId = 9,
                     Genres = new List<Genre>() {
                         new Genre() {Id=4, Name="Crime" } ,
                         new Genre() {Id=3, Name="Thriller" }
                     } },
                  new MovieDTO() {Id =1, Title="Film5", SeatsSold = 100, CityId = 9,
                     Genres = new List<Genre>() {
                         new Genre() {Id=1, Name="Action" } ,
                         new Genre() {Id=2, Name="Adventure" }
                     } },
                  new MovieDTO() {Id =1, Title="Film6", SeatsSold = 100, CityId = 9,
                     Genres = new List<Genre>() {
                         new Genre() {Id=1, Name="Action" } ,
                         new Genre() {Id=2, Name="Adventure" },
                     } },
                  new MovieDTO() {Id =1, Title="Film7", SeatsSold = 100, CityId = 9,
                     Genres = new List<Genre>() {
                         new Genre() {Id=1, Name="Action" } ,
                         new Genre() {Id=2, Name="Adventure"},
                     } },
                  new MovieDTO() {Id =1, Title="Film8", SeatsSold = 100, CityId = 9,
                     Genres = new List<Genre>() {
                         new Genre() {Id=1, Name="Action" } ,
                         new Genre() {Id=4, Name="Crime" }
                     },
            }};

            // Act
            var result = moviesFromDBService.GetGenresFromSuccesfullMovies(successfullMoviesForBigRooms);

            // Assert
            Assert.All(result.Result, item => Assert.Contains(item.Id, new List<int>() { 1, 2, 3, 4 }));
        }
    }
}
