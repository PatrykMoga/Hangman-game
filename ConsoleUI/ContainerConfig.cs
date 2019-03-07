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
            builder.RegisterType<FileGlossary>().As<IGlossary>().SingleInstance();
            builder.RegisterType<WordsProvider>().As<IWordsProvider>().SingleInstance();                                     
            builder.RegisterType<KeywordAssembler>().As<IKeywordAssembler>();
            builder.RegisterType<LifeController>().As<ILifeController>();
            builder.RegisterType<CharacterManager>().As<ICharacterManager>();
            builder.RegisterType<WordsEliminator>().As<IWordsEliminator>();
            builder.RegisterType<BufferManager>().As<IBufferManager>();

            builder.RegisterType<MenuController>().As<IMenuController>();           
            builder.RegisterType<MenuService>().As<IMenuService>();
            builder.RegisterType<MenuItem>();
            return builder.Build();
        }
    }
}
