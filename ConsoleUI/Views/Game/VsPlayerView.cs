using HangmanLibrary.Models;
using System.Text;
using static System.Console;

namespace ConsoleUI.Views.Game
{
    public class VsPlayerView
    {
        private readonly VsPlayer _game;
        private readonly StringBuilder _description;

        public VsPlayerView(VsPlayer game)
        {
            _game = game;
            _description = new StringBuilder();
  
            _description.AppendLine("In this game mode, the computer tries to guess your word.");
            _description.AppendLine("Think up your word and start when you're ready!");          
        }

        public void Description() => WriteLine(_description);

        public void ReadLength() => Write("Enter a word length (including white space): ");

        public void WordMissing() => WriteLine("This glossary does not contain this word.\n");

        public void DisplayLength() => WriteLine($"I'm looking for a word with a {_game.WordLength} length.\n");

        public void AskForIndex(char ch) => WriteLine($"In which index your word contains: \"{ch}\" (Starting with 0)?");

        public void AskIfContain(char ch) => WriteLine($"Does your word contain \"{ch}\"? (Y)");

        public void AskIfWordsMatch(string word) => WriteLine($"Is you word \"{word}\" (Y)");    

        public void AskIfAddWord() => WriteLine("Do you want to add a new word to the glossary? (Y)");

        public void AddingWord() => Write("Enter a new word: ");
    }
}
