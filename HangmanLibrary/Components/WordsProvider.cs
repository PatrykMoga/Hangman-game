using HangmanLibrary.Glossary;
using System.Collections.Generic;
using System.Linq;

namespace HangmanLibrary.Components
{
    public class WordsProvider : IWordsProvider
    {
        public IGlossary Glossary { get; }
        public List<string> WordsList { get; set; }

        public WordsProvider(IGlossary glossary)
        {
            Glossary = glossary;
            WordsList = glossary.Words.ToList();
        }

        public void AddWord(string word) => Glossary.AddWord(word);
    }
}
