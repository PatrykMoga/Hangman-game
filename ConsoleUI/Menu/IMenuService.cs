using System.Collections.Generic;

namespace ConsoleUI
{
    public interface IMenuService
    {
        Dictionary<int, MenuItem> MenuItems { get; set; }

        void AddComponent(MenuItem component);
        void ExecuteComponent(string actionKey);
        void PrintMenu();
    }
}