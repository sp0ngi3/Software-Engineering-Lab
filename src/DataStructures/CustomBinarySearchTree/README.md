# Custom Binary Search Tree

A binary search tree is a node-based data structure.

Each node stores:

- A value
- A reference to the left child
- A reference to the right child

## Binary Search Tree Rule

For every node:

- Smaller values should go to the left.
- Greater values should go to the right.

Example:

```text
        10
       /  \
      5    15
     / \     \
    3   7     20
```

If we search for `7`, we start at `10`.

`7` is smaller than `10`, so we move left.

Then we are at `5`.

`7` is greater than `5`, so we move right.

Then we find `7`.

## Search

Search can be written recursively because every move goes into a smaller part of the tree.

Base case:

```text
current node is null
```

Recursive cases:

```text
target > current value -> search right
target < current value -> search left
```

Found case:

```text
target == current value
```

## Insert

Insert also uses the binary search tree rule.

If the current node is `null`, we found the place where the new node should be created.

Recursive cases:

```text
value > current value -> insert right
value < current value -> insert left
```

In this first version, duplicate values are ignored.

Example insert order:

```text
10, 5, 15, 3, 7, 20
```

Result:

```text
        10
       /  \
      5    15
     / \     \
    3   7     20
```

## Remove

Remove is a little trickier because the node can have different shapes.

There are three main cases:

- The node has no left child.
- The node has no right child.
- The node has two children.

If the node has no left child, the right child can replace it.

If the node has no right child, the left child can replace it.

If the node has two children, this implementation finds the minimum value from the right subtree.

That node is called the in-order successor.

Then we copy that value into the current node and remove the duplicate from the right subtree.

## Printing The Tree

The tree can be printed as a small text diagram.

Example:

```text
Root: 10
|-- L: 5
|   |-- L: 3
|   `-- R: 7
`-- R: 15
    `-- R: 20
```

`L` means left child.

`R` means right child.

This is useful while debugging because it shows the real shape of the tree, not only the sorted order of values.

## Depth-First Search

Depth-first search means we go as deep as possible before going back to another branch.

In trees, DFS is usually written recursively.

There are three common DFS orders:

- Inorder
- Preorder
- Postorder

All three visit every node, but they visit the current node at a different moment.

### Inorder Traversal

Inorder means:

```text
left -> root -> right
```

For a binary search tree, inorder traversal returns values in sorted order.

Example:

```text
        10
       /  \
      5    15
     / \     \
    3   7     20
```

Inorder result:

```text
[3, 5, 7, 10, 15, 20]
```

### Preorder Traversal

Preorder means:

```text
root -> left -> right
```

Preorder visits the current node before its children.

Preorder result:

```text
[10, 5, 3, 7, 15, 20]
```

### Postorder Traversal

Postorder means:

```text
left -> right -> root
```

Postorder visits children before the current node.

Postorder result:

```text
[3, 7, 5, 20, 15, 10]
```

## Breadth-First Search

Breadth-first search means we visit the tree level by level.

For trees, this is also called level-order traversal.

BFS usually uses a queue.

The idea is:

- Add the root to the queue.
- Remove the node from the front of the queue.
- Visit that node.
- Add its left child if it exists.
- Add its right child if it exists.
- Repeat until the queue is empty.

BFS result:

```text
[10, 5, 15, 3, 7, 20]
```

## Complexity

| Operation | Time complexity | Space complexity | Notes |
| --- | --- | --- | --- |
| `SearchNode(root, target)` balanced tree | `O(log n)` | `O(log n)` | Every step removes about half of the remaining tree. |
| `SearchNode(root, target)` unbalanced tree | `O(n)` | `O(n)` | The tree can become shaped like a linked list. |
| `Insert(root, value)` balanced tree | `O(log n)` | `O(log n)` | Moves left or right until it finds an empty place. |
| `Insert(root, value)` unbalanced tree | `O(n)` | `O(n)` | Can become slow when the tree is shaped like a linked list. |
| `Remove(root, value)` balanced tree | `O(log n)` | `O(log n)` | Searches for the value and may also find a successor. |
| `Remove(root, value)` unbalanced tree | `O(n)` | `O(n)` | Can walk through most of the tree. |
| `MinValueNode(root)` | `O(h)` | `O(1)` | Walks down the left side of the tree. |
| `ToPrettyString(root)` | `O(n)` | `O(h)` | Visits every node and uses recursion to keep the tree shape. |
| `Print(root)` | `O(n)` | `O(h)` | Builds the readable tree text and writes it to the console. |
| `InOrderTraversal(root)` | `O(n)` | `O(h)` | DFS order: left, root, right. |
| `PreOrderTraversal(root)` | `O(n)` | `O(h)` | DFS order: root, left, right. |
| `PostOrderTraversal(root)` | `O(n)` | `O(h)` | DFS order: left, right, root. |
| `BreadthFirstTraversal(root)` | `O(n)` | `O(n)` | Uses a queue and visits values level by level. |

## Notes For This Implementation

Current public types:

- `CustomBinarySearchTreeNode<T>`
- `CustomBinarySearchTreeSearch`
- `CustomBinarySearchTreeOperations`

Current public operations:

- `SearchNode`
- `Insert`
- `Remove`
- `MinValueNode`
- `ToPrettyString`
- `Print`
- `InOrderTraversal`
- `PreOrderTraversal`
- `PostOrderTraversal`
- `BreadthFirstTraversal`

This is still a small learning version.

Future ideas:

- Add `Contains`
- Add iterative search
- Add iterative DFS traversal examples
- Add a full tree wrapper class with a private root field
