using DataStructures.CustomDynamicArrays;

namespace DataStructures.Algorithms.Arrays
{
    /// <summary>
    /// Provides examples of prefix sum and prefix product algorithms.
    /// </summary>
    /// <remarks>
    /// Prefix sums are useful when we want to answer many range sum questions quickly.
    /// We do some work once, store partial sums, and later calculate a range sum in O(1).
    /// </remarks>
    public static class PrefixSums
    {
        /// <summary>
        /// Builds a prefix sum array.
        /// Runs in O(n) time complexity because every value is visited once.
        /// Runs in O(n) space complexity because a new prefix array is created.
        /// </summary>
        /// <param name="nums">The array of numbers to process.</param>
        /// <returns>
        /// A prefix sum array where index 0 is 0, and every next value stores the sum so far.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the provided array is null.
        /// </exception>
        public static int[] BuildPrefixSum(int[] nums)
        {
            /*
             * Algorithm:
             * 1. Check whether the provided array is null.
             * 2. Create a prefix sum array with one extra slot.
             * 3. Store 0 at prefixSums[0].
             * 4. Go through the input using a normal for loop.
             * 5. Store the previous prefix sum plus the current value.
             * 6. Return the prefix sum array.
             */

            // Step 1: A null array cannot be processed.
            if (nums is null)
            {
                throw new ArgumentNullException(nameof(nums));
            }

            int[] prefixSums = new int[nums.Length + 1];

            // Step 4: Build the prefix sum from left to right.
            for (int i = 0; i < nums.Length; i++)
            {
                // Step 5: The next prefix stores everything before plus the current value.
                prefixSums[i + 1] = prefixSums[i] + nums[i];
            }

            // Step 6: Return the prepared prefix sum array.
            return prefixSums;
        }

        /// <summary>
        /// Builds a prefix sum array from a custom dynamic array.
        /// Runs in O(n) time complexity because every value is visited once.
        /// Runs in O(n) space complexity because a new prefix array is created.
        /// </summary>
        /// <param name="nums">The custom dynamic array of numbers to process.</param>
        /// <returns>
        /// A prefix sum array where index 0 is 0, and every next value stores the sum so far.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the provided dynamic array is null.
        /// </exception>
        public static int[] BuildPrefixSum(CustomDynamicArray<int> nums)
        {
            /*
             * Algorithm:
             * 1. Check whether the provided dynamic array is null.
             * 2. Create a prefix sum array with one extra slot.
             * 3. Store 0 at prefixSums[0].
             * 4. Go through the dynamic array using a normal for loop.
             * 5. Read every value by using Get(i).
             * 6. Store the previous prefix sum plus the current value.
             * 7. Return the prefix sum array.
             */

            // Step 1: A null dynamic array cannot be processed.
            if (nums is null)
            {
                throw new ArgumentNullException(nameof(nums));
            }

            int[] prefixSums = new int[nums.Count + 1];

            // Step 4: Build the prefix sum from left to right.
            for (int i = 0; i < nums.Count; i++)
            {
                // Step 5-6: Read the value and add it to the previous prefix sum.
                prefixSums[i + 1] = prefixSums[i] + nums.Get(i);
            }

            // Step 7: Return the prepared prefix sum array.
            return prefixSums;
        }

        /// <summary>
        /// Builds a prefix sum array from any integer sequence.
        /// </summary>
        /// <param name="nums">The sequence of numbers to process.</param>
        /// <returns>
        /// A prefix sum array where index 0 is 0, and every next value stores the sum so far.
        /// </returns>
        public static int[] BuildPrefixSum(IEnumerable<int> nums)
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
            return BuildPrefixSum(nums.ToArray());
        }

