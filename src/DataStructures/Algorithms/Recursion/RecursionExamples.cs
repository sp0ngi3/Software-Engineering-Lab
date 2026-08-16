namespace DataStructures.Algorithms.Recursion
{
    /// <summary>
    /// Provides small examples of recursive and iterative algorithms.
    /// </summary>
    /// <remarks>
    /// Recursion is when a method calls itself with a smaller version of the same problem.
    /// Every recursive method needs a base case, otherwise it will keep calling itself forever.
    /// These examples are intentionally simple because the goal is to understand the call stack.
    /// </remarks>
    public static class RecursionExamples
    {
        private const int MaxFactorialInputForInt = 12;
        private const int MaxFibonacciInputForInt = 46;
        private const int MaxRecursiveFibonacciInput = 40;

        /// <summary>
        /// Calculates n factorial by using one-branch recursion.
        /// Runs in O(n) time complexity because the method calls itself n times.
        /// Runs in O(n) space complexity because every recursive call is stored on the call stack.
        /// </summary>
        /// <param name="n">The number to calculate factorial for.</param>
        /// <returns>The factorial result.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when n is negative or too large for an int factorial result.
        /// </exception>
        public static int FactorialRecursive(int n)
        {
            /*
             * Algorithm:
             * 1. Check whether n is inside the supported range.
             * 2. If n is 0 or 1, return 1. This is the base case.
             * 3. Otherwise, return n multiplied by FactorialRecursive(n - 1).
             * 4. Each recursive call makes the problem smaller.
             */

            // Step 1: Factorial is not defined for negative numbers in this simple version.
            ValidateFactorialInput(n);

            // Step 2: Base case. Without this, the recursion would never stop.
            if (n <= 1)
            {
                return 1;
            }

            // Step 3-4: Recursive case. Solve a smaller factorial and multiply by n.
            return n * FactorialRecursive(n - 1);
        }

        /// <summary>
        /// Calculates n factorial by using iteration.
        /// Runs in O(n) time complexity because the loop multiplies values from n down to 2.
        /// Runs in O(1) space complexity because no recursive call stack is used.
        /// </summary>
        /// <param name="n">The number to calculate factorial for.</param>
        /// <returns>The factorial result.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when n is negative or too large for an int factorial result.
        /// </exception>
        public static int FactorialIterative(int n)
        {
            /*
             * Algorithm:
             * 1. Check whether n is inside the supported range.
             * 2. Start result at 1.
             * 3. While n is greater than 1, multiply result by n.
             * 4. Decrease n after every multiplication.
             * 5. Return the final result.
             */

            // Step 1: Use the same input rules as the recursive version.
            ValidateFactorialInput(n);

            int result = 1;

            // Step 3-4: Multiply values from n down to 2.
            while (n > 1)
            {
                result *= n;
                n--;
            }

            // Step 5: Return the final factorial result.
            return result;
        }

        /// <summary>
        /// Calculates the n-th Fibonacci number by using two-branch recursion.
        /// Runs in O(2^n) time complexity because every call creates two more calls.
        /// Runs in O(n) space complexity because the deepest call stack is n levels deep.
        /// </summary>
        /// <param name="n">The Fibonacci index to calculate.</param>
        /// <returns>The n-th Fibonacci number.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when n is negative, too large for an int result, or too large for the recursive learning version.
        /// </exception>
        public static int FibonacciRecursive(int n)
        {
            /*
             * Algorithm:
             * 1. Check whether n is inside the supported range.
             * 2. If n is 0 or 1, return n. This is the base case.
             * 3. Otherwise, calculate FibonacciRecursive(n - 1).
             * 4. Also calculate FibonacciRecursive(n - 2).
             * 5. Return the sum of those two results.
             */

            // Step 1: Naive recursive Fibonacci gets slow very quickly.
            ValidateRecursiveFibonacciInput(n);

            // Step 2: Base case for F(0) and F(1).
            if (n <= 1)
            {
                return n;
            }

            // Step 3-5: Recursive case. This branches into two smaller Fibonacci problems.
            return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
        }

        /// <summary>
        /// Calculates the n-th Fibonacci number by using iteration.
        /// Runs in O(n) time complexity because the loop moves from 2 up to n.
        /// Runs in O(1) space complexity because only a few integer variables are used.
        /// </summary>
        /// <param name="n">The Fibonacci index to calculate.</param>
        /// <returns>The n-th Fibonacci number.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when n is negative or too large for an int Fibonacci result.
        /// </exception>
        public static int FibonacciIterative(int n)
        {
            /*
             * Algorithm:
             * 1. Check whether n is inside the supported range.
             * 2. If n is 0 or 1, return n.
             * 3. Store the previous two Fibonacci values.
             * 4. Move from 2 up to n using a normal for loop.
             * 5. Add the previous two values to calculate the current value.
             * 6. Move the previous values forward.
             * 7. Return the current Fibonacci value.
             */

            // Step 1: The int version supports Fibonacci values up to F(46).
            ValidateFibonacciInput(n);

            // Step 2: Base case written iteratively.
            if (n <= 1)
            {
                return n;
            }

            int previous = 0;
            int current = 1;

            // Step 4: Build the sequence from the bottom up.
            for (int i = 2; i <= n; i++)
            {
                // Step 5: The next value is the sum of the previous two values.
                int next = previous + current;

                // Step 6: Move the window of previous values forward.
                previous = current;
                current = next;
            }

            // Step 7: Return the n-th Fibonacci value.
            return current;
        }

        private static void ValidateFactorialInput(int n)
        {
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(n),
                    "Factorial input must be greater than or equal to zero.");
            }

            if (n > MaxFactorialInputForInt)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(n),
                    $"Factorial input must be less than or equal to {MaxFactorialInputForInt} for an int result.");
            }
        }

        private static void ValidateRecursiveFibonacciInput(int n)
        {
            ValidateFibonacciInput(n);

            if (n > MaxRecursiveFibonacciInput)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(n),
                    $"Recursive Fibonacci is limited to {MaxRecursiveFibonacciInput} in this learning example.");
            }
        }

        private static void ValidateFibonacciInput(int n)
        {
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(n),
                    "Fibonacci input must be greater than or equal to zero.");
            }

            if (n > MaxFibonacciInputForInt)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(n),
                    $"Fibonacci input must be less than or equal to {MaxFibonacciInputForInt} for an int result.");
            }
        }
    }
}
