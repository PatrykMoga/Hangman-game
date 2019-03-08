namespace HangmanLibrary.Components
{
    public interface IWordsEliminator
    {
        IHasBuffer HasBuffer { get; }

        void EliminateWords(char ch, bool containCharacter);
        void EliminateWords(char ch, int index);
    }
}