using HangmanLibrary.Games.VsPlayer;

namespace ConsoleUI.Controllers
{
    public interface IVsPlayerController
    {
        IVsPlayerProvider GameProvider { get; }

        void StartGame();
    }
}