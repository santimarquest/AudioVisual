using AudioVisual.Contracts.DTO;
using System;

namespace AudioVisual.Domain.Contracts
{
    public class BillBoardItem
    {
        public DateTime Date { get; set; }
        public MovieDTO Movie { get; set; }
    }
}
