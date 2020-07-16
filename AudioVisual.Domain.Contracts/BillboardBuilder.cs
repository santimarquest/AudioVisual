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

        public BillboardBuilder GetMoviesForBigRooms(int cityId, string sizeRoom, int numberOfMoviesForBigRooms)
        {
            return this;
        }

        public BillboardBuilder GetMoviesForSmallRooms(int cityId, string sizeRoom, int numberOfMoviesForBigRooms)
        {
            return this;
        }

        public BillBoard Build()
        {
          return new BillBoard();
        }
    }
        
}
