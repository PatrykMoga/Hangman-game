using HangmanLibrary.FileGlossary;
using System.Collections.Generic;
using System.Linq;

namespace HangmanLibrary.Models
{
    public abstract class Game
    {       
        public static List<string> Words { get; set; }
        public bool Won { get; set; }
        private IGlossary _glossary;

        protected Game(IGlossary glossary)
        {
            _glossary = glossary;
            Words = glossary.Words.ToList();
        }

        public void AddWord(string word) => _glossary.AddWord(word);
    }
}
