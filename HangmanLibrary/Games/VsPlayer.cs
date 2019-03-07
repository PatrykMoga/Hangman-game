using System;
using System.Collections.Generic;
using System.Text;

namespace HangmanLibrary.Games
{
    public class VsPlayer
    {
        public int WordLength { get; set; }
        public List<string> WordsBuffer { get; set; }
        public HashSet<char> AvailableCharacters { get; set; }
        public HashSet<char> UsedCharacters { get; set; }
    }
}
