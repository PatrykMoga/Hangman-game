using HangmanLibrary.Games.VsPlayer;
using System;
using static System.Console;

namespace ConsoleUI.Controllers
{
    public class VsPlayerController : IVsPlayerController
    {
        public IVsPlayerProvider GameProvider { get; }

        public VsPlayerController(IVsPlayerProvider provider)
        {
            GameProvider = provider;
        }

        public void StartGame()
        {
            while (true)
            {
                Clear();
                WriteLine("In this game mode, the computer tries to guess your word.");
                WriteLine("Think up your word and start when you're ready!\n");
                Write("Enter a word length (including white space): ");
                var input = ReadLine();
                if (int.TryParse(input, out int lenght))
                {
                    GameProvider.BufferManager.LoadWords(lenght, GameProvider.WordsProvider.WordsList);
                    Clear();
                    break;
                }
            }

            GameProvider.CharacterManager.UpdateAvailableCharacters();

            while (true)
            {
                if (GameProvider.BufferManager.NoWordsLeft)
                {
                    Clear();
                    WriteLine("This glossary does not contain this word.\n");                    
                    AddNewWord();
                    break;
                }

                if (GameProvider.BufferManager.OneWordLeft)
                {
                    Clear();
                    WriteLine($"Is you word \"{GameProvider.BufferManager.GetWord()}\" (Y)");
                    var input = ReadLine();
                    if (Confirm(input))
                    {
                        break;
                    }
                    else
                    {
                        AddNewWord();
                        break;
                    }
                }

                if (GameProvider.CharacterManager.AreCharactersAvailable)
                {
                    Clear();
                    var randomCharacter = GameProvider.CharacterManager.GetRandomCharacter();
                    WriteLine($"I'm looking for your word...\n");
                    WriteLine($"Does your word contain \"{randomCharacter}\"? (Y)");
                    var input = ReadLine();

                    CheckIfContains(randomCharacter, input);

                }
                if (!GameProvider.CharacterManager.AreCharactersAvailable)
                {
                    Clear();
                    foreach (var ch in GameProvider.CharacterManager.UsedCharacters)
                    {
                        WriteLine($"In which index your word contains: \"{ch}\" (Starting with 0)?");
                        while (true)
                        {
                            var input = ReadLine();
                            if (int.TryParse(input, out int index))
                            {
                                GameProvider.WordsEliminator.EliminateWords(ch, index);
                                break;
                            }
                        }
                        if (GameProvider.BufferManager.OneWordLeft || GameProvider.BufferManager.NoWordsLeft)
                        {
                            break;
                        }
                    }
                }
            }
        }

        private void AddNewWord()
        {
            WriteLine("Do you want to add a new word to the glossary? (Y)");
            var input = ReadLine();
            if (Confirm(input))
            {
                Write("Enter a new word: ");
                var word = ReadLine();
                GameProvider.WordsProvider.AddWord(input);
            }
        }
        private void CheckIfContains(char randomCharacter, string input)
        {
            var doesContain = Confirm(input);

            GameProvider.WordsEliminator.EliminateWords(randomCharacter, doesContain);
            GameProvider.CharacterManager.UpdateAllCharacters(randomCharacter, doesContain);
        }

        private bool Confirm(string input) => input.Equals("y", StringComparison.OrdinalIgnoreCase);
    }
}
