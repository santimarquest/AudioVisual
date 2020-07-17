using AudioVisual.Domain.Contracts.Enum;

namespace AudioVisual.Domain.Contracts
{
    public class Room
    {
        public int Id { get; set; }
        public RoomSize Size { get; set; }
    }
}
