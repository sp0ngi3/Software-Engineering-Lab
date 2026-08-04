#  Algorithms

The algorithms in this folder are written against `IEnumerable<int>` when possible. This means they can work with normal arrays, `List<int>`, and custom structures such as `CustomDynamicArray<int>` as long as the structure can be enumerated.

## Kadane's Algorithm

Kadane's algorithm finds the contiguous subarray with the maximum sum.

Example:

```text
[-2, 1, -3, 4, -1, 2, 1, -5, 4]
```

The best contiguous subarray is:

```text
[4, -1, 2, 1]
```

The maximum sum is:

```text
6
```

## Current Methods

- `MaxSubarraySum(IEnumerable<int> nums)`
- `FindMaxSubarrayRange(IEnumerable<int> nums)`

## Complexity

| Operation | Time complexity | Space complexity | Notes |
| --- | --- | --- | --- |
| `MaxSubarraySum` | `O(n)` | `O(1)` | Visits every number once. |
| `FindMaxSubarrayRange` | `O(n)` | `O(1)` | Visits every number once and tracks indexes. |

## Notes

Kadane's algorithm works with numbers, so this implementation is for `int` values.

The dynamic array itself can be generic, but this algorithm needs numeric operations such as addition and comparison. That is why it uses `IEnumerable<int>` instead of `IEnumerable<T>`.
