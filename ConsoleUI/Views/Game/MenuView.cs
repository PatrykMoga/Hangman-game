using System.Text;
using static System.Console;

namespace ConsoleUI.Views.Game
{
    public class MenuView
    {
        private readonly StringBuilder _viewDesription;

        public MenuView()
        {
            _viewDesription = new StringBuilder();
            _viewDesription.AppendLine("Welcome in the Hangman game! Chose game type or option: \n");
            _viewDesription.AppendLine("1: Player VS Computer");
            _viewDesription.AppendLine("2: Computer VS Player");
            _viewDesription.AppendLine("\n9: Translation options");      
            _viewDesription.AppendLine("0: Glossary options");      
        }

        public void Description() => WriteLine(_viewDesription);
    }
}
