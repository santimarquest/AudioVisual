using AudioVisual.Domain.Contracts;
using System;
using System.Collections.Generic;

namespace AudioVisual.Domain.Contracts.FilterOptions
{
    public class BillboardOptions
    {
        public DateTime Startdate  { get; set; }
        public int DaysFromStartDate { get; set; }
        List<Room> Rooms { get; set; }
    }
}