using Autofac;
using ConsoleUI.Controllers;
using HangmanLibrary.Components;
using HangmanLibrary.Games.VsComputer;
using HangmanLibrary.Games.VsPlayer;
using HangmanLibrary.Glossary;

namespace ConsoleUI
{
    public class Menu
    {
        public IGlossary Glossary { get; }
      

        public Menu(IGlossary glossary)
        {
            Glossary = glossary; 
        }

        public void VsComputerScope()
        {
            var container = ContainerConfig.Configure();
            using (var scope = container.BeginLifetimeScope(builder =>
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

        public void VsPlayerScope()
        {
            var container = ContainerConfig.Configure();
            using (var scope = container.BeginLifetimeScope(builder =>
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
