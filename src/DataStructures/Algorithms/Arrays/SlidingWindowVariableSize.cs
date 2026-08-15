using DataStructures.CustomDynamicArrays;

namespace DataStructures.Algorithms.Arrays
{
    /// <summary>
    /// Provides examples of variable size sliding window algorithms.
    /// </summary>
    /// <remarks>
    /// Variable size sliding window uses two pointers, usually called left and right.
    /// The right pointer expands the window, and the left pointer shrinks the window
    /// when the current window no longer fits the problem.
    /// </remarks>
    public static class SlidingWindowVariableSize
    {
        /// <summary>
        /// Finds the length of the longest contiguous subarray where every value is the same.
        /// Runs in O(n) time complexity because every value is visited once.
        /// Runs in O(1) space complexity because only a few integer variables are used.
        /// </summary>
        /// <param name="nums">The array of numbers to analyze.</param>
        /// <returns>The length of the longest subarray with the same value.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the provided array is null.
        /// </exception>
        public static int LongestSubarrayWithSameValue(int[] nums)
        {
            /*
             * Algorithm:
             * 1. Check whether the provided array is null.
             * 2. Create the left pointer at the beginning of the array.
             * 3. Move the right pointer through the array using a normal for loop.
             * 4. If nums[left] is different than nums[right], start a new window at right.
             * 5. Calculate the current window length.
             * 6. Update the best length if the current window is longer.
             * 7. Return the best length found.
             */

            // Step 1: A null array cannot be processed.
            if (nums is null)
            {
                throw new ArgumentNullException(nameof(nums));
            }

            int length = 0;
            int left = 0;

            // Step 3: Move the right pointer through the array.
            for (int right = 0; right < nums.Length; right++)
            {
                // Step 4: If a new value appears, the previous window is finished.
                if (nums[left] != nums[right])
                {
                    left = right;
                }

                // Step 5-6: Calculate the current window length and keep the best one.
                length = Math.Max(length, right - left + 1);
            }

            // Step 7: Return the best length found.
            return length;
        }

        /// <summary>
        /// Finds the length of the longest contiguous subarray where every value is the same.
        /// Runs in O(n) time complexity because every value is visited once.
        /// Runs in O(1) space complexity because only a few integer variables are used.
        /// </summary>
        /// <param name="nums">The custom dynamic array of numbers to analyze.</param>
        /// <returns>The length of the longest subarray with the same value.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the provided dynamic array is null.
        /// </exception>
        public static int LongestSubarrayWithSameValue(CustomDynamicArray<int> nums)
        {
            /*
             * Algorithm:
             * 1. Check whether the provided dynamic array is null.
             * 2. Create the left pointer at the beginning of the dynamic array.
             * 3. Move the right pointer through the dynamic array using a normal for loop.
             * 4. If nums.Get(left) is different than nums.Get(right), start a new window at right.
             * 5. Calculate the current window length.
             * 6. Update the best length if the current window is longer.
             * 7. Return the best length found.
             */

            // Step 1: A null dynamic array cannot be processed.
            if (nums is null)
            {
                throw new ArgumentNullException(nameof(nums));
            }

            int length = 0;
            int left = 0;

            // Step 3: Move the right pointer through the dynamic array.
            for (int right = 0; right < nums.Count; right++)
            {
                // Step 4: If a new value appears, the previous window is finished.
                if (nums.Get(left) != nums.Get(right))
                {
                    left = right;
                }

                // Step 5-6: Calculate the current window length and keep the best one.
                length = Math.Max(length, right - left + 1);
            }

            // Step 7: Return the best length found.
            return length;
        }

        /// <summary>
        /// Finds the length of the longest contiguous subarray where every value is the same.
        /// </summary>
        /// <param name="nums">The sequence of numbers to analyze.</param>
        /// <returns>The length of the longest subarray with the same value.</returns>
        public static int LongestSubarrayWithSameValue(IEnumerable<int> nums)
        {
            /*
             * Algorithm:
             * 1. Check whether the provided sequence is null.
             * 2. Copy the sequence into an array.
             * 3. Use the array version, which is implemented with a normal for loop.
             */

            // Step 1: A null sequence cannot be processed.
            if (nums is null)
            {
                throw new ArgumentNullException(nameof(nums));
            }

            // Step 2-3: Copy the values and reuse the normal array implementation.
            return LongestSubarrayWithSameValue(nums.ToArray());
        }

