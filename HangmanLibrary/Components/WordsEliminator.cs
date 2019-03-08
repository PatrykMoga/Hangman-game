namespace HangmanLibrary.Components
{
    public class WordsEliminator : IWordsEliminator
    {
        public IHasBuffer HasBuffer { get; }

        public WordsEliminator(IHasBuffer hasBuffer)
        {
            HasBuffer = hasBuffer;
        }

        public void EliminateWords(char ch, int index) => HasBuffer.WordsBuffer.RemoveAll(w => w[index] != ch);

        public void EliminateWords(char ch, bool containCharacter)
        {
            if (containCharacter)
            {
                HasBuffer.WordsBuffer.RemoveAll(w => !w.Contains(ch.ToString()));
            }
            else
            {
                HasBuffer.WordsBuffer.RemoveAll(w => w.Contains(ch.ToString()));
            }
        }
    }
}
