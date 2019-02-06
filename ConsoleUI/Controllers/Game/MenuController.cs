using ConsoleUI.Views.Game;
using HangmanLibrary.FileGlossary;
using HangmanLibrary.Models;
using static System.Console;

namespace ConsoleUI.Controllers.Game
{
    public class MenuController
    {
        private MenuView _menuView;
        private IGlossary _glossary;

        public MenuController()
        {
            _menuView = new MenuView();

            //Temporarily solution
            _glossary = new FileGlossary();
        }

        public void ShowMenu()
        {
            while (true)
            {
                if (_glossary.BeenUpdated)
                {
                    //Temporarily solution
                    LoadGlossary(new FileGlossary());
                    _glossary.BeenUpdated = false;
                }
                Clear();
                _menuView.Description();
                var input = ReadLine();
                if (input.Equals("1"))
                {
                    var game = new VsComputer(_glossary, 12);
                    var view = new VsComputerView(game);
                    var controller = new VsComputerController(game, view);
                    controller.StartGame();
                }
                if (input.Equals("2"))
                {
                    var game = new VsPlayer(_glossary);
                    var view = new VsPlayerView(game);
                    var controller = new VsPlayerController(game, view);
                    controller.StartGame();
                }
                if (input.Equals("9"))
                {
                    Clear();
                    WriteLine("Available soon!");
                    System.Threading.Thread.Sleep(2000);
                }
                if (input.Equals("0"))
                {
                    Clear();
                    WriteLine("Available soon!");
                    System.Threading.Thread.Sleep(2000);
                }
            }
        }

        private void LoadGlossary(IGlossary glossary) => _glossary = glossary;
    }
}
