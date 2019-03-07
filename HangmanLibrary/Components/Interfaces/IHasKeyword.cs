using System;
using System.Collections.Generic;
using System.Text;

namespace HangmanLibrary.Components
{
    public interface IHasKeyword
    {
        string Keyword { get; set; }
        bool PlayerEnteredKeyword(string input);
        bool KeywordContain(char ch);
    }
}
