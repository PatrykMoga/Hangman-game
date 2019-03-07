using System.Collections.Generic;

namespace HangmanLibrary.Components
{
    public class LifeController : ILifeController
    {
        public IHasLifes HasLifes { get;}
        public HashSet<char> Missplaced { get; set; }

        public LifeController(IHasLifes hasLifes)
        {
            HasLifes = hasLifes;
            HasLifes.Lifes = 12;
            Missplaced = new HashSet<char>();
        }

        public void PlayerMissed(string input)
        {
            Missplaced.Add(input[0]);
            HasLifes.Lifes--;
        }
    }
}
