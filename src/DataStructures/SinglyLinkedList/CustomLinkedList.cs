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
        /// Inserts a new value at the specified index in the singly linked list.
        /// The index starts at 0.
        /// Runs in O(n) time complexity because the list may need to be traversed.
        /// </summary>
        /// <param name="index">
        /// The zero-based index at which the new value should be inserted.
        /// A value equal to Count adds the element to the end of the list.
        /// </param>
        /// <param name="value">The value to insert into the list.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the index is less than 0 or greater than Count.
        /// </exception>
        public void AddAtIndex(int index, T value)
        {
            /*
             * Algorithm:
             * 1. Check whether the provided index is within the valid range.
             * 2. If the index is 0, add the value to the head of the list.
             * 3. If the index is equal to Count, add the value to the tail.
             * 4. Otherwise, find the node located immediately before the insertion index.
             * 5. Create a new node containing the provided value.
             * 6. Make the new node point to the node currently after the previous node.
             * 7. Make the previous node point to the new node.
             * 8. Increase the number of elements in the list.
             */

            // Step 1: Check whether the index is valid for an insertion operation.
            if (index < 0 || index > Count)
            {
                // Valid insertion indexes range from 0 to Count.
                throw new ArgumentOutOfRangeException(
                    nameof(index),
                    "Index is out of range.");
            }

            // Step 2: Adding at index 0 is the same as adding to the head.
            if (index == 0)
            {
                AddToHead(value);
                return;
            }

            // Step 3: Adding at index Count is the same as adding to the tail.
            if (index == Count)
            {
                AddToTail(value);
                return;
            }

            // Step 4: Start traversing the list from the head.
            SinglyLinkedListNode<T>? previousNode = _head;

            // Move to the node located immediately before the insertion index.
            // For index 3, we need to stop at index 2.
            for (int currentIndex = 0;
                 currentIndex < index - 1;
                 currentIndex++)
            {
                // Move to the next node in the list.
                previousNode = previousNode!.Next;
            }

            // Step 5: Create the node that will be inserted into the list.
            SinglyLinkedListNode<T> newNode = new(value);

            // Step 6: Connect the new node to the part of the list after previousNode.
            newNode.Next = previousNode!.Next;

            // Step 7: Connect previousNode to the new node.
            previousNode.Next = newNode;

            // Step 8: Increase the number of elements in the list.
            Count++;
        }

        /// <summary>
        /// Removes the node located at the specified index from the singly linked list.
        /// The index starts at 0.
        /// Runs in O(n) time complexity because the list may need to be traversed.
        /// </summary>
        /// <param name="index">The zero-based index of the node to remove.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the index is less than 0 or greater than or equal to Count.
        /// </exception>
        public void DeleteAtIndex(int index)
        {
            /*
             * Algorithm:
             * 1. Check whether the provided index is within the valid range.
             * 2. If the first node should be removed, move the head to the second node.
             * 3. If the removed node was the only node, also clear the tail reference.
             * 4. Otherwise, find the node immediately before the node being removed.
             * 5. Store a reference to the node that should be removed.
             * 6. Make the previous node point to the node after the removed node.
             * 7. If the removed node was the tail, update the tail reference.
             * 8. Disconnect the removed node from the list.
             * 9. Decrease the number of elements in the list.
             */

            // Step 1: Check whether the requested index exists in the list.
            if (index < 0 || index >= Count)
            {
                // Valid deletion indexes range from 0 to Count - 1.
                throw new ArgumentOutOfRangeException(
                    nameof(index),
                    "Index is out of range.");
            }

            // Step 2: Handle removing the first node separately.
            if (index == 0)
            {
                // Store the current head so that it can be disconnected later.
                SinglyLinkedListNode<T> nodeToRemove = _head!;

                // Move the head reference to the second node.
                _head = _head!.Next;

                // Decrease the number of elements in the list.
                Count--;

                // Step 3: If the list is now empty, there is no tail node.
                if (Count == 0)
                {
                    _tail = null;
                }

                // Disconnect the removed node from the remaining list.
                nodeToRemove.Next = null;
                return;
            }

            // Step 4: Start traversing the list from the head.
            SinglyLinkedListNode<T>? previousNode = _head;

            // Move to the node located immediately before the node being removed.
            for (int currentIndex = 0;
                 currentIndex < index - 1;
                 currentIndex++)
            {
                // Move to the next node in the list.
                previousNode = previousNode!.Next;
            }

            // Step 5: Store a reference to the node that should be removed.
            SinglyLinkedListNode<T> nodeToDelete = previousNode!.Next!;

            // Step 6: Skip the removed node by connecting the previous node
            // directly to the node after the removed node.
            previousNode.Next = nodeToDelete.Next;

            // Step 7: If the removed node was the tail,
            // the previous node becomes the new tail.
            if (nodeToDelete == _tail)
            {
                _tail = previousNode;
            }

            // Step 8: Disconnect the removed node from the list.
            nodeToDelete.Next = null;

            // Step 9: Decrease the number of elements in the list.
            Count--;
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