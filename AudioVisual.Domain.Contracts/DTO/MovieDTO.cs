using AudioVisual.Core.Domain;
using System.Collections.Generic;

namespace AudioVisual.Contracts.DTO
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? SeatsSold { get; set; }
        public int CityId { get; set; }
        public List<Genre> Genres { get; set; }
    }
}
