using HangmanLibrary.Components;
using HangmanLibrary.Glossary;

namespace HangmanLibrary.Games.VsPlayer
{
    public interface IVsPlayerProvider
    {
        IBufferManager BufferManager { get; }
        ICharacterManager CharacterManager { get; }
        VsPlayer Game { get; }
        IWordsEliminator WordsEliminator { get; }
        IWordsProvider WordsProvider { get; }
    }
}