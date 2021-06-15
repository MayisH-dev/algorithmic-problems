using System;

namespace MaximumProductContinuousSubarray.CSharp
{
    public static class MaximumProductContinuousSubarray
    {
        public static int MaxProduct(int[] nums)
        {
            int maxSoFar = nums[0];
            int maxEndingHere = nums[0];
            int minEndingHere = nums[0];

            for (int i = 1; i < nums.Length; ++i)
            {
                var max = Max(nums[i], nums[i] * maxEndingHere, nums[i] * minEndingHere);
                var min = Min(nums[i], nums[i] * maxEndingHere, nums[i] * minEndingHere);
                (maxEndingHere, minEndingHere) = (max, min);
                maxSoFar = Math.Max(maxSoFar, maxEndingHere);
            }

            return maxSoFar;

            static int Max(int a, int b, int c) => Math.Max(a, Math.Max(b, c));
            static int Min(int a, int b, int c) => Math.Min(a, Math.Min(b, c));
        }
    }
}
