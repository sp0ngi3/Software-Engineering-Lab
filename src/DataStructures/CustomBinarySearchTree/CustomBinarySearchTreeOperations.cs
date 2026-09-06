using DataStructures.CustomQueue;
using System.Text;

namespace DataStructures.CustomBinarySearchTree
{
    /// <summary>
    /// Provides basic operations for a custom binary search tree.
    /// </summary>
    /// <remarks>
    /// These operations work with the root node directly.
    /// Insert and remove return the root because the root can change, especially when removing it.
    /// </remarks>
    public static class CustomBinarySearchTreeOperations
    {
        /// <summary>
        /// Inserts a new value into the binary search tree and returns the root node.
        /// Usually runs in O(log n) time complexity when the tree is balanced.
        /// Can run in O(n) time complexity when the tree is shaped like a linked list.
        /// Runs in O(h) space complexity because recursive calls use the call stack,
        /// where h is the height of the tree.
        /// </summary>
        /// <param name="root">The root node where the insert starts.</param>
        /// <param name="value">The value to insert.</param>
        /// <typeparam name="T">The type of value stored in the tree.</typeparam>
        /// <returns>The root node after insertion.</returns>
        public static CustomBinarySearchTreeNode<T> Insert<T>(
            CustomBinarySearchTreeNode<T>? root,
            T value)
            where T : IComparable<T>
        {
            /*
             * Algorithm:
             * 1. Check whether the current node is null.
             * 2. If the current node is null, create a new node with the provided value.
             * 3. Compare the value with the current node value.
             * 4. If the value is greater, insert it on the right side.
             * 5. If the value is smaller, insert it on the left side.
             * 6. If the value is equal, do nothing in this simple version.
             * 7. Return the root node.
             */

            // Step 1-2: Null means we found the place where the new node should be created.
            if (root is null)
            {
                return new CustomBinarySearchTreeNode<T>(value);
            }

            // Step 3: Compare the new value with the current node value.
            int comparison = value.CompareTo(root.Value);

            // Step 4: Greater values should be inserted on the right side.
            if (comparison > 0)
            {
                root.Right = Insert(root.Right, value);
            }
            // Step 5: Smaller values should be inserted on the left side.
            else if (comparison < 0)
            {
                root.Left = Insert(root.Left, value);
            }

            // Step 6-7: Duplicates are ignored for now, and the root is returned.
            return root;
        }

        /// <summary>
        /// Returns the node with the minimum value from the provided tree.
        /// Runs in O(h) time complexity because it walks down the left side of the tree.
        /// Runs in O(1) space complexity because it uses a normal loop.
        /// </summary>
        /// <param name="root">The root node where searching for the minimum starts.</param>
        /// <typeparam name="T">The type of value stored in the tree.</typeparam>
        /// <returns>The node with the minimum value, or null when the provided root is null.</returns>
        public static CustomBinarySearchTreeNode<T>? MinValueNode<T>(
            CustomBinarySearchTreeNode<T>? root)
            where T : IComparable<T>
        {
            /*
             * Algorithm:
             * 1. Start from the provided root node.
             * 2. While the current node exists and has a left child, move left.
             * 3. Return the last node reached.
             */

            // Step 1: Start from the given root.
            CustomBinarySearchTreeNode<T>? current = root;

            // Step 2: In a BST, the smallest value is always the most-left node.
            while (current is not null && current.Left is not null)
            {
                current = current.Left;
            }

            // Step 3: Return the minimum node, or null if the input was null.
            return current;
        }

