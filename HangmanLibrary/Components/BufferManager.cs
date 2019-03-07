using System.Collections.Generic;

namespace HangmanLibrary.Components
{
    public class BufferManager : IBufferManager
    {
        public IHasBuffer HasBuffer { get; }

        public BufferManager(IHasBuffer hasBuffer)
        {
            HasBuffer = hasBuffer;
        }

        public void LoadWords(int length, IEnumerable<string> Words)
        {
            foreach (var word in Words)
            {
                if (word.Length == length)
                {
                    HasBuffer.WordsBuffer.Add(word);
                }
            }
        }

        public string GetWord() => HasBuffer.WordsBuffer[0];
        public bool OneWordLeft => HasBuffer.WordsBuffer.Count == 1;
        public bool NoWordsLeft => HasBuffer.WordsBuffer.Count == 0;
    }
}
