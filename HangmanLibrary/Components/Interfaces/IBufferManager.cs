using System.Collections.Generic;

namespace HangmanLibrary.Components
{
    public interface IBufferManager
    {
        IHasBuffer HasBuffer { get; }
        bool NoWordsLeft { get; }
        bool OneWordLeft { get; }

        string GetWord();
        void LoadWords(int length, IEnumerable<string> Words);
    }
}