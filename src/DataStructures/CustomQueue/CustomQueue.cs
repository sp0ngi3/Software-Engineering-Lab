using DataStructures.SinglyLinkedList;

namespace DataStructures.CustomQueue
{
    /// <summary>
    /// Represents a custom queue implementation.
    /// </summary>
    /// <remarks>
    /// A queue works in FIFO order, which means First In, First Out.
    /// The first value added to the queue is the first value removed from it.
    /// This implementation uses linked nodes as the internal storage.
    /// </remarks>
    /// <typeparam name="T">The type of elements stored in the queue.</typeparam>
    public class CustomQueue<T>
    {
        /// <summary>
        /// First node in the queue.
        /// This is the value that will be removed first.
        /// </summary>
        private SinglyLinkedListNode<T>? _left;

        /// <summary>
        /// Last node in the queue.
        /// This is where new values are added.
        /// </summary>
        private SinglyLinkedListNode<T>? _right;

        /// <summary>
        /// Provides the number of values currently stored in the queue.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Creates a new empty queue.
        /// </summary>
        public CustomQueue()
        {
            _left = null;
            _right = null;
            Count = 0;
        }

        /// <summary>
        /// Adds a new value to the back of the queue.
        /// Runs in O(1) time complexity because the queue keeps a reference to the last node.
        /// </summary>
        /// <param name="item">The value to add to the queue.</param>
        public void Enqueue(T item)
        {
            /*
             * Algorithm:
             * 1. Create a new node for the provided value.
             * 2. Check whether the queue already has a back node.
             * 3. If the queue is not empty, connect the current back node to the new node.
             * 4. Move the back pointer to the new node.
             * 5. If the queue is empty, set both front and back to the new node.
             * 6. Increase the number of values stored in the queue.
             */

            // Step 1: Wrap the value in a linked list node.
            SinglyLinkedListNode<T> newNode = new SinglyLinkedListNode<T>(item);

            // Step 2: If _right exists, then the queue already contains at least one value.
            if (_right is not null)
            {
                // Step 3: The old back node should now point to the new back node.
                _right.Next = newNode;

                // Step 4: Move the back pointer to the new node.
                _right = newNode;
            }
            else
            {
                // Step 5: Empty queue means the new node is both front and back.
                _left = newNode;
                _right = newNode;
            }

            // Step 6: Store the current queue size.
            Count++;
        }

        /// <summary>
        /// Removes and returns the value from the front of the queue.
        /// Runs in O(1) time complexity because the queue keeps a reference to the first node.
        /// </summary>
        /// <returns>The value removed from the front of the queue.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the queue is empty.
        /// </exception>
        public T Dequeue()
        {
            /*
             * Algorithm:
             * 1. Check whether the queue contains any values.
             * 2. Read the value from the front node.
             * 3. Move the front pointer to the next node.
             * 4. If the queue became empty, also clear the back pointer.
             * 5. Decrease the number of values stored in the queue.
             * 6. Return the removed value.
             */

            // Step 1: The front value cannot be removed from an empty queue.
            if (_left is null)
            {
                throw new InvalidOperationException(
                    "Cannot dequeue a value from an empty queue.");
            }

            // Step 2: Save the value before moving the front pointer.
            T value = _left.Value;

            // Step 3: The next node becomes the new front.
            _left = _left.Next;

            // Step 4: If there is no front node anymore, the queue is now empty.
            if (_left is null)
            {
                _right = null;
            }

            // Step 5: Store the current queue size.
            Count--;

            // Step 6: Return the removed value.
            return value;
        }

        /// <summary>
        /// Returns the value from the front of the queue without removing it.
        /// Runs in O(1) time complexity.
        /// </summary>
        /// <returns>The value stored at the front of the queue.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the queue is empty.
        /// </exception>
        public T Peek()
        {
            /*
             * Algorithm:
             * 1. Check whether the queue contains any values.
             * 2. Return the value from the front node.
             */

            // Step 1: The front value cannot be read from an empty queue.
            if (_left is null)
            {
                throw new InvalidOperationException(
                    "Cannot peek a value from an empty queue.");
            }

            // Step 2: The left node is the front of the queue.
            return _left.Value;
        }

        /// <summary>
        /// Returns the number of values currently stored in the queue.
        /// Runs in O(1) time complexity.
        /// </summary>
        /// <returns>The number of values stored in the queue.</returns>
        public int Size()
        {
            /*
             * Algorithm:
             * 1. Return the value stored in Count.
             */

            // Step 1: Return current queue size.
            return Count;
        }

        /// <summary>
        /// Checks whether the queue is empty.
        /// Runs in O(1) time complexity.
        /// </summary>
        /// <returns>True if the queue is empty, otherwise false.</returns>
        public bool IsEmpty()
        {
            /*
             * Algorithm:
             * 1. Check whether the queue size is equal to zero.
             */

            // Step 1: Queue is empty when it does not contain any values.
            return Count == 0;
        }

        /// <summary>
        /// Prints the values currently stored in the queue from front to back.
        /// Runs in O(n) time complexity because every node is visited once.
        /// </summary>
        public void Print()
        {
            /*
             * Algorithm:
             * 1. Start at the front node.
             * 2. While the current node exists, print its value.
             * 3. Move to the next node.
             */

            // Step 1: Start from the front of the queue.
            SinglyLinkedListNode<T>? current = _left;

            // Step 2: Visit every node until we reach the end.
            while (current is not null)
            {
                Console.WriteLine($"{current.Value} -> ");

                // Step 3: Move to the next node.
                current = current.Next;
            }

            Console.WriteLine();
        }
    }
}
