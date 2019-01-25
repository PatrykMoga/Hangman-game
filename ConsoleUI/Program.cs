using ConsoleUI.Controllers.Game;
using static System.Console;

namespace ConsoleUI
{
    static class Program
    {

        static void Main(string[] args)
        {          
            Title = args[0];
            var controller = new MenuController();
            controller.ShowMenu();
        }
    }
}
