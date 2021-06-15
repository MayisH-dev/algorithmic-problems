using Xunit;

namespace InterleavingStrings.Test
{
    using System.Collections.Generic;
    using InterleavingStrings.Recursive;

    public class RecursiveImplementationTest
    {
        [Theory]
        [MemberData(nameof(ValidInterleaves))]
        public void IsInterleaved_ReturnsTrue(string first, string second, string third)
        {
            InterleaveTester tester = new(first, second, third);
            string error = $"Recursive IsInterleaved did not return true for first:\"{first}\"' second:\"{second}\" third:\"{third}\"";

            var result = tester.IsInterleaved();

            Assert.True(result, error);
        }

        public static IEnumerable<object[]> ValidInterleaves
        {
            get {
                yield return new [] {"a", "", "a"};
                yield return new [] {"", "a", "a"};
                yield return new [] {"a", "a", "aa"};
                yield return new [] {"abq", "abc", "abcabq"};
            }
        }
    }
}
