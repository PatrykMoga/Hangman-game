using Autofac;
using ConsoleUI.Controllers;
using HangmanLibrary.Components;
using HangmanLibrary.Games.VsComputer;
using HangmanLibrary.Games.VsPlayer;

namespace ConsoleUI
{
    public static class Scopes
    {
        private static IContainer _container = ContainerConfig.Configure();

        public static void VsComputerScope()
        {          
            using (var scope = _container.BeginLifetimeScope(builder =>
            {
                builder.RegisterType<VsComputer>().AsSelf()
                    .As<IHasKeyword>().As<IHasLifes>().SingleInstance();
                builder.RegisterType<VsComputerProvider>().As<IVsComputerProvider>();
                builder.RegisterType<VsComputerController>().As<IVsComputerController>();
            }))
            {
                scope.Resolve<IVsComputerController>().StartGame();
            }
        }

        public static void VsPlayerScope()
        {
            using (var scope = _container.BeginLifetimeScope(builder =>
            {
                builder.RegisterType<VsPlayer>().AsSelf()
                    .As<IHasBuffer>().SingleInstance();
                builder.RegisterType<VsPlayerProvider>().As<IVsPlayerProvider>();
                builder.RegisterType<VsPlayerController>().As<IVsPlayerController>();
            }))
            {
                scope.Resolve<IVsPlayerController>().StartGame();
            }
        }
    }
}
