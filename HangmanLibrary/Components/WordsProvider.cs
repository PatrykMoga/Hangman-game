using HangmanLibrary.Glossary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangmanLibrary.Components
{
    public class WordsProvider : IWordsProvider
    {
        public IGlossary Glossary { get; }
        public List<string> Words { get; set; }

        public WordsProvider(IGlossary glossary)
        {
            Glossary = glossary;
            Words = glossary.Words.ToList();
        }

        public void AddWord(string word) => Glossary.AddWord(word);
    }
}
