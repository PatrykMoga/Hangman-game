using HangmanLibrary.Models;
using System.Text;
using static System.Console;

namespace ConsoleUI.Views.Game
{
    public class VsComputerView
    {
        private readonly VsComputer _game;
        private readonly StringBuilder _description;
        private readonly StringBuilder _userInterface;

        public VsComputerView(VsComputer game)
        {
            _game = game;
            _description = new StringBuilder();
            _userInterface = new StringBuilder();

            _description.AppendLine("In this game mode you have to guess the word randomly selected by the computer.");
            _description.AppendLine("You can type a character or whole word. Every time you miss you lose one life.");
            _description.AppendLine("The game will end when you guess the word or lose all lifes.");
        }

        public void Description() => WriteLine(_description);

        public void UserInterface()
        {
            _userInterface.Clear();
            _userInterface.AppendLine($"You have {_game.Lifes} lifes left!");
            _userInterface.Append("\nMissplaced characters: ");

            if (_game.Missplaced.Count > 0)
            {
                foreach (var item in _game.Missplaced)
                {
                    _userInterface.Append($"{item} ");
                }
            }
         
            _userInterface.AppendLine("\n\n " + _game.HiddenKeywordView);
            WriteLine(_userInterface);
        }

        public void GameResult()
        {
            WriteLine(_game.Won ? "Congratulations you won!" : $"Unfortunately you lost. The keyword was: \"{_game.Keyword}\"");
        }
    }
}
