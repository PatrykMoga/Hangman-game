using HangmanLibrary.Games.VsComputer;
using static System.Console;

namespace ConsoleUI.Controllers
{
    public class VsComputerController : IVsComputerController
    {
        public IVsComputerProvider GameProvider { get; }

        public VsComputerController(IVsComputerProvider provider)
        {
            GameProvider = provider;
        }

        public void StartGame()
        {
            while (GameProvider.Game.HasLifes)
            {
                Clear();
                WriteLine("In this game mode you have to guess the word randomly selected by the computer.");
                WriteLine("You can type a character or whole word. Every time you miss you lose one life.");
                WriteLine("The game will end when you guess the word or lose all lifes.");

                WriteLine($"\nYou have {GameProvider.Game.Lifes} lifes left!");
                Write("\nMissplaced characters: ");

                if (GameProvider.LifeController.Missplaced.Count > 0)
                {
                    foreach (var item in GameProvider.LifeController.Missplaced)
                    {
                        Write($"{item} ");
                    }
                }

                var HiddenKeywordView = string.Join(" ", GameProvider.KeywordAssembler.ToString());
                WriteLine($"\n\n {HiddenKeywordView}\n");

                if (GameProvider.WordsMatched)
                {
                    GameProvider.Game.WinGame();
                    break;
                }
                var input = ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    if (GameProvider.Game.PlayerEnteredKeyword(input))
                    {
                        GameProvider.Game.WinGame();
                        break;
                    }

                    if (GameProvider.Game.KeywordContain(input[0]))
                    {
                        GameProvider.PlayerHit(input);
                    }
                    else
                    {
                        GameProvider.LifeController.PlayerMissed(input);
                    }
                }
            }
            WriteLine(GameProvider.Game.Won ? "Congratulations you won!" : $"Unfortunately you lost. The keyword was: \"{GameProvider.Game.Keyword}\"");
            ReadKey();
        }
    }
}