using System.Collections.Generic;

namespace HangmanLibrary.Components
{
    public interface ILifeController
    {
        IHasLifes HasLifes { get; }
        HashSet<char> Missplaced { get; set; }
        
        void PlayerMissed(string input);
    }
}