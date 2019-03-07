using static System.Console;

namespace HangmanLibrary.Components
{
    public class VsComputerController : IVsComputerController
    {
        public IVsComputerProvider Provider { get; }

        public VsComputerController(IVsComputerProvider provider)
        {
            Provider = provider;
        }

        public void StartGame()
        {
            while (Provider.Game.HasLifes)
            {
                Clear();
                WriteLine("In this game mode you have to guess the word randomly selected by the computer.");
                WriteLine("You can type a character or whole word. Every time you miss you lose one life.");
                WriteLine("The game will end when you guess the word or lose all lifes.");

                WriteLine($"\nYou have {Provider.Game.Lifes} lifes left!");
                Write("\nMissplaced characters: ");

                if (Provider.LifeController.Missplaced.Count > 0)
                {
                    foreach (var item in Provider.LifeController.Missplaced)
                    {
                        Write($"{item} ");
                    }
                }

                var HiddenKeywordView = string.Join(" ", Provider.KeywordAssembler.ToString());
                WriteLine($"\n\n {HiddenKeywordView}\n");

                if (Provider.WordsMatched)
                {
                    Provider.Game.WinGame();
                    break;
                }
                var input = ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    if (Provider.Game.PlayerEnteredKeyword(input))
                    {
                        Provider.Game.WinGame();
                        break;
                    }

                    if (Provider.Game.KeywordContain(input[0]))
                    {
                        Provider.PlayerHit(input);
                    }
                    else
                    {
                        Provider.LifeController.PlayerMissed(input);
                    }
                }
            }
            WriteLine(Provider.Game.Won ? "Congratulations you won!" : $"Unfortunately you lost. The keyword was: \"{Provider.Game.Keyword}\"");
            ReadKey();
        }
    }
}