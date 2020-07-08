using System;
using System.Collections.Generic;
using System.Text;

namespace AudioVisual.Domain.Contracts
{
    public class Documentary : IAudioVisual
    {
        public string Title { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Overview { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Genre Genre { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Language Language { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime ReleaseDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Uri Website { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<string> KeyWorkds { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