        /// <summary>
        /// Removes a value from the binary search tree and returns the root node.
        /// Usually runs in O(log n) time complexity when the tree is balanced.
        /// Can run in O(n) time complexity when the tree is shaped like a linked list.
        /// Runs in O(h) space complexity because recursive calls use the call stack,
        /// where h is the height of the tree.
        /// </summary>
        /// <param name="root">The root node where the remove starts.</param>
        /// <param name="value">The value to remove.</param>
        /// <typeparam name="T">The type of value stored in the tree.</typeparam>
        /// <returns>The root node after removal, or null when the tree becomes empty.</returns>
        public static CustomBinarySearchTreeNode<T>? Remove<T>(
            CustomBinarySearchTreeNode<T>? root,
            T value)
            where T : IComparable<T>
        {
            /*
             * Algorithm:
             * 1. Check whether the current node is null.
             * 2. If it is null, the value does not exist in this path.
             * 3. Compare the value with the current node value.
             * 4. If the value is greater, remove it from the right side.
             * 5. If the value is smaller, remove it from the left side.
             * 6. If the value is found, handle three cases:
             *      a. Node has no left child, so return the right child.
             *      b. Node has no right child, so return the left child.
             *      c. Node has two children, so replace it with the minimum value from the right subtree.
             * 7. Return the root node after the links are updated.
             */

            // Step 1-2: Null means there is nothing to remove from this path.
            if (root is null)
            {
                return null;
            }

            // Step 3: Compare the value we want to remove with the current node value.
            int comparison = value.CompareTo(root.Value);

            // Step 4: Greater values should be on the right side.
            if (comparison > 0)
            {
                root.Right = Remove(root.Right, value);
            }
            // Step 5: Smaller values should be on the left side.
            else if (comparison < 0)
            {
                root.Left = Remove(root.Left, value);
            }
            else
            {
                // Step 6a: If there is no left child, the right child can replace this node.
                if (root.Left is null)
                {
                    return root.Right;
                }

                // Step 6b: If there is no right child, the left child can replace this node.
                if (root.Right is null)
                {
                    return root.Left;
                }

                // Step 6c: Two children case. Use the smallest node from the right subtree.
                CustomBinarySearchTreeNode<T> minNode = MinValueNode(root.Right)!;
                root.Value = minNode.Value;
                root.Right = Remove(root.Right, minNode.Value);
            }

            // Step 7: Return the current root after updating child links.
            return root;
        }

        /// <summary>
        /// Builds a readable text representation of the binary search tree.
        /// Runs in O(n) time complexity because every node is visited once.
        /// Runs in O(h) space complexity because recursive calls use the call stack,
        /// where h is the height of the tree.
        /// </summary>
        /// <param name="root">The root node where printing starts.</param>
        /// <typeparam name="T">The type of value stored in the tree.</typeparam>
        /// <returns>A formatted string that shows the tree structure.</returns>
        public static string ToPrettyString<T>(CustomBinarySearchTreeNode<T>? root)
        {
            /*
             * Algorithm:
             * 1. Create a StringBuilder for the output.
             * 2. If the root is null, return information that the tree is empty.
             * 3. Start building the output from the root node.
             * 4. Recursively add left and right child nodes.
             * 5. Return the formatted text.
             */

            // Step 1: StringBuilder is useful when we build text in many small steps.
            StringBuilder builder = new StringBuilder();

            // Step 2: Empty tree still gets a readable output.
            if (root is null)
            {
                builder.AppendLine("<empty tree>");
                return builder.ToString();
            }

            // Step 3-4: Build the tree text starting from the root.
            BuildPrettyString(root, builder, string.Empty, "Root", isLastChild: true);

            // Step 5: Return the final text.
            return builder.ToString();
        }

        /// <summary>
        /// Prints a readable text representation of the binary search tree to the console.
        /// Runs in O(n) time complexity because every node is visited once.
        /// </summary>
        /// <param name="root">The root node where printing starts.</param>
        /// <typeparam name="T">The type of value stored in the tree.</typeparam>
        public static void Print<T>(CustomBinarySearchTreeNode<T>? root)
        {
            /*
             * Algorithm:
             * 1. Build a readable string representation of the tree.
             * 2. Print that string to the console.
             */

            // Step 1-2: Reuse ToPrettyString so this method stays very small.
            Console.Write(ToPrettyString(root));
        }

