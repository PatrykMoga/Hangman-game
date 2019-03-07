using System.Collections.Generic;

namespace HangmanLibrary.Components
{
    public interface ILifeController
    {
        IVsComputer HasLifes { get; }
        HashSet<char> Missplaced { get; set; }
        
        void PlayerMissed(string input);
    }
}