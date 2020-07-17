namespace AudioVisual.Domain.Contracts.FilterOptions
{
    public class SearchOptions
    {
        public string Genres { get; set; }
        public string Keywords { get; set; }
        public int DaysFromNow { get; set; }
        public string Topics { get; set; }
        public string AgeRates { get; set; }
    }
}