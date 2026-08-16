# Custom Queue

A queue is a linear data structure that works in FIFO order.

FIFO means:

```text
First In, First Out
```

The first value added to the queue is the first value removed from it.

## How It Works

This implementation uses linked nodes as internal storage.

The queue keeps two references:

- `_left` points to the front of the queue.
- `_right` points to the back of the queue.

```text
front                           back
 _left                         _right
   |                             |
  [10] -> [20] -> [30] -> [40] -> null
```

When `Enqueue` is called, the new value is added to the back.

When `Dequeue` is called, the value from the front is removed and returned.

When `Peek` is called, the front value is returned without removing it.

## Why Use Front And Back?

If a queue only stored the front node, adding to the back would require walking through the whole linked list.

That would make `Enqueue` run in `O(n)` time.

By keeping a back pointer, `Enqueue` can add a value in `O(1)` time.

## Complexity

| Operation | Time complexity | Space complexity | Notes |
| --- | --- | --- | --- |
| `Enqueue(value)` | `O(1)` | `O(1)` | Adds a value to the back of the queue. |
| `Dequeue()` | `O(1)` | `O(1)` | Removes the value from the front of the queue. |
| `Peek()` | `O(1)` | `O(1)` | Reads the front value without removing it. |
| `Size()` | `O(1)` | `O(1)` | Returns the number of stored values. |
| `Count` | `O(1)` | `O(1)` | Public property for current queue size. |
| `IsEmpty()` | `O(1)` | `O(1)` | Checks whether the queue has no values. |
| `Print()` | `O(n)` | `O(1)` | Visits every node from front to back. |

## Pros

- Good when values should be processed in the same order they arrived.
- `Enqueue`, `Dequeue`, and `Peek` are fast.
- Does not require shifting values like a simple array-based queue might.
- Can grow dynamically by connecting new nodes.

## Cons

- Does not support random access.
- Uses extra memory for node references.
- Traversal is usually slower than arrays because nodes may not be stored next to each other in memory.
- This implementation depends on the behavior of `SinglyLinkedListNode<T>`.

## Common Use Cases

- Breadth-first search
- Task scheduling
- Background jobs
- Print queues
- Message processing
- Producer-consumer style problems

## Notes for This Implementation

Current public operations:

- `Enqueue`
- `Dequeue`
- `Peek`
- `Size`
- `Count`
- `IsEmpty`
- `Print`

Future ideas:

- Add `Clear`
- Add `ToArray`
- Add `IEnumerable<T>` support
- Add a circular array based queue implementation for comparison
