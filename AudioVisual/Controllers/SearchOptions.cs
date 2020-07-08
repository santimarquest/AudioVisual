using System.Collections.Generic;

namespace AudioVisual.Controllers
{
    public class SearchOptions
    {
        public string genres { get; set;  }
        public string keywords { get; set; }
        public int daysFromNow { get; set; }
        public string topics { get; set; }
    }
}