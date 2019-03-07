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
        private MenuController _menuController;

        public Application(MenuController menuController)
        {
            _menuController = menuController;
        }
        public void Run()
        {
            _menuController.ShowMenu();
        }
    }
}
