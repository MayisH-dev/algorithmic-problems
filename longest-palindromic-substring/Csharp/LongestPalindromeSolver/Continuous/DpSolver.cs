using System;

namespace Csharp.LongestPalindromeSolver.Continuous
{
    public class DpSolver : IContinuousLongestPalindromeSolver
    {
        private Range?[,]? dp;

        public string GetLongestPalindrome(string chars)
        {
            if (chars.Length <= 1)
                return chars;

            dp = new Range?[chars.Length, chars.Length];

            return chars[LongestPalindromeRange(chars.AsSpan(), ..)].ToString();
        }

        private Range LongestPalindromeRange(in ReadOnlySpan<char> chars, in Range range)
        {
            // given [a,b,c]
            // tail is [b,c]
            // init is [a,b]
            // inner is [b]

            var innerRange = TrimStartEnd(range, 1, 1);
            if (Dp(range).HasValue) {}
            else if (chars[range].Length <= 1)
                Dp(range) = range;
            else if (First(chars, range) == Last(chars, range)
                && LongestPalindromeRange(chars, innerRange).Equals(innerRange))
                Dp(range) = range;
            else
            {
                var tailPalindromeRange = LongestPalindromeRange(chars, TrimStartEnd(range, 1, 0));
                var initPalindromeRange = LongestPalindromeRange(chars, TrimStartEnd(range, 0, 1));
                Dp(range) =
                    Length(chars, tailPalindromeRange) > Length(chars, initPalindromeRange)
                    ? tailPalindromeRange
                    : initPalindromeRange;
            }

            return Dp(range)!.Value;

            static int Length(in ReadOnlySpan<char> chars, in Range range) =>
                range.GetOffsetAndLength(chars.Length).Length;

            static T First<T>(ReadOnlySpan<T> span, Range range) => span[range.Start];
            static T Last<T>(ReadOnlySpan<T> span, Range range) => span[span.Length - range.End.Value - 1];

            // Do not use in production as this assumes 2 things :
            // 1. end index is from end and start is from start
            // 2. length is > 1 for the given chars val
            static Range TrimStartEnd(in Range range, int start, int end) =>
                new(Index.FromStart(range.Start.Value + start),
                    Index.FromEnd(range.End.Value + end));
        }

        // Do not use in production as this assumes 2 things :
        // 1. end index is from end and start is from start
        // 2. length is > 1 for the given chars val
        private ref Range? Dp(in Range range) =>
            ref dp![range.Start.Value, dp.GetLength(0) - range.End.Value - 1];

    }
}