        /// <summary>
        /// Returns values from the tree by using inorder depth-first search.
        /// For a binary search tree, this returns values in sorted order.
        /// Runs in O(n) time complexity because every node is visited once.
        /// Runs in O(h) space complexity because recursive calls use the call stack,
        /// where h is the height of the tree.
        /// </summary>
        /// <param name="root">The root node where traversal starts.</param>
        /// <typeparam name="T">The type of value stored in the tree.</typeparam>
        /// <returns>The values visited in left, root, right order.</returns>
        public static T[] InOrderTraversal<T>(CustomBinarySearchTreeNode<T>? root)
        {
            /*
             * Algorithm:
             * 1. Create a list for visited values.
             * 2. Visit the left subtree first.
             * 3. Visit the current node.
             * 4. Visit the right subtree last.
             * 5. Return all visited values as an array.
             */

            // Step 1: Store values in the order in which DFS visits them.
            List<T> values = new List<T>();

            // Step 2-4: Start recursive inorder traversal from the root.
            InOrder(root, values);

            // Step 5: Return a simple array so the result is easy to inspect and test.
            return values.ToArray();
        }

        /// <summary>
        /// Returns values from the tree by using preorder depth-first search.
        /// Runs in O(n) time complexity because every node is visited once.
        /// Runs in O(h) space complexity because recursive calls use the call stack,
        /// where h is the height of the tree.
        /// </summary>
        /// <param name="root">The root node where traversal starts.</param>
        /// <typeparam name="T">The type of value stored in the tree.</typeparam>
        /// <returns>The values visited in root, left, right order.</returns>
        public static T[] PreOrderTraversal<T>(CustomBinarySearchTreeNode<T>? root)
        {
            /*
             * Algorithm:
             * 1. Create a list for visited values.
             * 2. Visit the current node first.
             * 3. Visit the left subtree.
             * 4. Visit the right subtree last.
             * 5. Return all visited values as an array.
             */

            // Step 1: Store values in the order in which DFS visits them.
            List<T> values = new List<T>();

            // Step 2-4: Start recursive preorder traversal from the root.
            PreOrder(root, values);

            // Step 5: Return a simple array so the result is easy to inspect and test.
            return values.ToArray();
        }

        /// <summary>
        /// Returns values from the tree by using postorder depth-first search.
        /// Runs in O(n) time complexity because every node is visited once.
        /// Runs in O(h) space complexity because recursive calls use the call stack,
        /// where h is the height of the tree.
        /// </summary>
        /// <param name="root">The root node where traversal starts.</param>
        /// <typeparam name="T">The type of value stored in the tree.</typeparam>
        /// <returns>The values visited in left, right, root order.</returns>
        public static T[] PostOrderTraversal<T>(CustomBinarySearchTreeNode<T>? root)
        {
            /*
             * Algorithm:
             * 1. Create a list for visited values.
             * 2. Visit the left subtree first.
             * 3. Visit the right subtree.
             * 4. Visit the current node last.
             * 5. Return all visited values as an array.
             */

            // Step 1: Store values in the order in which DFS visits them.
            List<T> values = new List<T>();

            // Step 2-4: Start recursive postorder traversal from the root.
            PostOrder(root, values);

            // Step 5: Return a simple array so the result is easy to inspect and test.
            return values.ToArray();
        }

