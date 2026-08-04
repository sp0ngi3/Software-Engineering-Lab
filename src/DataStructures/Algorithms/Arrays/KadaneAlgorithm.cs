using DataStructures.CustomDynamicArray;

namespace DataStructures.Algorithms.Arrays
{
    /// <summary>
    /// Provides methods based on Kadane's algorithm.
    /// </summary>
    /// <remarks>
    /// Kadane's algorithm is used to find the contiguous subarray
    /// with the maximum possible sum.
    /// </remarks>
    public static class KadaneAlgorithm
    {
        /// <summary>
        /// Finds the maximum sum of a contiguous subarray.
        /// Runs in O(n) time complexity because every value is visited once.
        /// Runs in O(1) space complexity because only a few integer variables are used.
        /// </summary>
        /// <param name="nums">The array of numbers to analyze.</param>
        /// <returns>The maximum contiguous subarray sum.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the provided array is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when the provided array is empty.
        /// </exception>
        public static int MaxSubarraySum(int[] nums)
        {
            /*
             * Algorithm:
             * 1. Check whether the provided array is null.
             * 2. Check whether the provided array contains at least one value.
             * 3. Use the first value as the initial max sum.
             * 4. Go through the array using a normal for loop.
             * 5. If the current sum is negative, restart it from zero.
             * 6. Add the current value to the current sum.
             * 7. Update the max sum if the current sum is better.
             * 8. Return the best sum found.
             */

            // Step 1: A null array cannot be processed.
            if (nums is null)
            {
                throw new ArgumentNullException(nameof(nums));
            }

            // Step 2: The algorithm needs at least one value to have a valid result.
            if (nums.Length == 0)
            {
                throw new ArgumentException(
                    "Array must contain at least one value.",
                    nameof(nums));
            }

            // Step 3: Start with the first value as the best known sum.
            int maxSum = nums[0];
            int currentSum = 0;

            // Step 4: Go through the array using a normal for loop.
            for (int i = 0; i < nums.Length; i++)
            {
                // Step 5: If the current sum is negative, starting fresh is better.
                currentSum = Math.Max(currentSum, 0);

                // Step 6: Add the current value to the current sum.
                currentSum += nums[i];

                // Step 7: Store the best sum found so far.
                maxSum = Math.Max(maxSum, currentSum);
            }

            // Step 8: Return the best sum found.
            return maxSum;
        }

        /// <summary>
        /// Finds the maximum sum of a contiguous subarray in a custom dynamic array.
        /// Runs in O(n) time complexity because every value is visited once.
        /// Runs in O(1) space complexity because only a few integer variables are used.
        /// </summary>
        /// <param name="nums">The custom dynamic array of numbers to analyze.</param>
        /// <returns>The maximum contiguous subarray sum.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the provided dynamic array is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when the provided dynamic array is empty.
        /// </exception>
        public static int MaxSubarraySum(CustomDynamicArray<int> nums)
        {
            /*
             * Algorithm:
             * 1. Check whether the provided dynamic array is null.
             * 2. Check whether the dynamic array contains at least one value.
             * 3. Use the first value as the initial max sum.
             * 4. Go through the dynamic array using a normal for loop.
             * 5. Read every value by using Get(i).
             * 6. If the current sum is negative, restart it from zero.
             * 7. Add the current value to the current sum.
             * 8. Update the max sum if the current sum is better.
             * 9. Return the best sum found.
             */

            // Step 1: A null dynamic array cannot be processed.
            if (nums is null)
            {
                throw new ArgumentNullException(nameof(nums));
            }

            // Step 2: The algorithm needs at least one value to have a valid result.
            if (nums.Count == 0)
            {
                throw new ArgumentException(
                    "Dynamic array must contain at least one value.",
                    nameof(nums));
            }

            // Step 3: Start with the first value as the best known sum.
            int maxSum = nums.Get(0);
            int currentSum = 0;

            // Step 4: Go through the dynamic array using a normal for loop.
            for (int i = 0; i < nums.Count; i++)
            {
                // Step 5: Read the current value from the custom dynamic array.
                int currentValue = nums.Get(i);

                // Step 6: If the current sum is negative, starting fresh is better.
                currentSum = Math.Max(currentSum, 0);

                // Step 7: Add the current value to the current sum.
                currentSum += currentValue;

                // Step 8: Store the best sum found so far.
                maxSum = Math.Max(maxSum, currentSum);
            }

            // Step 9: Return the best sum found.
            return maxSum;
        }

        /// <summary>
        /// Finds the maximum sum of a contiguous subarray in any integer sequence.
        /// </summary>
        /// <param name="nums">The sequence of numbers to analyze.</param>
        /// <returns>The maximum contiguous subarray sum.</returns>
        public static int MaxSubarraySum(IEnumerable<int> nums)
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
            return MaxSubarraySum(nums.ToArray());
        }

