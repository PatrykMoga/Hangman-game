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
        private VsComputerService _VsComputerService;
        public Application(IGlossary glossary, VsPlayerService vsPlayerService, VsComputerService vsComputerService)
        {
            _glossary = glossary;
            _vsPlayerService = vsPlayerService;
            _VsComputerService = vsComputerService;
        }

        public void Run()
        {
            _VsComputerService.StartGame();
            
        }
    }
}
