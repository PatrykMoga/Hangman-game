using Autofac;
using HangmanLibrary.Components;
using HangmanLibrary.Glossary;

namespace ConsoleUI
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Application>();
            builder.RegisterType<FileGlossary>().As<IGlossary>().SingleInstance();
            builder.RegisterType<WordsProvider>().As<IWordsProvider>().SingleInstance();                     
            builder.RegisterType<VsComputer>().AsSelf()
                .As<IHasKeyword>().As<IHasLifes>().SingleInstance();
            builder.RegisterType<VsComputerProvider>().As<IVsComputerProvider>();
            builder.RegisterType<VsComputerController>().As<IVsComputerController>();
            builder.RegisterType<VsPlayer>();
            builder.RegisterType<VsPlayerService>();            
            builder.RegisterType<KeywordAssembler>().As<IKeywordAssembler>();
            builder.RegisterType<LifeController>().As<ILifeController>();
            return builder.Build();
        }
    }
}
