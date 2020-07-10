using System;
using System.Collections.Generic;
using System.Text;

namespace AudioVisual.Domain.Contracts
{
    public class BillBoard
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<BillBoardItem> Items { get; set; }

    }
}
