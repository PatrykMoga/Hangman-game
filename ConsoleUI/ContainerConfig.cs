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
            builder.RegisterType<KeywordAssembler>().As<IKeywordAssembler>();
            builder.RegisterType<LifeController>().As<ILifeController>();
            builder.RegisterType<CharacterManager>().As<ICharacterManager>();
            builder.RegisterType<WordsEliminator>().As<IWordsEliminator>();
            builder.RegisterType<BufferManager>().As<IBufferManager>();

            builder.RegisterType<Menu>();
            builder.RegisterType<MenuController>();
            builder.RegisterType<MenuItem>();
            builder.RegisterType<MenuService>();
            return builder.Build();
        }
    }
}
