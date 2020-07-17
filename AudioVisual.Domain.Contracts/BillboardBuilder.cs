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
        public int NumberOfBigRooms { get; set; }

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
            return this;
        }

        public BillboardBuilder WithNumberOfBigRooms(int numberOfBigRooms)
        {
            return this;
        }

        public BillboardBuilder WithNumberOfSmallRooms(int numberOfSmallRooms)
        {
            return this;
        }

        public BillboardBuilder GetMoviesFromAPI(int cityId, string sizeRoom, int numberOfMoviesForBigRooms, int numberOfMoviesForSmallRooms)
        {
            return this;
        }

        public BillBoard Build()
        {
          return new BillBoard();
        }
    }
        
}
