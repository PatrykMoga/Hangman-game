using System;
using System.Collections.Generic;

namespace HangmanLibrary
{
    public static class Generic
    {
        private static readonly Random _random = new Random();

        public static T GetRandomElement<T>(this IList<T> list) =>
            list[_random.Next(list.Count)];
    }
}