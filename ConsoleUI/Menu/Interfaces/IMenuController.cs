namespace ConsoleUI
{
    public interface IMenuController
    {
        IMenuService MenuService { get; }

        void ShowMenu();
    }
}