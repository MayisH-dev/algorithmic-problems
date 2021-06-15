using System.Collections.Generic;

namespace Csharp.LongestPalindromeSolver.Continuous
{
    public class NaiveCachingSolver : IContinuousLongestPalindromeSolver
    {
        private readonly Dictionary<string, string> cache = new();
        public string GetLongestPalindrome(string chars)
        {
            if (chars.Length <= 1)
                return chars;

            string inside = chars[1..^1];
            string longestPalindromeInside = GetLongestPalindrome(inside);
            string result;

            if (chars[0] == chars[^1] && inside == longestPalindromeInside)
                result = chars;
            else
            {
                var init = GetLongestPalindrome(chars[..^1]);
                var tail = GetLongestPalindrome(chars[1..]);
                result = init.Length >= tail.Length ? init : tail;
            }

            cache.Add(chars, result);
            return result;
        }
    }
}