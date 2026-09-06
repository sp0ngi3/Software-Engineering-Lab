namespace DataStructures.CustomBinarySearchTree
{
    /// <summary>
    /// Provides search operations for a custom binary search tree.
    /// </summary>
    /// <remarks>
    /// Search uses the binary search tree rule.
    /// Smaller values are searched on the left side, and greater values are searched on the right side.
    /// </remarks>
    public static class CustomBinarySearchTreeSearch
    {
        /// <summary>
        /// Checks whether the target value exists in the binary search tree.
        /// Usually runs in O(log n) time complexity when the tree is balanced.
        /// Can run in O(n) time complexity when the tree is shaped like a linked list.
        /// Runs in O(h) space complexity because recursive calls use the call stack,
        /// where h is the height of the tree.
        /// </summary>
        /// <param name="root">The root node where the search starts.</param>
        /// <param name="target">The value to search for.</param>
        /// <typeparam name="T">The type of value stored in the tree.</typeparam>
        /// <returns>True when the target exists in the tree; otherwise false.</returns>
        public static bool SearchNode<T>(CustomBinarySearchTreeNode<T>? root, T target)
            where T : IComparable<T>
        {
            /*
             * Algorithm:
             * 1. Check whether the current node is null.
             * 2. If the current node is null, the target was not found.
             * 3. Compare the target with the current node value.
             * 4. If the target is greater, search on the right side.
             * 5. If the target is smaller, search on the left side.
             * 6. If the values are equal, return true.
             */

            // Step 1-2: Null means we reached the end of this path and did not find the value.
            if (root is null)
            {
                return false;
            }

            // Step 3: Compare target with the current node value.
            int comparison = target.CompareTo(root.Value);

            // Step 4: Greater values should be on the right side of a binary search tree.
            if (comparison > 0)
            {
                return SearchNode(root.Right, target);
            }

            // Step 5: Smaller values should be on the left side of a binary search tree.
            if (comparison < 0)
            {
                return SearchNode(root.Left, target);
            }

            // Step 6: The current node stores the target value.
            return true;
        }
    }
}
