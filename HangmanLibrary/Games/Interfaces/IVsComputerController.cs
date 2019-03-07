namespace HangmanLibrary.Components
{
    public interface IVsComputerController
    {
        IVsComputerProvider Provider { get; }

        void StartGame();
    }
}