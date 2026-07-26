namespace DataStructures.SinglyLinkedList
{
    /// <summary>
    /// Represents a singly linked list data structure.
    /// </summary>
    /// <typeparam name="T">The type of elements in the singly linked list.</typeparam>
    public class CustomLinkedList<T>
    {
        /// <summary>
        /// Reference to the start of the list.
        /// </summary>
        private SinglyLinkedListNode<T>? _head;

        /// <summary>
        /// Reference to the end of the list.
        /// </summary>
        private SinglyLinkedListNode<T>? _tail;

        /// <summary>
        /// Provides the number of elements in the singly linked list.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Creates a new instance of the SinglyLinkedList class with an initial value.
        /// </summary>
        public CustomLinkedList()
        {
            _head = null;
            _tail = null;
            Count = 0;
        }

        /// <summary>
        /// Appends a new value to the end of the singly linked list.
        /// Works in O(1) time complexity.
        /// </summary>
        /// <param name="value">The value to append to the list.</param>
        public void AddToTail(T value)
        {
            SinglyLinkedListNode<T> newNode = new(value);
            Count++; // Update the count of elements in the list.
            _head ??= newNode; // If the list is empty, set the head to the new node.
            _tail?.Next = newNode; // If the list is not empty, link the current tail value to the new node.
            _tail = newNode; // Update the tail reference to the new node.
        }


        /// <summary>
        /// Returns the value stored at the specified index in the singly linked list.
        /// The index starts at 0.
        /// Runs in O(n) time complexity because the list must be traversed from the head.
        /// </summary>
        /// <param name="index">The zero-based index of the value to return.</param>
        /// <returns>The value stored at the specified index.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the index is less than 0 or greater than or equal to Count.
        /// </exception>
        public T Get(int index)
        {
            /*
            * Algorithm:
            * 1. Check whether the provided index is within the valid range.
            * 2. Start traversing the linked list from the head node.
            * 3. Move to the next node until the requested index is reached.
            * 4. Return the value stored in the current node.
            */

            // Check whether the requested index exists in the list.
            if (index < 0 || index >= Count)
            {
                // Stop the method when the index is outside the valid range.
                throw new ArgumentOutOfRangeException(
                    nameof(index),
                    "Index is out of range.");
            }

            // Start traversing the list from its first node.
            SinglyLinkedListNode<T>? currentNode = _head;

            // Move through the list until the requested index is reached.
            for (int currentIndex = 0; currentIndex < index; currentIndex++)
            {
                // Move the reference to the next node in the list.
                currentNode = currentNode!.Next;
            }

            // Return the value stored in the node at the requested index.
            return currentNode!.Value;
        }

        /// <summary>
        /// Adds a new value to the beginning of the singly linked list.
        /// Runs in O(1) time complexity.
        /// </summary>
        /// <param name="value">The value to add to the beginning of the list.</param>
        public void AddToHead(T value)
        {
            /*
             * Algorithm:
             * 1. Create a new node containing the provided value.
             * 2. Make the new node point to the current head node.
             * 3. Update the head reference so that it points to the new node.
             * 4. If the list was empty, also set the tail to the new node.
             * 5. Increase the number of elements in the list.
             */

            // Step 1: Create a new node containing the provided value.
            SinglyLinkedListNode<T> newNode = new(value);

            // Step 2: Make the new node point to the current first node.
            // If the list is empty, _head is null, so newNode.Next will also be null.
            newNode.Next = _head;

            // Step 3: Set the new node as the first node in the list.
            _head = newNode;

            // Step 4: If the list was empty, the new node is also the last node.
            if (_tail is null)
            {
                _tail = newNode;
            }

            // Step 5: Increase the number of elements in the list.
            Count++;
        }

        /// <summary>
        /// Checks if the singly linked list is empty.
        /// Runs in O(1) time complexity.
        /// </summary>
        /// <returns>True if the list is empty, otherwise false.</returns>
        public bool IsEmpty()
        {
            return Count == 0;
        }
    }
}


//TODO: Implement reversing, detecting cycle, AddToHead, AddAtIndex, DeleteAtIndex