using AudioVisual.Domain.Contracts.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace AudioVisual.Domain.Contracts
{
    public class Room
    {
        public int Id { get; set; }
        public RoomSize Size { get; set; }
    }
}
