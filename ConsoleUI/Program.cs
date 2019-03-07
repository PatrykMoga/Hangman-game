using Autofac;

namespace ConsoleUI
{
    internal static class Program
    {
        private static void Main()
        {
            var container = ContainerConfig.Configure();
            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<MenuController>();
                app.ShowMenu();
            }
        }
    }
}
