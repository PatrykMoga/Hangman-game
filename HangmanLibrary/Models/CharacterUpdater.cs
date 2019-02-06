using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangmanLibrary.Models
{
    public class CharacterUpdater
    {
        private readonly IEliminable _eliminable;

        public HashSet<char> AvailableCharacters { get; }
        public HashSet<char> UsedCharacters { get; }

        public CharacterUpdater(IEliminable eliminable)
        {
            _eliminable = eliminable;

            AvailableCharacters = new HashSet<char>();
            UsedCharacters = new HashSet<char>();
        }

        public void UpdateAllCharacters(char ch, bool ifContainsCharacter)
        {
            if (ifContainsCharacter)
            {
                UsedCharacters.Add(ch);
            }
            AvailableCharacters.Clear();
            UpdateAvailableCharacters();
            UsedCharacters.ToList().ForEach(c => AvailableCharacters.Remove(c));
        }

        public void UpdateAvailableCharacters()
        {
            for (int i = 0; i < _eliminable.WordsBuffer.Count; i++)
            {
                for (int j = 0; j < _eliminable.WordsBuffer[i].Length; j++)
                {
                    AvailableCharacters.Add(_eliminable.WordsBuffer[i][j]);
                }
            }
        }
    }
}
