namespace Csharp
{
    public interface ILongestPalindromeSolver
    {
        public string GetLongestPalindrome(string chars);
    }

    public interface IContinuousLongestPalindromeSolver : ILongestPalindromeSolver{}
    public interface INonContinuousLongestPalindromeSolver : ILongestPalindromeSolver{}
}