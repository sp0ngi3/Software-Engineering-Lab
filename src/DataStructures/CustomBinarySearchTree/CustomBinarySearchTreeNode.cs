namespace DataStructures.CustomBinarySearchTree
{
    /// <summary>
    /// Represents one node in a binary search tree.
    /// </summary>
    /// <remarks>
    /// A binary search tree node stores one value and references to two child nodes.
    /// Values smaller than the current node should be placed on the left side.
    /// Values greater than the current node should be placed on the right side.
    /// </remarks>
    /// <typeparam name="T">The type of value stored in the node.</typeparam>
    public class CustomBinarySearchTreeNode<T>
    {
        /// <summary>
        /// Value stored inside the current node.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Left child node.
        /// In a binary search tree, this side should contain smaller values.
        /// </summary>
        public CustomBinarySearchTreeNode<T>? Left { get; set; }

        /// <summary>
        /// Right child node.
        /// In a binary search tree, this side should contain greater values.
        /// </summary>
        public CustomBinarySearchTreeNode<T>? Right { get; set; }

        /// <summary>
        /// Creates a new binary search tree node without child nodes.
        /// </summary>
        /// <param name="value">The value stored in the node.</param>
        public CustomBinarySearchTreeNode(T value)
            : this(value, null, null)
        {
        }

        /// <summary>
        /// Creates a new binary search tree node with optional left and right child nodes.
        /// </summary>
        /// <param name="value">The value stored in the node.</param>
        /// <param name="left">The left child node.</param>
        /// <param name="right">The right child node.</param>
        public CustomBinarySearchTreeNode(
            T value,
            CustomBinarySearchTreeNode<T>? left,
            CustomBinarySearchTreeNode<T>? right)
        {
            /*
             * Algorithm:
             * 1. Store the provided value in the current node.
             * 2. Store the reference to the left child node.
             * 3. Store the reference to the right child node.
             */

            // Step 1: Store the value inside this node.
            Value = value;

            // Step 2: Store the left child reference.
            Left = left;

            // Step 3: Store the right child reference.
            Right = right;
        }
    }
}
