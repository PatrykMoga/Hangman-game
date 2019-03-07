using HangmanLibrary.Components;

namespace HangmanLibrary.Games
{
    public interface IVsComputerProvider
    {
        VsComputer Game { get; }
        IKeywordAssembler KeywordAssembler { get; }
        ILifeController LifeController { get; }
        bool WordsMatched { get; }
        IWordsProvider WordsProvider { get; }

        void PlayerHit(string input);
    }
}