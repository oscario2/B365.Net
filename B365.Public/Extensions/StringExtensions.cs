using System;
using System.Collections.Generic;
using System.Linq;

namespace B365.Public.Extensions
{
    public static class StringExtensions
    {
        public static List<string> SplitOnEnum<T>(this string input, T @enum)
            where T : Enum
        {
            return input.Split((char) (int) (object) @enum, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
    }
}