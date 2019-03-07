using HangmanLibrary.Glossary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangmanLibrary.Components
{
    public class WordsProvider
    {
        private IGlossary _glossary;
        public List<string> Words { get; set; }

        public WordsProvider(IGlossary glossary)
        {
            _glossary = glossary;
            Words = glossary.Words.ToList();
        }

        public void AddWord(string word) => _glossary.AddWord(word);
    }
}
