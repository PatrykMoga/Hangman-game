using System.Collections.Generic;
using HangmanLibrary.Glossary;

namespace HangmanLibrary.Components
{
    public interface IWordsProvider
    {
        IGlossary Glossary { get; }
        List<string> WordsList { get; set; }

        void AddWord(string word);
    }
}