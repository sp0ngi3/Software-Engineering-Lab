using DataStructures.CustomDynamicArrays;

namespace DataStructures.Algorithms.Arrays
{
    /// <summary>
    /// Provides examples of two pointers algorithms.
    /// </summary>
    /// <remarks>
    /// Two pointers is a technique where we keep two indexes and move them through the input.
    /// Very often one pointer starts at the beginning, and the second pointer starts at the end.
    /// This is useful when checking pairs, comparing values from both sides, or using sorted data.
    /// </remarks>
    public static class TwoPointers
    {
        /// <summary>
        /// Checks whether the provided word is a palindrome.
        /// Runs in O(n) time complexity because every character is checked at most once.
        /// Runs in O(1) space complexity because only two integer pointers are used.
        /// </summary>
        /// <param name="word">The word to check.</param>
        /// <returns>True when the word reads the same from both sides; otherwise false.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the provided word is null.
        /// </exception>
        public static bool IsPalindrome(string word)
        {
            /*
             * Algorithm:
             * 1. Check whether the provided word is null.
             * 2. Create the left pointer at the beginning of the word.
             * 3. Create the right pointer at the end of the word.
             * 4. While left is smaller than right, compare both characters.
             * 5. If the characters are different, the word is not a palindrome.
             * 6. Move left forward and right backward.
             * 7. If all compared characters matched, return true.
             */

            // Step 1: A null word cannot be processed.
            if (word is null)
            {
                throw new ArgumentNullException(nameof(word));
            }

            int left = 0;
            int right = word.Length - 1;

            // Step 4: Move both pointers towards the middle.
            while (left < right)
            {
                // Step 5: One mismatch is enough to know this is not a palindrome.
                if (word[left] != word[right])
                {
                    return false;
                }

                // Step 6: Move closer to the middle.
                left++;
                right--;
            }

            // Step 7: No mismatch was found.
            return true;
        }

        /// <summary>
        /// Checks whether the provided array is a palindrome.
        /// Runs in O(n) time complexity because every value is checked at most once.
        /// Runs in O(1) space complexity because only two integer pointers are used.
        /// </summary>
        /// <param name="nums">The array of numbers to check.</param>
        /// <returns>True when the values read the same from both sides; otherwise false.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the provided array is null.
        /// </exception>
        public static bool IsPalindrome(int[] nums)
        {
            /*
             * Algorithm:
             * 1. Check whether the provided array is null.
             * 2. Create the left pointer at the beginning of the array.
             * 3. Create the right pointer at the end of the array.
             * 4. While left is smaller than right, compare both values.
             * 5. If the values are different, the array is not a palindrome.
             * 6. Move left forward and right backward.
             * 7. If all compared values matched, return true.
             */

            // Step 1: A null array cannot be processed.
            if (nums is null)
            {
                throw new ArgumentNullException(nameof(nums));
            }

            int left = 0;
            int right = nums.Length - 1;

            // Step 4: Move both pointers towards the middle.
            while (left < right)
            {
                // Step 5: One mismatch is enough to know this is not a palindrome.
                if (nums[left] != nums[right])
                {
                    return false;
                }

                // Step 6: Move closer to the middle.
                left++;
                right--;
            }

            // Step 7: No mismatch was found.
            return true;
        }

        /// <summary>
        /// Checks whether the provided custom dynamic array is a palindrome.
        /// Runs in O(n) time complexity because every value is checked at most once.
        /// Runs in O(1) space complexity because only two integer pointers are used.
        /// </summary>
        /// <param name="nums">The custom dynamic array of numbers to check.</param>
        /// <returns>True when the values read the same from both sides; otherwise false.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the provided dynamic array is null.
        /// </exception>
        public static bool IsPalindrome(CustomDynamicArray<int> nums)
        {
            /*
             * Algorithm:
             * 1. Check whether the provided dynamic array is null.
             * 2. Create the left pointer at the beginning of the dynamic array.
             * 3. Create the right pointer at the end of the dynamic array.
             * 4. While left is smaller than right, compare both values.
             * 5. If the values are different, the dynamic array is not a palindrome.
             * 6. Move left forward and right backward.
             * 7. If all compared values matched, return true.
             */

            // Step 1: A null dynamic array cannot be processed.
            if (nums is null)
            {
                throw new ArgumentNullException(nameof(nums));
            }

            int left = 0;
            int right = nums.Count - 1;

            // Step 4: Move both pointers towards the middle.
            while (left < right)
            {
                // Step 5: One mismatch is enough to know this is not a palindrome.
                if (nums.Get(left) != nums.Get(right))
                {
                    return false;
                }

                // Step 6: Move closer to the middle.
                left++;
                right--;
            }

            // Step 7: No mismatch was found.
            return true;
        }

