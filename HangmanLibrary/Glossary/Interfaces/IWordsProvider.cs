using System.Collections.Generic;

namespace HangmanLibrary.Glossary
{
    public interface IWordsProvider
    {
        IGlossary Glossary { get; }
        List<string> WordsList { get; set; }

        void AddWord(string word);
    }
}