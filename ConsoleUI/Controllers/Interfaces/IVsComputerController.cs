using HangmanLibrary.Games.VsComputer;

namespace ConsoleUI.Controllers
{
    public interface IVsComputerController 
    {
        IVsComputerProvider GameProvider { get; }
        void StartGame();
    }
}