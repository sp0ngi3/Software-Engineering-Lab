using System.Collections;

namespace DataStructures.CustomDynamicArrays
{
    /// <summary>
    /// Represents a custom dynamic array implementation.
    /// </summary>
    /// <typeparam name="T">The type of elements stored in the dynamic array.</typeparam>
    public class CustomDynamicArray<T> : IEnumerable<T>
    {
        /// <summary>
        /// Initial number of values that can be stored before the first resize.
        /// </summary>
        private const int InitialCapacity = 8;

        /// <summary>
        /// Internal array that stores the values.
        /// </summary>
        private T[] _arr;

        /// <summary>
        /// Number of values currently stored in the dynamic array.
        /// </summary>
        private int _size;

        /// <summary>
        /// Number of values that can be stored before resizing is needed.
        /// </summary>
        private int _capacity;

        /// <summary>
        /// Provides the number of values currently stored in the dynamic array.
        /// </summary>
        public int Count => _size;

        /// <summary>
        /// Provides the current size of the internal array.
        /// </summary>
        public int Capacity => _capacity;

        /// <summary>
        /// Creates a new empty dynamic array with the initial capacity equal to 8.
        /// </summary>
        public CustomDynamicArray()
        {
            _capacity = InitialCapacity;
            _size = 0;
            _arr = new T[_capacity];
        }

        /// <summary>
        /// Returns the value stored at the specified index.
        /// Runs in O(1) time complexity because arrays support direct indexing.
        /// </summary>
        /// <param name="i">The zero-based index of the value to return.</param>
        /// <returns>The value stored at the specified index.</returns>
        /// <exception cref="IndexOutOfRangeException">
        /// Thrown when the index is outside the range of stored values.
        /// </exception>
        public T Get(int i)
        {
            /*
             * Algorithm:
             * 1. Check whether the requested index exists in the dynamic array.
             * 2. If the index is valid, return the value from the internal array.
             * 3. If the index is invalid, throw an exception.
             */

            // Step 1: Check whether the requested index exists.
            if (i >= 0 && i < _size)
            {
                // Step 2: Return the value stored at the requested index.
                return _arr[i];
            }

            // Step 3: Stop the method when the index is outside the stored values.
            throw new IndexOutOfRangeException();
        }

        /// <summary>
        /// Replaces the value stored at the specified index.
        /// Runs in O(1) time complexity because arrays support direct indexing.
        /// </summary>
        /// <param name="val">The new value to store in the dynamic array.</param>
        /// <param name="i">The zero-based index where the value should be replaced.</param>
        /// <exception cref="IndexOutOfRangeException">
        /// Thrown when the index is outside the range of stored values.
        /// </exception>
        public void Insert(T val, int i)
        {
            /*
             * Algorithm:
             * 1. Check whether the requested index exists in the dynamic array.
             * 2. If the index is valid, replace the value in the internal array.
             * 3. If the index is invalid, throw an exception.
             */

            // Step 1: Check whether the requested index exists.
            if (i >= 0 && i < _size)
            {
                // Step 2: Replace the value at the requested index.
                _arr[i] = val;
                return;
            }

            // Step 3: Stop the method when the index is outside the stored values.
            throw new IndexOutOfRangeException();
        }

        /// <summary>
        /// Adds a new value to the end of the dynamic array.
        /// Usually runs in O(1) time complexity, but can run in O(n)
        /// when the internal array has to be resized.
        /// </summary>
        /// <param name="val">The value to add to the dynamic array.</param>
        public void Add(T val)
        {
            /*
             * Algorithm:
             * 1. Check whether the internal array is full.
             * 2. If the internal array is full, resize it.
             * 3. Store the new value at the next free index.
             * 4. Increase the number of stored values.
             */

            // Step 1-2: If the internal array is full, create a bigger one.
            if (_size == _capacity)
            {
                Resize();
            }

            // Step 3: Store the new value at the first free index.
            _arr[_size] = val;

            // Step 4: Increase the number of stored values.
            _size++;
        }

        /// <summary>
        /// Removes the value stored at the specified index.
        /// Runs in O(n) time complexity because values after the removed index
        /// must be shifted one position to the left.
        /// </summary>
        /// <param name="i">The zero-based index of the value to remove.</param>
        /// <exception cref="IndexOutOfRangeException">
        /// Thrown when the index is outside the range of stored values.
        /// </exception>
        public void RemoveAt(int i)
        {
            /*
             * Algorithm:
             * 1. Check whether the requested index exists in the dynamic array.
             * 2. Move every value after the removed index one position to the left.
             * 3. Clear the old last value.
             * 4. Decrease the number of stored values.
             * 5. Shrink the internal array if it is much bigger than needed.
             */

            // Step 1: Check whether the requested index exists.
            if (i < 0 || i >= _size)
            {
                throw new IndexOutOfRangeException();
            }

            // Step 2: Shift values left to fill the removed position.
            for (int currentIndex = i; currentIndex < _size - 1; currentIndex++)
            {
                _arr[currentIndex] = _arr[currentIndex + 1];
            }

            // Step 3: Clear the old last value so the array does not keep an unnecessary reference.
            _arr[_size - 1] = default!;

            // Step 4: Decrease the number of stored values.
            _size--;

            // Step 5: Shrink the internal array if too much capacity is unused.
            ShrinkIfNeeded();
        }

