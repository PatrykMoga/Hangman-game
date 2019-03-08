using System.Collections.Generic;
using System.Linq;

namespace HangmanLibrary.Components
{
    public class CharacterManager : ICharacterManager
    {
        public IHasBuffer HasBuffer { get; }

        public HashSet<char> AvailableCharacters { get; }
        public HashSet<char> UsedCharacters { get; }

        public CharacterManager(IHasBuffer hasBuffer)
        {
            HasBuffer = hasBuffer;

            AvailableCharacters = new HashSet<char>();
            UsedCharacters = new HashSet<char>();
        }

        public void UpdateAllCharacters(char ch, bool doesContainCharacter)
        {
            if (doesContainCharacter)
            {
                UsedCharacters.Add(ch);
            }
            AvailableCharacters.Clear();
            UpdateAvailableCharacters();
            UsedCharacters.ToList().ForEach(c => AvailableCharacters.Remove(c));
        }

        public void UpdateAvailableCharacters()
        {
            for (int i = 0; i < HasBuffer.WordsBuffer.Count; i++)
            {
                for (int j = 0; j < HasBuffer.WordsBuffer[i].Length; j++)
                {
                    AvailableCharacters.Add(HasBuffer.WordsBuffer[i][j]);
                }
            }
        }

        public char GetRandomCharacter() => AvailableCharacters.ToList().GetRandomElement();
        public bool CharactersAreAvailable => AvailableCharacters.Count > 0;
    }
}