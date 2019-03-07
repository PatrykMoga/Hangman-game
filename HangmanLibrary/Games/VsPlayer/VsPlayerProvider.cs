using HangmanLibrary.Components;

namespace HangmanLibrary.Games.VsPlayer
{
    public class VsPlayerProvider : IVsPlayerProvider
    {
        public VsPlayer Game { get; }
        public IWordsProvider WordsProvider { get; }
        public ICharacterManager CharacterManager { get; }
        public IBufferManager BufferManager { get; }
        public IWordsEliminator WordsEliminator { get;}

        public VsPlayerProvider(VsPlayer game, IWordsProvider wordsProvider, ICharacterManager characterManager,
             IBufferManager bufferManager, IWordsEliminator wordsEliminator)
        {
            Game = game;
            WordsProvider = wordsProvider;
            CharacterManager = characterManager;
            BufferManager = bufferManager;
            WordsEliminator = wordsEliminator;
        }
    }
}
