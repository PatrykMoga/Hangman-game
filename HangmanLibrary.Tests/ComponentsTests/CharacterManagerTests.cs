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
        public void UpdateAvailableCharacters_WhenCalled_GetAllAvailableCharactersAndPlaceInTheSet()
        {
            using(var mock = AutoMock.GetLoose())
            {
                mock.Mock<IHasBuffer>()
                    .Setup(m => m.WordsBuffer).Returns(_provider.Words);

                var manager = mock.Create<CharacterManager>();
                manager.UpdateAvailableCharacters();

                Assert.That(manager.AvailableCharacters.Count > 0);
            }
        }

        [Test]
        [TestCase('a')]
        [TestCase('s')]
        [TestCase('l')]
        public void RemoveUsed_WhenCalled_RemoveUsedCharactersFromAvailableOne(char c)
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IHasBuffer>()
                    .Setup(m => m.WordsBuffer).Returns(_provider.Words);

                var manager = mock.Create<CharacterManager>();
                manager.RemoveUsed(c, true);

                Assert.That(!manager.AvailableCharacters.Contains(c));
            }
        }
    }
}
