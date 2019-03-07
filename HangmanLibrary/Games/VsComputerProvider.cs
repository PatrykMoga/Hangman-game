namespace HangmanLibrary.Components
{
    public class VsComputerProvider : IVsComputerProvider
    {
        public VsComputer Game { get; }
        public IWordsProvider WordsProvider { get; }
        public IKeywordAssembler KeywordAssembler { get; }
        public ILifeController LifeController { get; }

        public void PlayerHit(string input) => KeywordAssembler.UpdateAssembler(input);
        public bool WordsMatched => Game.Keyword == KeywordAssembler.Assembler.ToString();

        public VsComputerProvider(VsComputer vsComputer, IWordsProvider wordsProvider,
            IKeywordAssembler keywordAssembler, ILifeController lifeController)
        {
            Game = vsComputer;
            WordsProvider = wordsProvider;
            Game.Keyword = WordsProvider.Words.GetRandomElement();
            KeywordAssembler = keywordAssembler;
            KeywordAssembler.UpdateAssembler();
            LifeController = lifeController;
        }
    }
}
