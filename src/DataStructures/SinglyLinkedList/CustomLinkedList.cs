namespace DataStructures.SinglyLinkedList
{
    /// <summary>
    /// Represents a custom singly linked list implementation.
    /// </summary>
    /// <remarks>
    /// This implementation stores references to both the first node and the last node.
    /// The list is still singly linked because each node only stores a reference to the next node.
    /// The tail reference makes appending to the end an O(1) operation.
    /// </remarks>
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
        /// Creates an empty custom linked list.
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
        /// Removes the last element from the singly linked list.
        /// Runs in O(n) time complexity because the list must be traversed
        /// to find the node located before the tail. A doubly linked list could make this operation O(1).
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the list is empty.
        /// </exception>
        public void Pop()
        {
            /*
             * Algorithm:
             * 1. Check whether the list is empty.
             * 2. If the list contains only one node, clear both the head and tail.
             * 3. Otherwise, start traversing the list from the head.
             * 4. Find the node located immediately before the tail.
             * 5. Disconnect the current tail from the list.
             * 6. Set the previous node as the new tail.
             * 7. Decrease the number of elements in the list.
             */

            // Step 1: Check whether the list contains any elements.
            if (Count == 0)
            {
                // The last element cannot be removed from an empty list.
                throw new InvalidOperationException(
                    "Cannot remove an element from an empty list.");
            }

            // Step 2: Handle the case where the list contains only one node.
            if (Count == 1)
            {
                // Remove the reference to the first node.
                _head = null;

                // Remove the reference to the last node.
                _tail = null;

                // The list is now empty.
                Count = 0;

                // Stop the method because the only node has been removed.
                return;
            }

            // Step 3: Start traversing the list from the first node.
            SinglyLinkedListNode<T> previousNode = _head!;

            // Step 4: Move through the list until previousNode
            // is located immediately before the tail.
            while (previousNode.Next != _tail)
            {
                // Move the reference to the next node.
                previousNode = previousNode.Next!;
            }

            // Step 5: Disconnect the current tail from the list.
            previousNode.Next = null;

            // Step 6: Set the previous node as the new tail.
            _tail = previousNode;

            // Step 7: Decrease the number of elements in the list.
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

        /// <summary>
        /// Returns the value stored in the first node of the singly linked list.
        /// Runs in O(1) time complexity because the list stores a direct reference
        /// to the head node.
        /// </summary>
        /// <returns>The value stored in the first node.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the list is empty.
        /// </exception>
        public T GetHead()
        {
            /*
             * Algorithm:
             * 1. Check whether the list is empty.
             * 2. Access the node referenced by _head.
             * 3. Return the value stored in the head node.
             */

            // Check whether the list contains any elements.
            if (IsEmpty())
            {
                // A head value cannot be returned from an empty list.
                throw new InvalidOperationException(
                    "Cannot get the head value from an empty list.");
            }

            // Access the head node directly and return its stored value.
            return _head!.Value;
        }

        /// <summary>
        /// Returns the value stored in the last node of the singly linked list.
        /// Runs in O(1) time complexity because the list stores a direct reference
        /// to the tail node.
        /// </summary>
        /// <returns>The value stored in the last node.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the list is empty.
        /// </exception>
        public T GetTail()
        {
            /*
             * Algorithm:
             * 1. Check whether the list is empty.
             * 2. Access the node referenced by _tail.
             * 3. Return the value stored in the tail node.
             */

            // Check whether the list contains any elements.
            if (IsEmpty())
            {
                // A tail value cannot be returned from an empty list.
                throw new InvalidOperationException(
                    "Cannot get the tail value from an empty list.");
            }

            // Access the tail node directly and return its stored value.
            return _tail!.Value;
        }

        /// <summary>
        /// Reverses the order of all nodes in the singly linked list.
        /// Runs in O(n) time complexity because every node must be visited.
        /// Runs in O(1) space complexity because only a few additional
        /// node references are used.
        /// </summary>
        public void Reverse()
        {
            /*
             * Algorithm:
             * 1. Store the current head because it will become the new tail.
             * 2. Create a previous-node reference starting as null.
             * 3. Create a current-node reference starting at the head.
             * 4. Repeat until the current node becomes null:
             *      a. Store the next node before changing any references.
             *      b. Reverse the current node's Next reference.
             *      c. Move the previous-node reference to the current node.
             *      d. Move the current-node reference to the saved next node.
             * 5. Set the previous head as the new tail.
             * 6. Set the last processed node as the new head.
             */

            // Step 1: Store the current head.
            // After reversing the list, the current head will become the new tail.
            SinglyLinkedListNode<T>? oldHead = _head;

            // Step 2: There is no node before the current head,
            // so the previous-node reference initially points to null.
            SinglyLinkedListNode<T>? previousNode = null;

            // Step 3: Start traversing the list from the current head.
            SinglyLinkedListNode<T>? currentNode = _head;

            // Step 4: Continue until every node in the list has been processed.
            while (currentNode is not null)
            {
                // Step 4a: Store the next node before reversing the reference.
                // Without this variable, the remaining part of the list would be lost.
                SinglyLinkedListNode<T>? nextNode = currentNode.Next;

                // Step 4b: Reverse the current node's reference.
                // Instead of pointing forward, the current node now points backward.
                currentNode.Next = previousNode;

                // Step 4c: Move previousNode forward to the current node.
                previousNode = currentNode;

                // Step 4d: Move currentNode forward to the saved next node.
                currentNode = nextNode;
            }

            // Step 5: The previous head is now the last node in the reversed list.
            _tail = oldHead;

            // Step 6: previousNode points to the last processed node,
            // which is now the first node in the reversed list.
            _head = previousNode;
        }

    }
}


//TODO: Detecting cycle, 
