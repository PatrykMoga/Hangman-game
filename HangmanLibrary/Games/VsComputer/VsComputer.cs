using HangmanLibrary.Components;

namespace HangmanLibrary.Games.VsComputer
{
    public class VsComputer : IHasKeyword, IHasLifes, IWinnable
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
