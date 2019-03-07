using HangmanLibrary.Components;
using HangmanLibrary.Glossary;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    public class Application
    {
        private IGlossary _glossary;
        private VsPlayerService _vsPlayerService;
        private IVsComputerController _vsComputerController;
        public Application(IGlossary glossary, VsPlayerService vsPlayerService, IVsComputerController vsComputerController)
        {
            _glossary = glossary;
            _vsPlayerService = vsPlayerService;
            _vsComputerController = vsComputerController;
        }

        public void Run()
        {
            _vsComputerController.StartGame();
            
        }
    }
}
