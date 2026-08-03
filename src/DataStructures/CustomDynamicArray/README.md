# Custom Dynamic Array


A dynamic array stores values inside a normal array. The important idea is that the internal array has a fixed capacity, but the dynamic array can grow by creating a bigger internal array and copying the old values into it.

This is the same general idea used by structures like `List<T>` in C#: the public collection feels like it can grow, but internally it still stores values in an array.

## How It Works

This implementation stores three private fields:

- `_arr`: the internal array that stores values
- `_size`: the number of values currently stored
- `_capacity`: the number of values that can be stored before resizing

It also exposes:

- `Count`: public view of `_size`
- `Capacity`: public view of `_capacity`, useful while learning and debugging

At the beginning, the capacity is `8` and the size is `0`.

```text
size:     0
capacity: 8

[ ][ ][ ][ ][ ][ ][ ][ ]
```

When a value is added, it is placed at the next free index and `_size` is increased.

```text
size:     3
capacity: 8

[10][20][30][ ][ ][ ][ ][ ]
```

When `_size == _capacity`, the internal array is full. The array is resized by doubling the capacity and copying values into the new array.

When many values are removed, the opposite problem can happen: the internal array may be much bigger than needed. For example, capacity may be `160`, while only `3` values are stored.

To solve this, the implementation shrinks when the array uses at most 25% of its capacity:

```text
if size <= capacity / 4:
    capacity = capacity / 2
```

The capacity never goes below the initial capacity of `8`.

## Complexity

| Operation | Time complexity | Space complexity | Notes |
| --- | --- | --- | --- |
| `Count` | `O(1)` | `O(1)` | Returns the number of stored values. |
| `Capacity` | `O(1)` | `O(1)` | Returns the size of the internal array. |
| `Get(index)` | `O(1)` | `O(1)` | Direct access by index. |
| `Insert(value, index)` | `O(1)` | `O(1)` | Currently replaces an existing value at index. |
| `Add(value)` | * `O(1)` | `O(1)` | Adds at the end when there is free capacity. |
| `Add(value)` with resize | `O(n)` | `O(n)` | Creates a bigger array and copies existing values. |
| `RemoveAt(index)` | `O(n)` | `O(1)` | Shifts values after the removed index to the left. |
| `RemoveLast()` | * `O(1)` | `O(1)` | Removes the last value without shifting. |
| Shrinking | `O(n)` | `O(n)` | Creates a smaller array and copies existing values. |
| `Resize()` | `O(n)` | `O(n)` | Private helper used when capacity is full. |

## Dynamic Array vs Linked List

| Topic | Dynamic array | Linked list |
| --- | --- | --- |
| Access by index | Fast, `O(1)`. | Slow, `O(n)`. |
| Append at end | Usually fast, amortized `O(1)`. | `O(1)` when tail is stored. |
| Insert in middle | Usually expensive if shifting is required. | Can be cheap if the correct node is already known. |
| Memory layout | Values are stored contiguously in an array. | Nodes can be scattered in memory. |
| Extra memory | May keep unused capacity. | Needs references between nodes. |

## Pros

- Fast access by index.
- Usually fast appending.
- Good cache locality because values are stored in an array.
- Simple mental model.

## Cons

- Resizing requires copying existing values.
- The internal array may have unused capacity.
- Inserting or deleting in the middle would require shifting values if implemented later.
- Shrinking also requires copying values, so it should not happen after every single removal.

## Notes for This Implementation

Current public operations:

- `Add`
- `Get`
- `Insert`
- `RemoveAt`
- `RemoveLast`
- `Count`
- `Capacity`

Important naming note: current `Insert` works more like replacing a value at an existing index. In `List<T>`, `Insert` usually means adding a new value at an index and shifting the following values to the right. A future improvement could be to rename the current method to `Set` and implement a real `InsertAt`.


