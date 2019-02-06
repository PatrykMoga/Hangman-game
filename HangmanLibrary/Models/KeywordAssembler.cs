using System;
using System.Collections.Generic;
using System.Text;

namespace HangmanLibrary.Models
{
    public class KeywordAssembler
    {
        private readonly IKeywordAssemblable _hideable;
        public StringBuilder Assembler { get; }

        public KeywordAssembler(IKeywordAssemblable hideable)
        {
            _hideable = hideable;
            Assembler = new StringBuilder();

            for (int i = 0; i < _hideable.Keyword.Length; i++)
            {
                if (_hideable.Keyword[i] == ' ')
                {
                    Assembler.Append(' ');
                }
                else
                {
                    Assembler.Append('_');
                }
            }
        }
        public void UpdateAssembler(string input)
        {
            for (int j = 0; j < _hideable.Keyword.Length; j++)
            {
                if (_hideable.Keyword[j] == input[0])
                {
                    Assembler[j] = _hideable.Keyword[j];
                }
            }
        }   
        
        public string bla => string.Join(" ",Assembler.ToString().ToCharArray());
    }
}
