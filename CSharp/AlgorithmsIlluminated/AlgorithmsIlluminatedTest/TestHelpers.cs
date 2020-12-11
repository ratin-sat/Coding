using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AlgorithmsIlluminated.DataModel;

namespace AlgorithmsIlluminatedTest
{
    public static class TestHelpers
    {
        public static IEnumerable<T> ReadLineFromTextFile<T>(string filepath, Func<string, T> parser)
            => File.ReadAllLines(filepath).Select(parser);

        public static int[,] Read2DArray(string filepath)
        {
            var lines = File.ReadAllLines(filepath);

            // read grid dimensions
            var dim = lines.First()
                .Split(Array.Empty<char>(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var a = new int[dim[0], dim[1]];

            // read elements row by row
            for (var r = 0; r < dim[0]; r++)
            {
                var row = lines[r + 1].Split(Array.Empty<char>(), StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (var c = 0; c < dim[1]; c++)
                {
                    a[r, c] = row[c];
                }
            }

            return a;
        }

        public static Matrix[] ReadMatricesFromTextFile(string filepath)
        {
            var lines = File.ReadAllLines(filepath);
            var num = int.Parse(lines.First());
            var matrices = new Matrix[num];
            var currentLine = 1;

            for (var i = 0; i < num; i++)
            {
                // read number of rows and columns
                var rc = lines[currentLine++]
                    .Split(Array.Empty<char>(), StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                // read elements row by row
                var buffer = new int[rc[0], rc[1]];
                for (var r = 0; r < rc[0]; r++)
                {
                    var row = lines[currentLine++]
                        .Split(Array.Empty<char>(), StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
                    for (var c = 0; c < rc[1]; c++)
                    {
                        buffer[r, c] = row[c];
                    }
                }

                matrices[i] = new Matrix(buffer);
            }

            return matrices;
        }
    }
}
