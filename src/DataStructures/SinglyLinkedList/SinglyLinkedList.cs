namespace DataStructures.SinglyLinkedList
{
    /// <summary>
    /// Represents a singly linked list data structure.
    /// </summary>
    /// <typeparam name="T">The type of elements in the singly linked list.</typeparam>
    public class SinglyLinkedList<T>
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
        public SinglyLinkedList()
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
        public void Append(T value)
        {
            SinglyLinkedListNode<T> newNode = new(value);
            Count++; // Update the count of elements in the list.
            _head ??= newNode; // If the list is empty, set the head to the new node.
            _tail?.Next = newNode; // If the list is not empty, link the current tail value to the new node.
            _tail = newNode; // Update the tail reference to the new node.
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
