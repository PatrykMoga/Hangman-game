using Autofac.Extras.Moq;
using HangmanLibrary.Components;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HangmanLibrary.Tests.ComponentsTests
{
    [TestFixture]
    public class BufferManagerTests
    {
        [Test]
        [TestCase(6, 4)]
        [TestCase(5, 1)]
        [TestCase(8, 2)]
        public void LoadWords_WhenCalled_LoadWordsToBuffer(int wordLenght, int expectedBufferCount)
        {
            using(var mock = AutoMock.GetLoose())
            {
                mock.Mock<IHasBuffer>()
                    .Setup(m => m.WordsBuffer).Returns(new List<string>());

                mock.Create<BufferManager>()
                    .LoadWords(wordLenght, Words);

                var actual = mock.Create<IHasBuffer>().WordsBuffer.Count;

                Assert.That(actual, Is.EqualTo(expectedBufferCount));
            }
        }

        private List<string> Words => new List<string>
        {
            "absorb",
            "abuse",
            "academic",
            "accent",
            "accept",
            "acceptable",
            "access",
            "accident",
            "accidental",
            "accidentally"
        };
    }
}
