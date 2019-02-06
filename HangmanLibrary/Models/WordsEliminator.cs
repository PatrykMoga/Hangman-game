using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangmanLibrary.Models
{
    public class WordsEliminator
    {
        private readonly IEliminable _eliminable;

        public WordsEliminator(IEliminable eliminable) => _eliminable = eliminable;

        public void EliminateWords(char ch, bool ifContainsCharacter)
        {
            if (ifContainsCharacter)
            {
                _eliminable.WordsBuffer.RemoveAll(w => !w.Contains(ch));
            }
            else
            {
                _eliminable.WordsBuffer.RemoveAll(w => w.Contains(ch));
            }
        }

        public void EliminateWords(char ch, int index) => _eliminable.WordsBuffer.RemoveAll(w => w[index] != ch);
    }
}
