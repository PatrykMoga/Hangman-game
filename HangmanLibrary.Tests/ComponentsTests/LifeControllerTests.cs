using Autofac.Extras.Moq;
using HangmanLibrary.Components;
using NUnit.Framework;

namespace HangmanLibrary.Tests.ComponentsTests
{
    [TestFixture]
    public class LifeControllerTests
    {
        private WordsProvider _provider;

        [SetUp]
        public void SetUp()
        {
            _provider = new WordsProvider();
        }

        [Test]
        [TestCase(9,8)]
        [TestCase(10,9)]
        public void PlayerMissed_WhenCalled_DecreaseLifesCount(int lifesCount, int expected)
        {
            using(var mock = AutoMock.GetLoose())
            {
                mock.Mock<IHasLifes>()
                    .Setup(m => m.Lifes).Returns(lifesCount);
              
                mock.Create<LifeController>()
                    .PlayerMissed("a");

                mock.Mock<IHasLifes>()
                    .VerifySet(m => m.Lifes = expected);
            }
        }

        [Test]
        [TestCase('c')]
        [TestCase('d')]
        [TestCase('x')]
        public void PlayerMissed_WhenCalled_AddCharacterToMissplaced(char c)
        {
            using (var mock = AutoMock.GetLoose())
            {
                var lifeController = mock.Create<LifeController>();
                lifeController.PlayerMissed(c.ToString());
                Assert.That(lifeController.Missplaced.Contains(c));
            }

        }
    }
}
