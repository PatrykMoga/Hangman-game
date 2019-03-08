using Autofac.Extras.Moq;
using HangmanLibrary.Components;
using NUnit.Framework;

namespace HangmanLibrary.Tests.ComponentsTests
{
    [TestFixture]
    public class CharacterManagerTests
    {
        private WordsProvider _provider;

        [SetUp]
        public void SetUp()
        {
            _provider = new WordsProvider();
        }
        [Test]
        public void UpdateAvailableCharacters_WhenCalled_GetAllAvailbleCharactersAndPlaceInTheList()
        {
            using(var mock = AutoMock.GetLoose())
            {
                mock.Mock<IHasBuffer>()
                    .Setup(m => m.WordsBuffer).Returns(_provider.Words);
            }
        }
    }
}
