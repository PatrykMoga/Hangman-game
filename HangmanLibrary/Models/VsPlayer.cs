using HangmanLibrary.Extensions;
using HangmanLibrary.FileGlossary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HangmanLibrary.Models
{
    public class VsPlayer : Game, IEliminable
    {
        public int WordLength { get; set; }
        public List<string> WordsBuffer { get; }

        public CharacterUpdater CharacterUpdater { get; set; }
        public WordsEliminator WordsEliminator { get; }

        public VsPlayer(IGlossary glossary) : base(glossary)
        {
            WordsBuffer = new List<string>();

            CharacterUpdater = new CharacterUpdater(this);
            WordsEliminator = new WordsEliminator(this);
        }

        public string GetWord() => WordsBuffer[0];      

        public void LoadWords(int length)
        {
            foreach (var word in Words)
            {
                if (word.Length == length)
                {
                    WordsBuffer.Add(word);
                }
            }

            WordLength = length;
        }

        public char GetRandomCharacter() => CharacterUpdater.AvailableCharacters.ToList().GetRandomElement();

        public bool OneWordLeft => WordsBuffer.Count == 1;

        public bool NoWordsLeft => WordsBuffer.Count == 0;

        public bool CharactersAreAvailable => CharacterUpdater.AvailableCharacters.Count > 0;

        public bool Confirmation(string input) => input.Equals("y", StringComparison.OrdinalIgnoreCase);

        public void CheckIfContains(char randomCharacter, string input)
        {
            var ifContains = Confirmation(input);

            WordsEliminator.EliminateWords(randomCharacter, ifContains);
            CharacterUpdater.UpdateAllCharacters(randomCharacter, ifContains);
        }       
    }
}