        /// <summary>
        /// Calculates the sum between left and right indexes by using a prefix sum array.
        /// Runs in O(1) time complexity because it uses only two prefix values.
        /// Runs in O(1) space complexity because no new collection is created.
        /// </summary>
        /// <param name="prefixSums">The prefix sum array created by BuildPrefixSum.</param>
        /// <param name="left">The first index of the original range.</param>
        /// <param name="right">The last index of the original range.</param>
        /// <returns>The sum of values between left and right, inclusive.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the provided prefix sum array is null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the requested range does not fit the original array.
        /// </exception>
        public static int RangeSumFromPrefixSum(int[] prefixSums, int left, int right)
        {
            /*
             * Algorithm:
             * 1. Check whether the provided prefix sum array is null.
             * 2. Validate the left and right indexes.
             * 3. Take prefixSums[right + 1].
             * 4. Subtract prefixSums[left].
             * 5. Return the range sum.
             */

            // Step 1: A null prefix sum array cannot be processed.
            if (prefixSums is null)
            {
                throw new ArgumentNullException(nameof(prefixSums));
            }

            // Step 2: Make sure the requested range exists in the original array.
            ValidatePrefixRange(prefixSums, left, right);

            // Step 3-5: Remove everything before left from the sum up to right.
            return prefixSums[right + 1] - prefixSums[left];
        }

        /// <summary>
        /// Builds a prefix product array.
        /// Runs in O(n) time complexity because every value is visited once.
        /// Runs in O(n) space complexity because a new prefix array is created.
        /// </summary>
        /// <param name="nums">The array of numbers to process.</param>
        /// <returns>
        /// A prefix product array where index 0 is 1, and every next value stores the product so far.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the provided array is null.
        /// </exception>
        public static int[] BuildPrefixProduct(int[] nums)
        {
            /*
             * Algorithm:
             * 1. Check whether the provided array is null.
             * 2. Create a prefix product array with one extra slot.
             * 3. Store 1 at prefixProducts[0].
             * 4. Go through the input using a normal for loop.
             * 5. Store the previous prefix product multiplied by the current value.
             * 6. Return the prefix product array.
             */

            // Step 1: A null array cannot be processed.
            if (nums is null)
            {
                throw new ArgumentNullException(nameof(nums));
            }

            int[] prefixProducts = new int[nums.Length + 1];
            prefixProducts[0] = 1;

            // Step 4: Build the prefix product from left to right.
            for (int i = 0; i < nums.Length; i++)
            {
                // Step 5: The next prefix stores everything before multiplied by the current value.
                prefixProducts[i + 1] = prefixProducts[i] * nums[i];
            }

            // Step 6: Return the prepared prefix product array.
            return prefixProducts;
        }

        /// <summary>
        /// Builds a prefix product array from a custom dynamic array.
        /// Runs in O(n) time complexity because every value is visited once.
        /// Runs in O(n) space complexity because a new prefix array is created.
        /// </summary>
        /// <param name="nums">The custom dynamic array of numbers to process.</param>
        /// <returns>
        /// A prefix product array where index 0 is 1, and every next value stores the product so far.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the provided dynamic array is null.
        /// </exception>
        public static int[] BuildPrefixProduct(CustomDynamicArray<int> nums)
        {
            /*
             * Algorithm:
             * 1. Check whether the provided dynamic array is null.
             * 2. Create a prefix product array with one extra slot.
             * 3. Store 1 at prefixProducts[0].
             * 4. Go through the dynamic array using a normal for loop.
             * 5. Read every value by using Get(i).
             * 6. Store the previous prefix product multiplied by the current value.
             * 7. Return the prefix product array.
             */

            // Step 1: A null dynamic array cannot be processed.
            if (nums is null)
            {
                throw new ArgumentNullException(nameof(nums));
            }

            int[] prefixProducts = new int[nums.Count + 1];
            prefixProducts[0] = 1;

            // Step 4: Build the prefix product from left to right.
            for (int i = 0; i < nums.Count; i++)
            {
                // Step 5-6: Read the value and multiply it with the previous prefix product.
                prefixProducts[i + 1] = prefixProducts[i] * nums.Get(i);
            }

            // Step 7: Return the prepared prefix product array.
            return prefixProducts;
        }

