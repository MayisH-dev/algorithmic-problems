using System.Collections.Generic;

namespace Csharp.LongestPalindromeSolver.Continuous
{
    public class NaiveSolver : IContinuousLongestPalindromeSolver
    {
        public string GetLongestPalindrome(string chars)
        {
            if (chars.Length <= 1)
                return chars;

            string inside = chars[1..^1];
            string longestPalindromeInside = GetLongestPalindrome(inside);

            if (chars[0] == chars[^1] && inside == longestPalindromeInside)
                return chars;
            else
            {
                var init = GetLongestPalindrome(chars[..^1]);
                var tail = GetLongestPalindrome(chars[1..]);
                return init.Length >= tail.Length ? init : tail;
            }

        }
    }
}