        /// <summary>
        /// Finds the start and end indexes of the contiguous subarray with the maximum sum.
        /// Runs in O(n) time complexity because every value is visited once.
        /// Runs in O(1) space complexity because only a few integer variables are used.
        /// </summary>
        /// <param name="nums">The array of numbers to analyze.</param>
        /// <returns>
        /// An array where the first value is the start index and the second value is the end index.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the provided array is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when the provided array is empty.
        /// </exception>
        public static int[] FindMaxSubarrayRange(int[] nums)
        {
            /*
             * Algorithm:
             * 1. Check whether the provided array is null.
             * 2. Check whether the provided array contains at least one value.
             * 3. Use the first value as the initial max sum.
             * 4. Go through the array using a normal for loop.
             * 5. If the current sum is negative, start a new range at the current index.
             * 6. Add the current value to the current sum.
             * 7. If the current sum is better than the max sum, save the current range.
             * 8. Return the saved start and end indexes.
             */

            // Step 1: A null array cannot be processed.
            if (nums is null)
            {
                throw new ArgumentNullException(nameof(nums));
            }

            // Step 2: The algorithm needs at least one value to have a valid result.
            if (nums.Length == 0)
            {
                throw new ArgumentException(
                    "Array must contain at least one value.",
                    nameof(nums));
            }

            // Step 3: Start with the first value as the best known sum.
            int maxSum = nums[0];
            int currentSum = 0;
            int maxLeft = 0;
            int maxRight = 0;
            int currentLeft = 0;

            // Step 4: Go through the array using a normal for loop.
            for (int right = 0; right < nums.Length; right++)
            {
                // Step 5: If the current sum is negative, start a new range here.
                if (currentSum < 0)
                {
                    currentSum = 0;
                    currentLeft = right;
                }

                // Step 6: Add the current value to the current sum.
                currentSum += nums[right];

                // Step 7: If this range is better, save its indexes.
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    maxLeft = currentLeft;
                    maxRight = right;
                }
            }

            // Step 8: Return the best range found.
            return new[] { maxLeft, maxRight };
        }

        /// <summary>
        /// Finds the start and end indexes of the contiguous subarray with the maximum sum.
        /// Runs in O(n) time complexity because every value is visited once.
        /// Runs in O(1) space complexity because only a few integer variables are used.
        /// </summary>
        /// <param name="nums">The custom dynamic array of numbers to analyze.</param>
        /// <returns>
        /// An array where the first value is the start index and the second value is the end index.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the provided dynamic array is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when the provided dynamic array is empty.
        /// </exception>
        public static int[] FindMaxSubarrayRange(CustomDynamicArray<int> nums)
        {
            /*
             * Algorithm:
             * 1. Check whether the provided dynamic array is null.
             * 2. Check whether the dynamic array contains at least one value.
             * 3. Use the first value as the initial max sum.
             * 4. Go through the dynamic array using a normal for loop.
             * 5. Read every value by using Get(i).
             * 6. If the current sum is negative, start a new range at the current index.
             * 7. Add the current value to the current sum.
             * 8. If the current sum is better than the max sum, save the current range.
             * 9. Return the saved start and end indexes.
             */

            // Step 1: A null dynamic array cannot be processed.
            if (nums is null)
            {
                throw new ArgumentNullException(nameof(nums));
            }

            // Step 2: The algorithm needs at least one value to have a valid result.
            if (nums.Count == 0)
            {
                throw new ArgumentException(
                    "Dynamic array must contain at least one value.",
                    nameof(nums));
            }

            // Step 3: Start with the first value as the best known sum.
            int maxSum = nums.Get(0);
            int currentSum = 0;
            int maxLeft = 0;
            int maxRight = 0;
            int currentLeft = 0;

            // Step 4: Go through the dynamic array using a normal for loop.
            for (int right = 0; right < nums.Count; right++)
            {
                // Step 5: Read the current value from the custom dynamic array.
                int currentValue = nums.Get(right);

                // Step 6: If the current sum is negative, start a new range here.
                if (currentSum < 0)
                {
                    currentSum = 0;
                    currentLeft = right;
                }

                // Step 7: Add the current value to the current sum.
                currentSum += currentValue;

                // Step 8: If this range is better, save its indexes.
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    maxLeft = currentLeft;
                    maxRight = right;
                }
            }

            // Step 9: Return the best range found.
            return new[] { maxLeft, maxRight };
        }

        /// <summary>
        /// Finds the start and end indexes of the contiguous subarray with the maximum sum.
        /// </summary>
        /// <param name="nums">The sequence of numbers to analyze.</param>
        /// <returns>
        /// An array where the first value is the start index and the second value is the end index.
        /// </returns>
        public static int[] FindMaxSubarrayRange(IEnumerable<int> nums)
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
            return FindMaxSubarrayRange(nums.ToArray());
        }
    }
}
