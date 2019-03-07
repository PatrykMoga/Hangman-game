using HangmanLibrary.Components;
using HangmanLibrary.Games;
using HangmanLibrary.Glossary;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    public class Application
    {
        private IGlossary _glossary;
        private IVsComputerController _vsComputerController;
        public Application(IGlossary glossary, IVsComputerController vsComputerController)
        {
            _glossary = glossary;        
            _vsComputerController = vsComputerController;
        }

        public void Run()
        {
            _vsComputerController.StartGame();
            
        }
    }
}
