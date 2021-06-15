namespace Csharp.LongestPalindromeSolver.NonContinuous
{
    public class NaiveSolver : INonContinuousLongestPalindromeSolver
    {
        public string GetLongestPalindrome(string chars)
        {
            if (chars.Length is 0 or 1)
                return chars;
            else if (chars[0] == chars[^1])
                return chars[0] + GetLongestPalindrome(chars[1..^1]) + chars[^1];
            else
            {
                var init = GetLongestPalindrome(chars[..^1]);
                var tail = GetLongestPalindrome(chars[1..]);
                return (init.Length >= tail.Length) ? init : tail;
            }
        }
    }
}