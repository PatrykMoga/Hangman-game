using HangmanLibrary.Components;
using System.Collections.Generic;

namespace HangmanLibrary.Games.VsPlayer
{
    public class VsPlayer : IHasBuffer
    {
        public List<string> WordsBuffer { get; set; } = new List<string>();       
    }
}
