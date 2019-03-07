using System;
using static System.Console;

namespace ConsoleUI
{
    public class MenuController : IMenuController
    {
        public IMenuService MenuService { get; }

        public MenuController(IMenuService menuService)
        {
            MenuService = menuService;

            MenuService.AddComponent(new MenuItem("Player VS Computer", Scopes.VsComputerScope));
            MenuService.AddComponent(new MenuItem("Computer VS Player", Scopes.VsPlayerScope));

            MenuService.AddComponent(new MenuItem("Exit", Exit));
        }       

        public void ShowMenu()
        {
            while (true)
            {
                WriteLine("Welcome in the Hangman game! Chose game type or option: \n");
                MenuService.PrintMenu();
            }
        }

        private void Exit() => Environment.Exit(0);
    }
}
