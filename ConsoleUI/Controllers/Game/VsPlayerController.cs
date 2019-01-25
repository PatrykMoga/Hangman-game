using ConsoleUI.Views.Game;
using HangmanLibrary.Models;
using System;
using static System.Console;

namespace ConsoleUI.Controllers.Game
{
    public class VsPlayerController
    {
        private VsPlayer _game;
        private VsPlayerView _view;

        public VsPlayerController(VsPlayer game, VsPlayerView view)
        {
            _game = game;
            _view = view;
        }

        public void StartGame()
        {
            while (true)
            {
                Clear();
                _view.Description();
                _view.ReadLength();
                var input = ReadLine();
                if (int.TryParse(input, out int lenght))
                {
                    _game.LoadWords(lenght);
                    Clear();
                    break;
                }
            }

            _game.UpdateAvailableCharacters();

            while (true)
            {                
                if (_game.NoWordsLeft)
                {
                    Clear();
                    _view.WordMissing();                  
                    _view.AskIfAddWord();

                    var input = ReadLine();
                    if (_game.Confirmation(input))
                    {
                        _view.AddingWord();
                        var word = ReadLine();
                        _game.AddWord(input);

                    }
                    break;
                }

                if (_game.OneWordLeft)
                {
                    Clear();
                    _view.AskIfWordsMatch(_game.GetWord());
                    var input = ReadLine();
                    if (_game.Confirmation(input))
                    {
                        break;
                    }
                    else
                    {
                        _view.AskIfAddWord();
                        input = ReadLine();
                        if (_game.Confirmation(input))
                        {
                            _view.AddingWord();
                            var word = ReadLine();
                            _game.AddWord(word);
                        }
                        break;
                    }                 
                }

                if (_game.CharactersAreAvailable)
                {
                    Clear();
                    var randomCharacter = _game.GetRandomCharacter();
                    _view.DisplayLength();
                    _view.AskIfContain(randomCharacter);
                    var input = ReadLine();

                    _game.CheckIfContains(randomCharacter, input);
                    
                }
                if (!_game.CharactersAreAvailable)
                {
                    Clear();
                    foreach (var ch in _game.UsedCharacters)
                    {
                        _view.DisplayLength();
                        _view.AskForIndex(ch);
                        var input = ReadLine();
                        _game.EliminateWords(ch, int.Parse(input));
                        if (_game.OneWordLeft || _game.NoWordsLeft)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}
