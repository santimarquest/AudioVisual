using System;
using System.Collections.Generic;
using System.Text;

namespace AudioVisual.Domain.Contracts
{
    public interface IAudioVisual
    {
        string Title { get; set; }
        string Overview { get; set; }
        Genre Genre { get; set; }
        Language Language { get; set; }
        DateTime ReleaseDate { get; set; }
        Uri Website { get; set; }
        List<string> KeyWorkds { get; set; }

        
    }
}
