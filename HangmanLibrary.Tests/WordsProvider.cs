using System;
using System.Collections.Generic;
using System.Text;

namespace HangmanLibrary.Tests
{
    public class WordsProvider
    {
        public List<string> Words { get; }

        public WordsProvider()
        {
            Words = new List<string>
            {
                "absorb",
                "abuse",
                "academic",
                "accent",
                "accept",
                "acceptable",
                "access",
                "accident",
                "accidental",
            };
        }
    }
}
