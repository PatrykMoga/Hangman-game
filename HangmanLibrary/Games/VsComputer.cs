using System;
using System.Collections.Generic;
using System.Text;

namespace HangmanLibrary.Components
{
    public class VsComputer : IVsComputer
    {
        public string Keyword { get; set; }          
        public int Lifes { get; set; }
        public bool Won { get; set; }
      
        public bool HasLifes => Lifes > 0;       
        public bool PlayerEnteredKeyword(string input) => input == Keyword;      
        public void WinGame() => Won = true;
        public bool KeywordContain(char ch) => Keyword.Contains(ch.ToString());
    }
}
