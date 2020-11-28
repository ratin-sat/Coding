using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AlgorithmsIlluminatedTest
{
    public static class TestHelpers
    {
        public static IEnumerable<T> ReadLineFromTextFile<T>(string filepath, Func<string, T> parser)
            => File.ReadAllLines(filepath).Select(parser);
    }
}