        /// <summary>
        /// Finds the minimum length of a contiguous subarray where the sum is greater than or equal to target.
        /// Assumes all values are positive.
        /// Runs in O(n) time complexity because each value is added and removed from the window at most once.
        /// Runs in O(1) space complexity because only a few integer variables are used.
        /// </summary>
        /// <param name="nums">The array of positive numbers to analyze.</param>
        /// <param name="target">The target sum that the window must reach.</param>
        /// <returns>The minimum valid subarray length, or 0 when no valid subarray exists.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the provided array is null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when target is less than or equal to zero.
        /// </exception>
        public static int ShortestSubarrayWithSumAtLeastTarget(int[] nums, int target)
        {
            /*
             * Algorithm:
             * 1. Check whether the provided array is null.
             * 2. Check whether the target is positive.
             * 3. Create the left pointer at the beginning of the array.
             * 4. Move the right pointer through the array and expand the window.
             * 5. Add nums[right] to the current window sum.
             * 6. While the window sum is greater than or equal to target:
             *      a. Update the best length.
             *      b. Remove nums[left] from the current window sum.
             *      c. Move left forward to shrink the window.
             * 7. Return 0 if no valid window was found.
             * 8. Otherwise, return the best length found.
             */

            // Step 1: A null array cannot be processed.
            if (nums is null)
            {
                throw new ArgumentNullException(nameof(nums));
            }

            // Step 2: This version assumes a positive target.
            if (target <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(target),
                    "Target must be greater than zero.");
            }

            int left = 0;
            int total = 0;
            int length = int.MaxValue;

            // Step 4: Move the right pointer and expand the window.
            for (int right = 0; right < nums.Length; right++)
            {
                // Step 5: Add the new right value to the window sum.
                total += nums[right];

                // Step 6: Shrink the window while it is valid.
                while (total >= target)
                {
                    length = Math.Min(length, right - left + 1);
                    total -= nums[left];
                    left++;
                }
            }

            // Step 7: If no valid window exists, return 0.
            if (length == int.MaxValue)
            {
                return 0;
            }

            // Step 8: Return the best length found.
            return length;
        }

        /// <summary>
        /// Finds the minimum length of a contiguous subarray where the sum is greater than or equal to target.
        /// Assumes all values are positive.
        /// Runs in O(n) time complexity because each value is added and removed from the window at most once.
        /// Runs in O(1) space complexity because only a few integer variables are used.
        /// </summary>
        /// <param name="nums">The custom dynamic array of positive numbers to analyze.</param>
        /// <param name="target">The target sum that the window must reach.</param>
        /// <returns>The minimum valid subarray length, or 0 when no valid subarray exists.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the provided dynamic array is null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when target is less than or equal to zero.
        /// </exception>
        public static int ShortestSubarrayWithSumAtLeastTarget(CustomDynamicArray<int> nums, int target)
        {
            /*
             * Algorithm:
             * 1. Check whether the provided dynamic array is null.
             * 2. Check whether the target is positive.
             * 3. Create the left pointer at the beginning of the dynamic array.
             * 4. Move the right pointer through the dynamic array and expand the window.
             * 5. Add nums.Get(right) to the current window sum.
             * 6. While the window sum is greater than or equal to target:
             *      a. Update the best length.
             *      b. Remove nums.Get(left) from the current window sum.
             *      c. Move left forward to shrink the window.
             * 7. Return 0 if no valid window was found.
             * 8. Otherwise, return the best length found.
             */

            // Step 1: A null dynamic array cannot be processed.
            if (nums is null)
            {
                throw new ArgumentNullException(nameof(nums));
            }

            // Step 2: This version assumes a positive target.
            if (target <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(target),
                    "Target must be greater than zero.");
            }

            int left = 0;
            int total = 0;
            int length = int.MaxValue;

            // Step 4: Move the right pointer and expand the window.
            for (int right = 0; right < nums.Count; right++)
            {
                // Step 5: Add the new right value to the window sum.
                total += nums.Get(right);

                // Step 6: Shrink the window while it is valid.
                while (total >= target)
                {
                    length = Math.Min(length, right - left + 1);
                    total -= nums.Get(left);
                    left++;
                }
            }

            // Step 7: If no valid window exists, return 0.
            if (length == int.MaxValue)
            {
                return 0;
            }

            // Step 8: Return the best length found.
            return length;
        }

        /// <summary>
        /// Finds the minimum length of a contiguous subarray where the sum is greater than or equal to target.
        /// Assumes all values are positive.
        /// </summary>
        /// <param name="nums">The sequence of positive numbers to analyze.</param>
        /// <param name="target">The target sum that the window must reach.</param>
        /// <returns>The minimum valid subarray length, or 0 when no valid subarray exists.</returns>
        public static int ShortestSubarrayWithSumAtLeastTarget(IEnumerable<int> nums, int target)
        {
            /*
             * Algorithm:
             * 1. Check whether the provided sequence is null.
             * 2. Copy the sequence into an array.
             * 3. Use the array version, which is implemented with a normal for loop.
             */

            // Step 1: A null sequence cannot be processed.
            if (nums is null)
            {
                throw new ArgumentNullException(nameof(nums));
            }

            // Step 2-3: Copy the values and reuse the normal array implementation.
            return ShortestSubarrayWithSumAtLeastTarget(nums.ToArray(), target);
        }
    }
}
