using HangmanLibrary.Games;
using HangmanLibrary.Glossary;
using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using static System.Console;
using HangmanLibrary.Components;

namespace ConsoleUI
{
    public class MenuController
    {
        public Menu Menu { get; }
        public MenuService MenuService { get; }

        public MenuController(Menu menu, MenuService menuService)
        {
            Menu = menu;
            MenuService = menuService;

            MenuService.AddComponent(new MenuItem("Player VS Computer", Menu.VsComputerScope));
            MenuService.AddComponent(new MenuItem("Computer VS Player", Menu.VsPlayerScope));

        }       

        public void ShowMenu()
        {
            while (true)
            {
                WriteLine("Welcome in the Hangman game! Chose game type or option: \n");
                MenuService.PrintMenu();
            }
        }
    }
}
