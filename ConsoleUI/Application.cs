using HangmanLibrary.Glossary;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    public class Application
    {
        private IGlossary _glossary;
        public Application(IGlossary glossary)
        {
            _glossary = glossary;
        }

        public void Run()
        {
            Console.WriteLine("Running");
            Console.WriteLine(_glossary.BeenUpdated);
        }
    }
}
