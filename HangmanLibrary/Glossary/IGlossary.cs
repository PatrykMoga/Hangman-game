using System.Collections.Generic;

namespace HangmanLibrary.Glossary
{
    public interface IGlossary
    {
        HashSet<string> Words { get; set; }
        bool BeenUpdated { get; set; }

        void AddWord(string word);
    }
}