        /// <summary>
        /// Builds a prefix product array from any integer sequence.
        /// </summary>
        /// <param name="nums">The sequence of numbers to process.</param>
        /// <returns>
        /// A prefix product array where index 0 is 1, and every next value stores the product so far.
        /// </returns>
        public static int[] BuildPrefixProduct(IEnumerable<int> nums)
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
            return BuildPrefixProduct(nums.ToArray());
        }

        /// <summary>
        /// Calculates the product between left and right indexes by using a direct range loop.
        /// Runs in O(k) time complexity where k is the length of the requested range.
        /// Runs in O(1) space complexity because only one result variable is used.
        /// </summary>
        /// <param name="nums">The array of numbers to process.</param>
        /// <param name="left">The first index of the range.</param>
        /// <param name="right">The last index of the range.</param>
        /// <returns>The product of values between left and right, inclusive.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the provided array is null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the requested range does not fit the array.
        /// </exception>
        public static int RangeProduct(int[] nums, int left, int right)
        {
            /*
             * Algorithm:
             * 1. Check whether the provided array is null.
             * 2. Validate the left and right indexes.
             * 3. Start the product at 1.
             * 4. Go from left to right using a normal for loop.
             * 5. Multiply the result by every value in the range.
             * 6. Return the product.
             */

            // Step 1: A null array cannot be processed.
            if (nums is null)
            {
                throw new ArgumentNullException(nameof(nums));
            }

            // Step 2: Make sure the requested range exists.
            ValidateRange(nums.Length, left, right);

            int product = 1;

            // Step 4: Go through only the requested range.
            for (int i = left; i <= right; i++)
            {
                // Step 5: Multiply the result by the current value.
                product *= nums[i];
            }

            // Step 6: Return the product.
            return product;
        }

        /// <summary>
        /// Calculates the product between left and right indexes by using a direct range loop.
        /// Runs in O(k) time complexity where k is the length of the requested range.
        /// Runs in O(1) space complexity because only one result variable is used.
        /// </summary>
        /// <param name="nums">The custom dynamic array of numbers to process.</param>
        /// <param name="left">The first index of the range.</param>
        /// <param name="right">The last index of the range.</param>
        /// <returns>The product of values between left and right, inclusive.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the provided dynamic array is null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the requested range does not fit the dynamic array.
        /// </exception>
        public static int RangeProduct(CustomDynamicArray<int> nums, int left, int right)
        {
            /*
             * Algorithm:
             * 1. Check whether the provided dynamic array is null.
             * 2. Validate the left and right indexes.
             * 3. Start the product at 1.
             * 4. Go from left to right using a normal for loop.
             * 5. Read every value by using Get(i).
             * 6. Multiply the result by every value in the range.
             * 7. Return the product.
             */

            // Step 1: A null dynamic array cannot be processed.
            if (nums is null)
            {
                throw new ArgumentNullException(nameof(nums));
            }

            // Step 2: Make sure the requested range exists.
            ValidateRange(nums.Count, left, right);

            int product = 1;

            // Step 4: Go through only the requested range.
            for (int i = left; i <= right; i++)
            {
                // Step 5-6: Read the value and multiply it into the result.
                product *= nums.Get(i);
            }

            // Step 7: Return the product.
            return product;
        }

        /// <summary>
        /// Calculates the product between left and right indexes by using a direct range loop.
        /// </summary>
        /// <param name="nums">The sequence of numbers to process.</param>
        /// <param name="left">The first index of the range.</param>
        /// <param name="right">The last index of the range.</param>
        /// <returns>The product of values between left and right, inclusive.</returns>
        public static int RangeProduct(IEnumerable<int> nums, int left, int right)
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
            return RangeProduct(nums.ToArray(), left, right);
        }

        private static void ValidatePrefixRange(int[] prefixSums, int left, int right)
        {
            if (prefixSums.Length == 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(prefixSums),
                    "Prefix sum array must contain at least the starting zero value.");
            }

            ValidateRange(prefixSums.Length - 1, left, right);
        }

        private static void ValidateRange(int count, int left, int right)
        {
            if (left < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(left));
            }

            if (right < left)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(right),
                    "Right index must be greater than or equal to left index.");
            }

            if (right >= count)
            {
                throw new ArgumentOutOfRangeException(nameof(right));
            }
        }
    }
}
