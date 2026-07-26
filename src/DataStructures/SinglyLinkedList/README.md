# Custom Linked List

These are personal learning notes for a custom singly linked list implementation in C#.

The goal is to understand how linked structures work internally: how nodes are connected, how references change during insertions and deletions, and why linked lists have different trade-offs than arrays.

## What Is a Linked List?

A linked list is a linear data structure that stores values in order, similar to an array. The main difference is how the values are stored and connected.

An array stores elements next to each other in contiguous memory:

```text
[10][20][30][40]
```

A linked list is built from nodes. Each node stores a value and a reference to the next node:

```text
[10] -> [20] -> [30] -> [40] -> null
```

In this repository, the node type is `SinglyLinkedListNode<T>`:

```csharp
public class SinglyLinkedListNode<T>
{
    public T Value { get; set; }
    public SinglyLinkedListNode<T>? Next { get; set; }
}
```

The list stores references to:

- `_head`: the first node in the list
- `_tail`: the last node in the list
- `Count`: the number of nodes

Having both `_head` and `_tail` does not make this a doubly linked list. It is still singly linked because each node only points to the next node. A doubly linked list node would also store a `Previous` reference.

## Traversal

Linked lists do not support direct indexing like arrays. To reach an element at a specific index, the list must start from the head and move node by node.

```text
head -> node -> node -> node -> null
```

This is why access by index is `O(n)`.

## Complexity

| Operation | Time complexity | Space complexity | Notes |
| --- | --- | --- | --- |
| `Count` | `O(1)` | `O(1)` | Count is stored as a property. |
| `IsEmpty()` | `O(1)` | `O(1)` | Checks whether `Count == 0`. |
| `GetHead()` | `O(1)` | `O(1)` | Direct access through `_head`. |
| `GetTail()` | `O(1)` | `O(1)` | Direct access through `_tail`. |
| `Get(index)` | `O(n)` | `O(1)` | Must traverse from the head. |
| `AddToHead(value)` | `O(1)` | `O(1)` | Only updates a few references. |
| `AddToTail(value)` | `O(1)` | `O(1)` | Fast because this implementation stores `_tail`. |
| `AddAtIndex(index, value)` | `O(n)` | `O(1)` | Traverses to the node before the index, except for head/tail cases. |
| `DeleteAtIndex(index)` | `O(n)` | `O(1)` | Traverses to the node before the index, except for deleting the head. |
| `Pop()` | `O(n)` | `O(1)` | Must find the node before `_tail` in a singly linked list. |
| `Reverse()` | `O(n)` | `O(1)` | Visits every node and rewires `Next` references. |

Important detail: insertion or deletion can be `O(1)` if a reference to the correct node is already available. If the list first needs to search or traverse to that position, the full operation becomes `O(n)`.

## Linked List vs Array

| Topic | Linked list | Array |
| --- | --- | --- |
| Memory layout | Nodes can be stored in different places in memory. | Elements are stored contiguously. |
| Access by index | Slow, `O(n)`. | Fast, `O(1)`. |
| Insert at beginning | Fast, `O(1)`. | Usually slow, `O(n)`, because elements shift. |
| Append at end | `O(1)` with a tail reference, otherwise `O(n)`. | Usually amortized `O(1)` for dynamic arrays. |
| Delete from middle | `O(1)` if previous node is known, otherwise `O(n)`. | Usually `O(n)`, because elements shift. |
| Extra memory | Needs extra references such as `Next`. | No per-element pointer overhead. |
| Cache performance | Usually worse because nodes may be scattered in memory. | Usually better because memory is contiguous. |

## Pros

- Fast insertion at the beginning.
- Fast append when a tail reference is stored.
- Does not require contiguous memory.
- Can grow and shrink dynamically.


## Cons

- Slow access by index.
- Searching requires traversal.
- Extra memory is needed for node references.
- Usually worse cache locality than arrays.
- Removing the last item from a singly linked list is `O(n)` unless additional structure is used.

## When a Linked List Is Useful

Linked lists are useful when the program often inserts or removes elements and already has access to the relevant node or position.

Common learning examples:

- Stacks
- Queues


## When an Array Is Usually Better

Arrays or dynamic arrays are usually better when:

- Fast indexing is important.
- The program often reads elements by position.
- The data is mostly appended and iterated.
- Cache-friendly memory access matters.
- The list does not need frequent insertions or deletions in the middle.

## Notes for This Implementation

This implementation is a singly linked list with a head and tail reference.

Current public operations:

- `AddToHead`
- `AddToTail`
- `AddAtIndex`
- `DeleteAtIndex`
- `Get`
- `GetHead`
- `GetTail`
- `Pop`
- `Reverse`
- `IsEmpty`

Future ideas:

- Add `Contains`
- Add `Clear`
- Add `ToArray`
- Add `IEnumerable<T>` support
- Detect cycles

