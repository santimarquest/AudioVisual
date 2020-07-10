using AudioVisual.Domain.Contracts.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace AudioVisual.Domain.Contracts
{
    // In the solution delivered, we will value aspects such as maintainable code, SOLID principles, 
    // rational use of architecture standards/patterns, organised code structure, data access patterns, 
    // exception handling, testing, logging… Or also additional documentation or diagrams you might provide.
    public interface IAudioVisual
    {
        string Title { get; set; }
        string Overview { get; set; }
        Genre[] Genres { get; set; }
        Topic[] Topics { get; set; }
        Language[] Languages { get; set; }
        DateTime ReleaseDate { get; set; }
        Uri Website { get; set; }
        List<string> KeyWorkds { get; set; }
        AgeRate AgeRate { get; set; }
        
    }
}
