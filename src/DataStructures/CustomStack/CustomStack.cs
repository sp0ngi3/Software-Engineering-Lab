using DataStructures.CustomDynamicArrays;

namespace DataStructures.CustomStack
{
    /// <summary>
    /// Represents a custom stack implementation.
    /// </summary>
    /// <remarks>
    /// A stack works in LIFO order, which means Last In, First Out.
    /// The last value pushed onto the stack is the first value removed from it.
    /// This implementation uses custom dynamic array as the internal storage.
    /// </remarks>
    /// <typeparam name="T">The type of elements stored in the stack.</typeparam>
    public class CustomStack<T>
    {
        /// <summary>
        /// Internal dynamic array that stores stack values.
        /// </summary>
        private readonly CustomDynamicArray<T> _arr;

        /// <summary>
        /// Provides the number of values currently stored in the stack.
        /// </summary>
        public int Count => _arr.Count;

        /// <summary>
        /// Creates a new empty stack.
        /// </summary>
        public CustomStack()
        {
            _arr = new CustomDynamicArray<T>();
        }

        /// <summary>
        /// Adds a new value to the top of the stack.
        /// Usually runs in O(1) time complexity, unless the internal dynamic array has to resize.
        /// </summary>
        /// <param name="val">The value to add to the stack.</param>
        public void Push(T val)
        {
            /*
             * Algorithm:
             * 1. Add the value to the end of the internal dynamic array.
             * 2. The end of the dynamic array is treated as the top of the stack.
             */

            // Step 1-2: Add the value to the top of the stack.
            _arr.Add(val);
        }

        /// <summary>
        /// Removes and returns the value from the top of the stack.
        /// Usually runs in O(1) time complexity, unless the internal dynamic array has to shrink.
        /// </summary>
        /// <returns>The value removed from the top of the stack.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the stack is empty.
        /// </exception>
        public T Pop()
        {
            /*
             * Algorithm:
             * 1. Check whether the stack contains any values.
             * 2. Read the value from the top of the stack.
             * 3. Remove the last value from the internal dynamic array.
             * 4. Return the value that was removed.
             */

            // Step 1: The top value cannot be removed from an empty stack.
            if (IsEmpty())
            {
                throw new InvalidOperationException(
                    "Cannot pop a value from an empty stack.");
            }

            // Step 2: Read the value from the top of the stack.
            T val = Peek();

            // Step 3: Remove the value from the internal dynamic array.
            _arr.RemoveLast();

            // Step 4: Return the removed value.
            return val;
        }

        /// <summary>
        /// Returns the number of values currently stored in the stack.
        /// Runs in O(1) time complexity.
        /// </summary>
        /// <returns>The number of values stored in the stack.</returns>
        public int Size()
        {
            /*
             * Algorithm:
             * 1. Return the number of values stored in the internal dynamic array.
             */

            // Step 1: Return current stack size.
            return _arr.Count;
        }

        /// <summary>
        /// Checks whether the stack is empty.
        /// Runs in O(1) time complexity.
        /// </summary>
        /// <returns>True if the stack is empty, otherwise false.</returns>
        public bool IsEmpty()
        {
            /*
             * Algorithm:
             * 1. Check whether the stack size is equal to zero.
             */

            // Step 1: Stack is empty when it does not contain any values.
            return _arr.Count == 0;
        }

        /// <summary>
        /// Returns the value from the top of the stack without removing it.
        /// Runs in O(1) time complexity.
        /// </summary>
        /// <returns>The value stored at the top of the stack.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the stack is empty.
        /// </exception>
        public T Peek()
        {
            /*
             * Algorithm:
             * 1. Check whether the stack contains any values.
             * 2. Return the last value from the internal dynamic array.
             */

            // Step 1: The top value cannot be read from an empty stack.
            if (IsEmpty())
            {
                throw new InvalidOperationException(
                    "Cannot peek a value from an empty stack.");
            }

            // Step 2: The last value in the internal array is the top of the stack.
            return _arr.Get(_arr.Count - 1);
        }
    }
}
