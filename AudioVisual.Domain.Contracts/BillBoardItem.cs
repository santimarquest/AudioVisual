using System;
using System.Collections.Generic;
using System.Text;

namespace AudioVisual.Domain.Contracts
{
    public class BillBoardItem
    {
        public DateTime Date { get; set; }
        public Room Room { get; set; }
        public IAudioVisual AudioVisual { get; set; }
    }
}
