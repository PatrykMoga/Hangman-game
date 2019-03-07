namespace HangmanLibrary.Games
{
    public interface IVsComputerController
    {
        IVsComputerProvider Provider { get; }

        void StartGame();
    }
}