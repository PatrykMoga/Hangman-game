using ConsoleUI.Views.Game;
using HangmanLibrary.Models;
using static System.Console;

namespace ConsoleUI.Controllers.Game
{
    public class VsComputerController
    {
        private VsComputer _game;
        private VsComputerView _view;

        public VsComputerController(VsComputer game, VsComputerView view)
        {
            _game = game;
            _view = view;
        }

        public void StartGame()
        {
            while (_game.HasLifes)
            {
                Clear();
                _view.Description();
                _view.UserInterface();

                if (_game.WordsMatched)
                {
                    _game.WinGame();
                    break;
                }
                var input = ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    if (_game.PlayerEnteredKeyword(input))
                    {
                        _game.WinGame();
                        break;
                    }

                    if (_game.KeywordContain(input[0]))
                    {
                        _game.PlayerHit(input);
                    }
                    else
                    {
                       _game.PlayerMissed(input);
                    }
                }
            }
            _view.GameResult();
            ReadKey();
        }
    }
}
