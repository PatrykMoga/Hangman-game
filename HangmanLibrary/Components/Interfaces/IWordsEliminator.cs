namespace HangmanLibrary.Components
{
    public interface IWordsEliminator
    {
        IHasBuffer HasBuffer { get; }

        void EliminateWords(char ch, bool ifContainsCharacter);
        void EliminateWords(char ch, int index);
    }
}