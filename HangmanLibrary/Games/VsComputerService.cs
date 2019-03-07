using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace HangmanLibrary.Components
{
    public class VsComputerService
    {
        private IVsComputer _game;
        private WordsProvider _wordsProvider;
        private IKeywordAssembler _keywordAssembler;
        private ILifeController _lifeController;

        public void PlayerHit(string input) => _keywordAssembler.UpdateAssembler(input);
        public bool WordsMatched => _game.Keyword == _keywordAssembler.Assembler.ToString();


        public VsComputerService(IVsComputer vsComputer, WordsProvider wordsProvider,
            IKeywordAssembler keywordAssembler, ILifeController lifeController)
        {
            _game = vsComputer;           
            _wordsProvider = wordsProvider;
            _game.Keyword = _wordsProvider.Words.GetRandomElement();
            _keywordAssembler = keywordAssembler;
            _keywordAssembler.UpdateAssembler();
            _lifeController = lifeController;
        }

        public void StartGame()
        {
            while (_game.HasLifes)
            {
                Clear();
                WriteLine("In this game mode you have to guess the word randomly selected by the computer.");
                WriteLine("You can type a character or whole word. Every time you miss you lose one life.");
                WriteLine("The game will end when you guess the word or lose all lifes.");

                WriteLine($"You have {_game.Lifes} lifes left!");
                Write("\nMissplaced characters: ");

                if (_lifeController.Missplaced.Count > 0)
                {
                    foreach (var item in _lifeController.Missplaced)
                    {
                        Write($"{item} ");
                    }
                }

                var HiddenKeywordView = string.Join(" ", _keywordAssembler.ToString());
                WriteLine($"\n\n {HiddenKeywordView}\n");

                if (WordsMatched)
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
                        PlayerHit(input);
                    }
                    else
                    {
                        _lifeController.PlayerMissed(input);
                    }
                }
            }
            WriteLine(_game.Won ? "Congratulations you won!" : $"Unfortunately you lost. The keyword was: \"{_game.Keyword}\"");
            ReadKey();
        }        
    }
}
