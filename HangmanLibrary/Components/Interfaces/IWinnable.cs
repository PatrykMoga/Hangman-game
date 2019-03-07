namespace HangmanLibrary.Components
{
    public interface IWinnable
    {
        bool Won { get; set; }
        void WinGame();
    }
}