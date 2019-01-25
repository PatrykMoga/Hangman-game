using HangmanLibrary.Extensions;
using HangmanLibrary.FileGlossary;
using System.Collections.Generic;
using System.Text;

namespace HangmanLibrary.Models
{
    public class VsComputer : Game
    {
        public string Keyword { get; }
        public StringBuilder KeywordAssembler { get; }
        public HashSet<char> Missplaced { get; }
        public int Lifes { get; set; }
        
        public VsComputer(IGlossary glossary, int lifes) : base(glossary)
        {
            Keyword = Words.GetRandomElement();
            KeywordAssembler = new StringBuilder();
            Missplaced = new HashSet<char>();           
            Lifes = lifes;

            for (int i = 0; i < Keyword.Length; i++)
            {
                if (Keyword[i] == ' ')
                {
                    KeywordAssembler.Append(' ');
                }
                else
                {
                    KeywordAssembler.Append('_');
                }
            }  
        }

        private void UpdateAssembler(string input)
        {
            for (int j = 0; j < Keyword.Length; j++)
            {
                if (Keyword[j] == input[0])
                {
                    KeywordAssembler[j] = Keyword[j];
                }
            }
        }
        public bool HasLifes => Lifes > 0;

        public bool KeywordContain(char ch) => Keyword.Contains(ch.ToString()); // ?

        public bool WordsMatched => Keyword == KeywordAssembler.ToString();

        public void WinGame() => Won = true;

        public bool PlayerEnteredKeyword(string input) => input == Keyword;

        public void PlayerMissed(string input)
        {
            Missplaced.Add(input[0]);
            Lifes--;
        }

        public void PlayerHit(string input) => UpdateAssembler(input);
    }
}