        /// <summary>
        /// Checks whether the provided sequence is a palindrome.
        /// </summary>
        /// <param name="nums">The sequence of numbers to check.</param>
        /// <returns>True when the values read the same from both sides; otherwise false.</returns>
        public static bool IsPalindrome(IEnumerable<int> nums)
        {
            /*
             * Algorithm:
             * 1. Check whether the provided sequence is null.
             * 2. Copy the sequence into an array.
             * 3. Use the array version, which is implemented with two pointers.
             */

            // Step 1: A null sequence cannot be processed.
            if (nums is null)
            {
                throw new ArgumentNullException(nameof(nums));
            }

            // Step 2-3: Copy the values and reuse the normal array implementation.
            return IsPalindrome(nums.ToArray());
        }

        /// <summary>
        /// Finds two indexes where the values add up to the target.
        /// Assumes the input array is sorted in ascending order.
        /// Runs in O(n) time complexity because each pointer moves through the array at most once.
        /// Runs in O(1) space complexity because only two integer pointers are used.
        /// </summary>
        /// <param name="nums">The sorted array of numbers to search.</param>
        /// <param name="target">The target sum to find.</param>
        /// <returns>The two indexes that create the target sum, or null when no pair exists.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the provided array is null.
        /// </exception>
        public static int[]? TargetSum(int[] nums, int target)
        {
            /*
             * Algorithm:
             * 1. Check whether the provided array is null.
             * 2. Create the left pointer at the beginning of the array.
             * 3. Create the right pointer at the end of the array.
             * 4. While left is smaller than right, calculate the current sum.
             * 5. If the sum is too big, move right backward to use a smaller value.
             * 6. If the sum is too small, move left forward to use a bigger value.
             * 7. If the sum is equal to target, return both indexes.
             * 8. If no pair was found, return null.
             */

            // Step 1: A null array cannot be processed.
            if (nums is null)
            {
                throw new ArgumentNullException(nameof(nums));
            }

            int left = 0;
            int right = nums.Length - 1;

            // Step 4: Keep searching while the pointers do not cross.
            while (left < right)
            {
                int currentSum = nums[left] + nums[right];

                // Step 5: The array is sorted, so moving right left makes the sum smaller.
                if (currentSum > target)
                {
                    right--;
                }
                // Step 6: The array is sorted, so moving left right makes the sum bigger.
                else if (currentSum < target)
                {
                    left++;
                }
                else
                {
                    // Step 7: We found the pair.
                    return new[] { left, right };
                }
            }

            // Step 8: No pair was found.
            return null;
        }

        /// <summary>
        /// Finds two indexes where the values add up to the target.
        /// Assumes the custom dynamic array is sorted in ascending order.
        /// Runs in O(n) time complexity because each pointer moves through the dynamic array at most once.
        /// Runs in O(1) space complexity because only two integer pointers are used.
        /// </summary>
        /// <param name="nums">The sorted custom dynamic array of numbers to search.</param>
        /// <param name="target">The target sum to find.</param>
        /// <returns>The two indexes that create the target sum, or null when no pair exists.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the provided dynamic array is null.
        /// </exception>
        public static int[]? TargetSum(CustomDynamicArray<int> nums, int target)
        {
            /*
             * Algorithm:
             * 1. Check whether the provided dynamic array is null.
             * 2. Create the left pointer at the beginning of the dynamic array.
             * 3. Create the right pointer at the end of the dynamic array.
             * 4. While left is smaller than right, calculate the current sum.
             * 5. If the sum is too big, move right backward to use a smaller value.
             * 6. If the sum is too small, move left forward to use a bigger value.
             * 7. If the sum is equal to target, return both indexes.
             * 8. If no pair was found, return null.
             */

            // Step 1: A null dynamic array cannot be processed.
            if (nums is null)
            {
                throw new ArgumentNullException(nameof(nums));
            }

            int left = 0;
            int right = nums.Count - 1;

            // Step 4: Keep searching while the pointers do not cross.
            while (left < right)
            {
                int currentSum = nums.Get(left) + nums.Get(right);

                // Step 5: The dynamic array is sorted, so moving right left makes the sum smaller.
                if (currentSum > target)
                {
                    right--;
                }
                // Step 6: The dynamic array is sorted, so moving left right makes the sum bigger.
                else if (currentSum < target)
                {
                    left++;
                }
                else
                {
                    // Step 7: We found the pair.
                    return new[] { left, right };
                }
            }

            // Step 8: No pair was found.
            return null;
        }

        /// <summary>
        /// Finds two indexes where the values add up to the target.
        /// Assumes the sequence is sorted in ascending order.
        /// </summary>
        /// <param name="nums">The sorted sequence of numbers to search.</param>
        /// <param name="target">The target sum to find.</param>
        /// <returns>The two indexes that create the target sum, or null when no pair exists.</returns>
        public static int[]? TargetSum(IEnumerable<int> nums, int target)
        {
            /*
             * Algorithm:
             * 1. Check whether the provided sequence is null.
             * 2. Copy the sequence into an array.
             * 3. Use the array version, which is implemented with two pointers.
             */

            // Step 1: A null sequence cannot be processed.
            if (nums is null)
            {
                throw new ArgumentNullException(nameof(nums));
            }

            // Step 2-3: Copy the values and reuse the normal array implementation.
            return TargetSum(nums.ToArray(), target);
        }
    }
}