        /// <summary>
        /// Removes the last value from the dynamic array.
        /// Runs in O(1) time complexity unless shrinking is needed.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the dynamic array is empty.
        /// </exception>
        public void RemoveLast()
        {
            /*
             * Algorithm:
             * 1. Check whether the dynamic array contains any values.
             * 2. Clear the current last value.
             * 3. Decrease the number of stored values.
             * 4. Shrink the internal array if it is much bigger than needed.
             */

            // Step 1: The last value cannot be removed from an empty dynamic array.
            if (_size == 0)
            {
                throw new InvalidOperationException(
                    "Cannot remove a value from an empty dynamic array.");
            }

            // Step 2: Clear the current last value.
            _arr[_size - 1] = default!;

            // Step 3: Decrease the number of stored values.
            _size--;

            // Step 4: Shrink the internal array if too much capacity is unused.
            ShrinkIfNeeded();
        }

        /// <summary>
        /// Copies all stored values from the dynamic array into a new array.
        /// Runs in O(n) time complexity because every stored value must be copied.
        /// Runs in O(n) space complexity because a new array is created.
        /// </summary>
        /// <returns>An array containing all stored values in the same order.</returns>
        public T[] ToArray()
        {
            /*
             * Algorithm:
             * 1. Create a new array with the same size as the number of stored values.
             * 2. Copy every stored value from the internal array into the new array.
             * 3. Return the new array.
             */

            // Step 1: Create a new array that stores only real values, not empty capacity.
            T[] values = new T[_size];

            // Step 2: Copy all stored values into the new array.
            for (int i = 0; i < _size; i++)
            {
                values[i] = _arr[i];
            }

            // Step 3: Return the created array.
            return values;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the stored values.
        /// Runs in O(n) time complexity when the whole dynamic array is enumerated.
        /// </summary>
        /// <returns>An enumerator for the stored values.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            /*
             * Algorithm:
             * 1. Start from the first stored index.
             * 2. Return the current value.
             * 3. Move to the next stored index.
             * 4. Continue until all stored values are returned.
             */

            // Step 1-4: Return only stored values, not unused capacity.
            for (int i = 0; i < _size; i++)
            {
                yield return _arr[i];
            }
        }

        /// <summary>
        /// Returns a non-generic enumerator that iterates through the stored values.
        /// </summary>
        /// <returns>An enumerator for the stored values.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Creates a bigger internal array and copies existing values into it.
        /// Runs in O(n) time complexity because every stored value must be copied.
        /// </summary>
        private void Resize()
        {
            /*
             * Algorithm:
             * 1. Double the current capacity.
             * 2. Create a new array with the new capacity.
             * 3. Copy all existing values into the new array.
             * 4. Replace the old internal array with the new one.
             */

            // Step 1: Double the current capacity.
            int newCapacity = 2 * _capacity;

            // Step 2-4: Resize the internal array to the new capacity.
            ResizeTo(newCapacity);
        }

        /// <summary>
        /// Shrinks the internal array when too much capacity is unused.
        /// Runs in O(n) time complexity only when shrinking happens.
        /// </summary>
        private void ShrinkIfNeeded()
        {
            /*
             * Algorithm:
             * 1. Do not shrink below the initial capacity.
             * 2. Check whether the dynamic array uses at most 25% of its capacity.
             * 3. If yes, cut the capacity in half.
             */

            // Step 1: Keep the minimum capacity at the initial capacity.
            if (_capacity == InitialCapacity)
            {
                return;
            }

            // Step 2: If more than 25% is used, shrinking is not needed yet.
            if (_size > _capacity / 4)
            {
                return;
            }

            // Step 3: Cut the capacity in half, but never below the initial capacity.
            int newCapacity = _capacity / 2;

            if (newCapacity < InitialCapacity)
            {
                newCapacity = InitialCapacity;
            }

            ResizeTo(newCapacity);
        }

        /// <summary>
        /// Creates a new internal array with the requested capacity and copies existing values into it.
        /// Runs in O(n) time complexity because every stored value must be copied.
        /// </summary>
        /// <param name="newCapacity">The new capacity of the internal array.</param>
        private void ResizeTo(int newCapacity)
        {
            /*
             * Algorithm:
             * 1. Update the capacity value.
             * 2. Create a new array with the requested capacity.
             * 3. Copy all existing values into the new array.
             * 4. Replace the old internal array with the new one.
             */

            // Step 1: Update the capacity value.
            _capacity = newCapacity;

            // Step 2: Create a new array with the requested capacity.
            T[] newArr = new T[_capacity];

            // Step 3: Copy all existing values into the new array.
            for (int i = 0; i < _size; i++)
            {
                newArr[i] = _arr[i];
            }

            // Step 4: Replace the old internal array with the new one.
            _arr = newArr;
        }
    }
}
