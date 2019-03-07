using System.Collections.Generic;

namespace HangmanLibrary.Components
{
    public interface IHasBuffer
    {
        List<string> WordsBuffer { get; set; }
    }
}