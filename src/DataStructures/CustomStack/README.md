# Custom Stack

A stack is a linear data structure that works in LIFO order.

LIFO means:

```text
Last In, First Out
```

The last value added to the stack is the first value removed from it.

## How It Works

This implementation uses `CustomDynamicArray<T>` as internal storage.

The end of the dynamic array is treated as the top of the stack:

```text
bottom                     top
[10] [20] [30] [40]
                ^
              Peek()
```

When `Push` is called, the value is added to the end.

When `Pop` is called, the last value is removed and returned.

When `Peek` is called, the last value is returned without removing it.

## Complexity

| Operation | Time complexity | Space complexity | Notes |
| --- | --- | --- | --- |
| `Push(value)` | Usually `O(1)` | `O(1)` | Can be `O(n)` if the dynamic array needs to grow. |
| `Pop()` | Usually `O(1)` | `O(1)` | Can be `O(n)` if the dynamic array shrinks. |
| `Peek()` | `O(1)` | `O(1)` | Reads the last value without removing it. |
| `Size()` | `O(1)` | `O(1)` | Returns the number of stored values. |
| `Count` | `O(1)` | `O(1)` | Public property for current stack size. |
| `IsEmpty()` | `O(1)` | `O(1)` | Checks whether the stack has no values. |

## Pros

- Simple mental model.
- Good for problems where only the latest value matters.
- `Push`, `Pop`, and `Peek` are usually fast.


## Cons

- Does not support random access.
- Only the top value should be accessed directly.
- This implementation depends on the behavior of `CustomDynamicArray<T>`.

## Common Use Cases

- Undo history
- Browser back navigation
- Function call stack
- Parsing expressions
- Depth-first search
- Matching brackets

## Notes for This Implementation

Current public operations:

- `Push`
- `Pop`
- `Peek`
- `Size`
- `Count`
- `IsEmpty`

Future ideas:

- Add `Clear`
- Add `ToArray`
- Add `IEnumerable<T>` support
- Add tests for large push/pop scenarios
