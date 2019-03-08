﻿using Autofac.Extras.Moq;
using HangmanLibrary.Components;
using NUnit.Framework;
using System.Collections.Generic;

namespace HangmanLibrary.Tests.ComponentsTests
{
    [TestFixture]
    public class WordsEliminatorTests
    {       
        [Test]
        [TestCase('s', true)]
        [TestCase('c', false)]
        [TestCase('b', false)]
        [TestCase('b', true)]
        [TestCase('v', false)]
        [TestCase('o', true)]
        [TestCase('p', true)]
        [TestCase('m', true)]
        public void EliminateWords_KeywordDoesContainCharacter_EliminateAllWordsThatNotContainCharacter(char c, bool eliminate)
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IHasBuffer>()
                    .Setup(m => m.WordsBuffer).Returns(Words);

                mock.Create<WordsEliminator>()
                    .EliminateWords(c, eliminate);

                var wordsBuffer = mock.Create<IHasBuffer>().WordsBuffer;

                Assert.That(DoesStringInListContainCharacter(wordsBuffer, c), Is.EqualTo(!eliminate));
            }
        }

        private bool DoesStringInListContainCharacter(List<string> list, char c)
        {
            foreach (var item in list)
            {
                if (item.Contains(c))
                {
                    return false;
                }
            }
            return true;
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
            "accidentally",
            "some",
            "somebody",
            "somehow",
            "terrible"
        };
    }
}
