using System.Collections.Generic;
using HangmanLibrary.Glossary;

namespace HangmanLibrary.Components
{
    public interface IWordsProvider
    {
        IGlossary Glossary { get; }
        List<string> Words { get; set; }

        void AddWord(string word);
    }
}