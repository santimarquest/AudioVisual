using AudioVisual.Contracts.DTO;
using AudioVisual.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AudioVisual.Contracts
{
    public class BillboardBuilder
    {

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumberOfMoviesForBigRooms { get; private set; }
        public int NumberOfMoviesForSmallRooms { get; private set; }
        public int NumberOfBigRooms { get; set; }
        public int CityId { get; set; }

        IEnumerable<GenreDTO> GenresForBigRooms { get; set; }

        IEnumerable<BillBoardItem> MoviesForBigRooms { get; set; }

        public int NumberOfSmallRooms { get; set; }

        IEnumerable<GenreDTO> GenresForSmallRooms { get; set; }

        IEnumerable<BillBoardItem> MoviesForSmallRooms { get; set; }


        public static BillboardBuilder CreateBillboard()
        {
            return new BillboardBuilder();
        }

        public BillboardBuilder WithStartDate(string startDate)
        {
            if (DateTime.TryParse(startDate, out DateTime value))
            {
                StartDate = value;
            }
            else
            {
                throw new ArgumentException("Incorrect StartDate");
            }
            return this;
        }

        public BillboardBuilder ForTheNextWeeks(int weeks)
        {
            if (weeks <=0 || weeks > 3)
            {
                // Not allowed a Billboard for more than 3 weeks
                throw new ArgumentException("Incorrect Weeks parameter");
            }
            EndDate = StartDate.AddDays(weeks * 7);
            NumberOfMoviesForBigRooms = NumberOfBigRooms * weeks;
            NumberOfMoviesForSmallRooms = NumberOfSmallRooms * weeks;

            return this;
        }

        public BillboardBuilder WithNumberOfBigRooms(int numberOfBigRooms)
        {
            if (numberOfBigRooms < 0 || numberOfBigRooms > 10)
            {
                // Not allowed a Billboard for more than 10 big rooms
                throw new ArgumentException("Incorrect number of big rooms");
            }
            NumberOfBigRooms = numberOfBigRooms;
            return this;
        }

        public BillboardBuilder WithNumberOfSmallRooms(int numberOfSmallRooms)
        {
            if (numberOfSmallRooms < 0 || numberOfSmallRooms > 10)
            {
                // Not allowed a Billboard for more than 10 small rooms
                throw new ArgumentException("Incorrect number of small rooms");
            }
            NumberOfSmallRooms = numberOfSmallRooms;
            return this;
        }

        public BillboardBuilder ForCity(int cityId)
        {
            CityId = cityId;
            return this;
        }

        public BillBoard Build()
        {
          return new BillBoard(StartDate, EndDate, NumberOfBigRooms, NumberOfSmallRooms, 
                                          NumberOfMoviesForBigRooms, NumberOfMoviesForSmallRooms,CityId);
        }
    }
        
}
