using Autofac;
using HangmanLibrary.Glossary;

namespace ConsoleUI
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Application>();
            builder.RegisterType<FileGlossary>().As<IGlossary>();


            return builder.Build();
        }
    }
}
