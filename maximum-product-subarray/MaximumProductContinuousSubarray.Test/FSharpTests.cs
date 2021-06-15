using System.Collections.Generic;
using Xunit;

namespace MaximumProductContinuousSubarray.Test
{
    public class FSharpTests
    {
        [Theory]
        [MemberData(nameof(TestCases))]
        public void Test(int[] nums, int maxProduct)
        {
            var max = FSharp.maxProduct(nums);

            Assert.Equal(max, maxProduct);
        }

        public static IEnumerable<object[]> TestCases
        {
            get
            {
                yield return new object[] { new[] { 2, 3, -2, 4 }, 6 };
                yield return new object[] { new[] { -2, 0, -1 }, 0 };
                yield return new object[] { new[] { -4, -3, -2 }, 12 };
                yield return new object[] { new[] { 6, -3, -10, 0, 2 }, 180 };
                yield return new object[] { new[] { -2, -40, 0, -2, -3 }, 80 };
                yield return new object[] { new[] { -1, -3, -10, 0, 60 }, 60 };
            }
        }
    }
}
