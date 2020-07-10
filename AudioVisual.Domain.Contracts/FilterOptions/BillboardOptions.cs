using AudioVisual.Domain.Contracts;
using System;
using System.Collections.Generic;

namespace AudioVisual.Domain.Contracts.FilterOptions
{
    // api key = 7c28b31e1e8bb72816e17cf705ae2e32
    public class BillboardOptions
    {
        public DateTime Startdate  { get; set; }
        public int DaysFromStartDate { get; set; }
        List<Room> Rooms { get; set; }
    }
}