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
        /// Creates a new instance of the SinglyLinkedList class with an initial value.
        /// </summary>
        /// <param name="value">The initial value to be stored in the list.</param>
        public SinglyLinkedList(T value)
        {
            _head = new SinglyLinkedListNode<T>(value);
            _tail = _head;
        }
    }
}
