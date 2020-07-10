using AudioVisual.Domain.Contracts.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace AudioVisual.Domain.Contracts
{
    public class TVShow : IAudioVisual
    {
        public string Title { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Overview { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Genre[] Genres { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Language[] Languages { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime ReleaseDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Uri Website { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<string> KeyWorkds { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<(int,int, bool)> Seasons { get; set; }
        public AgeRate AgeRate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Topic[] Topics { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
