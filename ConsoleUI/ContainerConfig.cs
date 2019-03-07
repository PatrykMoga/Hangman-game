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
            builder.RegisterType<WordsProvider>().SingleInstance();
            builder.RegisterType<VsPlayerService>();
            builder.RegisterType<VsPlayer>();            
            builder.RegisterType<VsComputer>()
                //.As<IVsComputer>()
                .As<IVsComputer>()
                //.As<IHasKeyword>()
                .SingleInstance();
            builder.RegisterType<VsComputerService>();           
            builder.RegisterType<KeywordAssembler>().As<IKeywordAssembler>();
            builder.RegisterType<LifeController>().As<ILifeController>();


            return builder.Build();
        }
    }
}
