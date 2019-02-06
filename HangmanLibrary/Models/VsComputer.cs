using HangmanLibrary.Extensions;
using HangmanLibrary.FileGlossary;
using System;
using System.Collections.Generic;
using System.Text;

namespace HangmanLibrary.Models
{
    public class VsComputer : Game, IKeywordAssemblable, ILifeable
    {
        public string Keyword { get; }
        public HashSet<char> Missplaced { get; }
        public byte Lifes { get; set; }

        private readonly KeywordAssembler _assembler;

        public VsComputer(IGlossary glossary, byte lifes) : base(glossary)
        {
            Keyword = Words.GetRandomElement();
            _assembler = new KeywordAssembler(this);
            Missplaced = new HashSet<char>();
            Lifes = lifes;
        }

        public bool HasLifes => Lifes > 0;

        public bool KeywordContain(char ch) => Keyword.Contains(ch.ToString());

        public bool WordsMatched => Keyword == _assembler.Assembler.ToString();

        public string HiddenKeywordView => _assembler.bla;

        public void WinGame() => Won = true;

        public bool PlayerEnteredKeyword(string input) => input == Keyword;

        public void PlayerMissed(string input)
        {
            Missplaced.Add(input[0]);
            Lifes--;
        }

        public void PlayerHit(string input) => _assembler.UpdateAssembler(input);
    }
}
