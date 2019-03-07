using HangmanLibrary.Games; // temp
using System.Collections.Generic;
using System.Linq;

namespace HangmanLibrary.Components
{
    public class CharacterUpdater
    {
        private VsPlayer _vsComputer;

        public HashSet<char> AvailableCharacters { get; }
        public HashSet<char> UsedCharacters { get; }

        public CharacterUpdater(VsPlayer vsComputer)
        {
            _vsComputer = vsComputer;

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
            for (int i = 0; i < _vsComputer.WordsBuffer.Count; i++)
            {
                for (int j = 0; j < _vsComputer.WordsBuffer[i].Length; j++)
                {
                    AvailableCharacters.Add(_vsComputer.WordsBuffer[i][j]);
                }
            }
        }
    }
}