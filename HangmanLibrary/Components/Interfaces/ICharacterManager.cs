﻿using System.Collections.Generic;

namespace HangmanLibrary.Components
{
    public interface ICharacterManager
    {
        HashSet<char> AvailableCharacters { get; }
        bool AreCharactersAvailable { get; }
        IHasBuffer HasBuffer { get; }
        HashSet<char> UsedCharacters { get; }

        char GetRandomCharacter();
        void RemoveUsed(char ch, bool containCharacter);
        void UpdateAvailableCharacters();
    }
}