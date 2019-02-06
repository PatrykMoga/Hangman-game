using System;
using System.Collections.Generic;
using System.Text;

namespace HangmanLibrary.Models
{
    public interface IEliminable
    {
        List<string> WordsBuffer { get; }
        int WordLength { get; set; }
        void LoadWords(int length);
    }
}
