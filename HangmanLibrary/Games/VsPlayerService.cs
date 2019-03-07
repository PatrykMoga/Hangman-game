using System;
using System.Collections.Generic;
using System.Text;

namespace HangmanLibrary.Components
{
    public class VsPlayerService
    {
        private VsPlayer _vsPlayer;

        public VsPlayerService(VsPlayer vsPlayer)
        {
            _vsPlayer = vsPlayer;
        }

        public void Do()
        {
            Console.WriteLine(_vsPlayer.WordLength); 
        }
    }
}
