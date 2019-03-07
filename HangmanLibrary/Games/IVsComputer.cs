namespace HangmanLibrary.Components
{
    public interface IVsComputer : IHasKeyword , IHasLifes
    {       
        bool Won { get; set; }       
        void WinGame();
    }
}