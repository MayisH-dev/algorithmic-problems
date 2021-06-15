using System;
using BenchmarkDotNet.Attributes;
using Csharp.LongestPalindromeSolver.Continuous;

namespace Csharp
{
    public class ContinuousBenchmark
    {
        [Params(20)]
        public int Size;
        private readonly string _data;
        private readonly DpSolver _dp = new();
        private readonly NaiveSolver _naive = new();
        private readonly NaiveCachingSolver _naiveCaching = new();

        public ContinuousBenchmark()
        {
            Random rng = new();
            var data = new char[Size];

            for (int i = 0; i < data.Length; ++i)
                data[i] = (char)rng.Next(97, 122);

            _data = new(data);
        }

        [Benchmark]
        public string Dp() => _dp.GetLongestPalindrome(_data);

        [Benchmark(Baseline = true)]
        public string Naive() => _naive.GetLongestPalindrome(_data);

        [Benchmark]
        public string NaiveCaching() => _naiveCaching.GetLongestPalindrome(_data);
    }
}