        /// <summary>
        /// Returns values from the tree by using breadth-first search.
        /// This is also called level-order traversal for trees.
        /// Runs in O(n) time complexity because every node is visited once.
        /// Runs in O(n) space complexity because the queue can store many nodes from one level.
        /// </summary>
        /// <param name="root">The root node where traversal starts.</param>
        /// <typeparam name="T">The type of value stored in the tree.</typeparam>
        /// <returns>The values visited level by level from left to right.</returns>
        public static T[] BreadthFirstTraversal<T>(CustomBinarySearchTreeNode<T>? root)
        {
            /*
             * Algorithm:
             * 1. Create a list for visited values.
             * 2. If the root is null, return an empty array.
             * 3. Add the root node to the queue.
             * 4. While the queue is not empty, remove the front node.
             * 5. Visit the removed node.
             * 6. Add the left child to the queue if it exists.
             * 7. Add the right child to the queue if it exists.
             * 8. Return all visited values as an array.
             */

            // Step 1: Store values in the order in which BFS visits them.
            List<T> values = new List<T>();

            // Step 2: Empty tree has no values to visit.
            if (root is null)
            {
                return values.ToArray();
            }

            // Step 3: BFS uses a queue because we want to process nodes level by level.
            CustomQueue<CustomBinarySearchTreeNode<T>> queue =
                new CustomQueue<CustomBinarySearchTreeNode<T>>();

            queue.Enqueue(root);

            // Step 4: Keep going until all queued nodes are processed.
            while (!queue.IsEmpty())
            {
                CustomBinarySearchTreeNode<T> current = queue.Dequeue();

                // Step 5: Visit the current node.
                values.Add(current.Value);

                // Step 6: Add the left child first, so each level is read from left to right.
                if (current.Left is not null)
                {
                    queue.Enqueue(current.Left);
                }

                // Step 7: Add the right child after the left child.
                if (current.Right is not null)
                {
                    queue.Enqueue(current.Right);
                }
            }

            // Step 8: Return a simple array so the result is easy to inspect and test.
            return values.ToArray();
        }

        private static void BuildPrettyString<T>(
            CustomBinarySearchTreeNode<T> node,
            StringBuilder builder,
            string prefix,
            string label,
            bool isLastChild)
        {
            /*
             * Algorithm:
             * 1. Add the current indentation prefix.
             * 2. Add information whether this is the root, left child, or right child.
             * 3. Add the current node value.
             * 4. Prepare the prefix for child nodes.
             * 5. Recursively add the left child if it exists.
             * 6. Recursively add the right child if it exists.
             */

            // Step 1: Add indentation created by previous recursive calls.
            builder.Append(prefix);

            // Step 2: Root does not need a branch marker.
            if (label == "Root")
            {
                builder.Append("Root: ");
            }
            else
            {
                builder.Append(isLastChild ? "`-- " : "|-- ");
                builder.Append(label);
                builder.Append(": ");
            }

            // Step 3: Add the current node value.
            builder.AppendLine(node.Value?.ToString());

            // Step 4: Child nodes need a prefix that visually keeps the tree shape.
            string childPrefix = label == "Root"
                ? string.Empty
                : prefix + (isLastChild ? "    " : "|   ");

            // Step 5: Add the left side first because smaller values live there.
            if (node.Left is not null)
            {
                BuildPrettyString(
                    node.Left,
                    builder,
                    childPrefix,
                    "L",
                    isLastChild: node.Right is null);
            }

            // Step 6: Add the right side after the left side.
            if (node.Right is not null)
            {
                BuildPrettyString(
                    node.Right,
                    builder,
                    childPrefix,
                    "R",
                    isLastChild: true);
            }
        }

        private static void InOrder<T>(
            CustomBinarySearchTreeNode<T>? root,
            List<T> values)
        {
            // Base case: null means there is no node to visit on this path.
            if (root is null)
            {
                return;
            }

            // Inorder means left first, current node second, right last.
            InOrder(root.Left, values);
            values.Add(root.Value);
            InOrder(root.Right, values);
        }

        private static void PreOrder<T>(
            CustomBinarySearchTreeNode<T>? root,
            List<T> values)
        {
            // Base case: null means there is no node to visit on this path.
            if (root is null)
            {
                return;
            }

            // Preorder means current node first, then left, then right.
            values.Add(root.Value);
            PreOrder(root.Left, values);
            PreOrder(root.Right, values);
        }

        private static void PostOrder<T>(
            CustomBinarySearchTreeNode<T>? root,
            List<T> values)
        {
            // Base case: null means there is no node to visit on this path.
            if (root is null)
            {
                return;
            }

            // Postorder means left first, right second, current node last.
            PostOrder(root.Left, values);
            PostOrder(root.Right, values);
            values.Add(root.Value);
        }
    }
}
