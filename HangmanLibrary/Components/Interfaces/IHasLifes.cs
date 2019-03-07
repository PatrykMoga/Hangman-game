using System;
using System.Collections.Generic;
using System.Text;

namespace HangmanLibrary.Components
{
    public interface IHasLifes
    {
        int Lifes { get; set; }
        bool HasLifes { get; }
    }
}
