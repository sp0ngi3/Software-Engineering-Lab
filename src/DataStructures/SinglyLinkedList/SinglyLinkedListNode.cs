namespace DataStructures.SinglyLinkedList
{
    /// <summary>
    /// Represents a node in a singly linked list.
    /// </summary>
    /// <typeparam name="T">The type of elements in the singly linked list.</typeparam>
    public class SinglyLinkedListNode<T>
    {
        public T Value { get; set; }
        public SinglyLinkedListNode<T>? Next { get; set; }
        public SinglyLinkedListNode(T value)
        {
            Value = value;
            Next = null;
        }
    }

    // A singly linked list node consists of two things: Data and the pointer to the next node.
    // The last node in the singly linked list points to null.
}
