using System.Collections.Generic;

namespace HangmanLibrary.Components
{
    public interface ICharacterManager
    {
        HashSet<char> AvailableCharacters { get; }
        bool CharactersAreAvailable { get; }
        IHasBuffer HasBuffer { get; }
        HashSet<char> UsedCharacters { get; }

        char GetRandomCharacter();
        void UpdateAllCharacters(char ch, bool ifContainsCharacter);
        void UpdateAvailableCharacters();
    }
}