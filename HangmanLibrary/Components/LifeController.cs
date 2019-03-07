using System;
using System.Collections.Generic;
using System.Text;

namespace HangmanLibrary.Components
{
    public class LifeController : ILifeController
    {
        public IVsComputer HasLifes { get;}
        public HashSet<char> Missplaced { get; set; }

        public LifeController(IVsComputer hasLifes)
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
