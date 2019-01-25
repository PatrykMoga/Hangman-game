using HangmanLibrary.Extensions;
using HangmanLibrary.FileGlossary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HangmanLibrary.Models
{
    public class VsPlayer : Game
    {
        public int WordLength { get; set; }
        public List<string> WordsBuffer { get; }
        public HashSet<char> AvailableCharacters { get; }
        public HashSet<char> UsedCharacters { get; }

        public VsPlayer(IGlossary glossary) : base(glossary)
        {
            WordsBuffer = new List<string>();
            AvailableCharacters = new HashSet<char>();
            UsedCharacters = new HashSet<char>();
        }

        public string GetWord() => WordsBuffer[0];

        private void UpdateAllCharacters(char ch, bool ifContainsCharacter)
        {
            if (ifContainsCharacter)
            {
                UsedCharacters.Add(ch);
            }
            AvailableCharacters.Clear();
            UpdateAvailableCharacters();
            UsedCharacters.ToList().ForEach(c => AvailableCharacters.Remove(c));
        }

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

        private void EliminateWords(char ch, bool ifContainsCharacter)
        {
            if (ifContainsCharacter)
            {
                WordsBuffer.RemoveAll(w => !w.Contains(ch));
            }
            else
            {
                WordsBuffer.RemoveAll(w => w.Contains(ch));
            }
        }

        public void EliminateWords(char ch, int index) => WordsBuffer.RemoveAll(w => w[index] != ch);

        public void RemoveCharacter(char ch) => AvailableCharacters.Remove(ch);

        public void UpdateAvailableCharacters()
        {
            for (int i = 0; i < WordsBuffer.Count; i++)
            {
                for (int j = 0; j < WordsBuffer[i].Length; j++)
                {
                    AvailableCharacters.Add(WordsBuffer[i][j]);
                }
            }
        }

        public char GetRandomCharacter() => AvailableCharacters.ToList().GetRandomElement();

        public bool OneWordLeft => WordsBuffer.Count == 1;

        public bool NoWordsLeft => WordsBuffer.Count == 0;

        public bool CharactersAreAvailable => AvailableCharacters.Count > 0;

        public bool Confirmation(string input) => input.Equals("y", StringComparison.OrdinalIgnoreCase);

        public void CheckIfContains(char randomCharacter, string input)
        {
            var ifContains = Confirmation(input);

            EliminateWords(randomCharacter, ifContains);
            UpdateAllCharacters(randomCharacter, ifContains);
        }       
    }
}
