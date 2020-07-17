using AudioVisual.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AudioVisual.Domain.Contracts
{
    public class BillBoard
    {
        public BillBoard(DateTime startDate, DateTime endDate, int numberOfBigRooms, int numberOfSmallRooms, 
                                int numberOfMoviesForBigRooms, int numberOfMoviesForSmallRooms, int cityId) 
        {
            StartDate = startDate;
            EndDate = endDate;
            NumberOfBigRooms = numberOfBigRooms;
            NumberOfSmallRooms = numberOfSmallRooms;
            NumberOfMoviesForBigRooms = numberOfMoviesForBigRooms;
            NumberOfMoviesForSmallRooms = numberOfMoviesForSmallRooms;
            CityId = cityId;

        }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int CityId { get; set; }
        public int NumberOfBigRooms{ get; set; }
        public int NumberOfSmallRooms { get; set; }
        public int NumberOfMoviesForBigRooms { get; set; }
        public int NumberOfMoviesForSmallRooms { get; set; }
        public object MoviesForBigRooms { get; set; }
        public object MoviesForSmallRooms { get; set; }

    }
}
