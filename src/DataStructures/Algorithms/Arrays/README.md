# Algorithms

The algorithms in this folder are written against arrays and array-like structures.

When possible, they also support `CustomDynamicArray<int>` and `IEnumerable<int>`, so the same idea can be tested on both built-in and custom data structures.

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

## Variable Size Sliding Window

Sliding window is a technique where we keep a range of values between two pointers:

```text
left ... right
```

The right pointer usually expands the window.

The left pointer usually shrinks the window when the current window no longer fits the problem.

Variable size means the window does not have a fixed length. The length changes depending on the current values and the constraint.

### Longest Subarray With Same Value

Problem:

```text
Find the length of the longest subarray with the same value in each position.
```

Example:

```text
[4, 2, 2, 3, 3, 3]
```

The best subarray is:

```text
[3, 3, 3]
```

The answer is:

```text
3
```

Idea:

- Start with `left = 0`.
- Move `right` through the array.
- If `nums[left] != nums[right]`, the old window is no longer valid.
- Move `left` to `right`.
- Keep the longest valid window length.

### Shortest Subarray With Sum At Least Target

Problem:

```text
Find the minimum length subarray where the sum is greater than or equal to target.
Assume all values are positive.
```

Example:

```text
nums = [2, 3, 1, 2, 4, 3]
target = 7
```

The best subarray is:

```text
[4, 3]
```

The answer is:

```text
2
```

Idea:

- Expand the window by moving `right`.
- Add `nums[right]` to the current sum.
- While the sum is at least the target, try to shrink from the left.
- Every time the window is valid, update the best length.

## Two Pointers

Two pointers is a technique where we keep two indexes and move them through the input.

Very often the first pointer starts at the beginning:

```text
left = 0
```

And the second pointer starts at the end:

```text
right = nums.Length - 1
```

Then we move them depending on what the problem needs.

### Palindrome

Problem:

```text
Check if a sequence reads the same backwards as forwards.
```

Example:

```text
racecar
```

The first and last character are the same, then the second and second-last character are the same, and so on.

Idea:

- Start with `left = 0`.
- Start with `right = word.Length - 1`.
- Compare `word[left]` with `word[right]`.
- If they are different, return `false`.
- Move both pointers towards the middle.
- If no mismatch was found, return `true`.

This implementation is case-sensitive and whitespace-sensitive. For example, `Racecar` is not treated as the same as `racecar`.

### Target Sum

Problem:

```text
Given a sorted array, return the indexes of two values that add up to the target.
```

Example:

```text
nums = [2, 7, 11, 15]
target = 9
```

The answer is:

```text
[0, 1]
```

Because:

```text
nums[0] + nums[1] = 2 + 7 = 9
```

Idea:

- Start with `left = 0`.
- Start with `right = nums.Length - 1`.
- Calculate `nums[left] + nums[right]`.
- If the sum is too big, move `right` backward.
- If the sum is too small, move `left` forward.
- If the sum is equal to target, return both indexes.

This only works in this simple form when the input is already sorted in ascending order.

## Prefix Sums

Prefix sums are useful when we want to ask many questions like:

```text
What is the sum between index left and index right?
```

Without prefix sums, every range query needs a loop through that range.

With prefix sums, we first build an extra array:

```text
nums        = [2, -1, 3, 5]
prefixSums = [0,  2, 1, 4, 9]
```

The extra `0` at the beginning makes the range formula easier.

To get the sum from index `left` to index `right`, we use:

```text
prefixSums[right + 1] - prefixSums[left]
```

Example:

```text
left = 1
right = 3
```

This means:

```text
nums[1] + nums[2] + nums[3]
```

So:

```text
prefixSums[4] - prefixSums[1] = 9 - 2 = 7
```

### Prefix Product

Prefix product is the same idea, but with multiplication instead of addition:

```text
nums           = [2, 3, 4]
prefixProducts = [1, 2, 6, 24]
```

The extra `1` at the beginning is used because `1` is the neutral value for multiplication.

This is useful as a learning exercise, but multiplication has more traps than addition:

- A `0` breaks simple division-based range product formulas.
- Products can overflow `int` much faster than sums.
- Because of that, `RangeProduct` in this project uses a direct loop through the requested range.

## Current Methods

Kadane:

- `MaxSubarraySum(int[] nums)`
- `MaxSubarraySum(CustomDynamicArray<int> nums)`
- `MaxSubarraySum(IEnumerable<int> nums)`
- `FindMaxSubarrayRange(int[] nums)`
- `FindMaxSubarrayRange(CustomDynamicArray<int> nums)`
- `FindMaxSubarrayRange(IEnumerable<int> nums)`

Variable size sliding window:

- `LongestSubarrayWithSameValue(int[] nums)`
- `LongestSubarrayWithSameValue(CustomDynamicArray<int> nums)`
- `LongestSubarrayWithSameValue(IEnumerable<int> nums)`
- `ShortestSubarrayWithSumAtLeastTarget(int[] nums, int target)`
- `ShortestSubarrayWithSumAtLeastTarget(CustomDynamicArray<int> nums, int target)`
- `ShortestSubarrayWithSumAtLeastTarget(IEnumerable<int> nums, int target)`

Two pointers:

- `IsPalindrome(string word)`
- `IsPalindrome(int[] nums)`
- `IsPalindrome(CustomDynamicArray<int> nums)`
- `IsPalindrome(IEnumerable<int> nums)`
- `TargetSum(int[] nums, int target)`
- `TargetSum(CustomDynamicArray<int> nums, int target)`
- `TargetSum(IEnumerable<int> nums, int target)`

Prefix sums:

- `BuildPrefixSum(int[] nums)`
- `BuildPrefixSum(CustomDynamicArray<int> nums)`
- `BuildPrefixSum(IEnumerable<int> nums)`
- `RangeSumFromPrefixSum(int[] prefixSums, int left, int right)`
- `BuildPrefixProduct(int[] nums)`
- `BuildPrefixProduct(CustomDynamicArray<int> nums)`
- `BuildPrefixProduct(IEnumerable<int> nums)`
- `RangeProduct(int[] nums, int left, int right)`
- `RangeProduct(CustomDynamicArray<int> nums, int left, int right)`
- `RangeProduct(IEnumerable<int> nums, int left, int right)`

## Complexity

| Operation | Time complexity | Space complexity | Notes |
| --- | --- | --- | --- |
| `MaxSubarraySum` | `O(n)` | `O(1)` | Visits every number once. |
| `FindMaxSubarrayRange` | `O(n)` | `O(1)` | Visits every number once and tracks indexes. |
| `LongestSubarrayWithSameValue` | `O(n)` | `O(1)` | Moves the right pointer through the input once. |
| `ShortestSubarrayWithSumAtLeastTarget` | `O(n)` | `O(1)` | Each value enters and leaves the window at most once. |
| `IsPalindrome` | `O(n)` | `O(1)` | Compares values from both ends until the pointers meet. |
| `TargetSum` | `O(n)` | `O(1)` | Uses the sorted order to move left or right intelligently. |
| `BuildPrefixSum` | `O(n)` | `O(n)` | Creates an extra array of partial sums. |
| `RangeSumFromPrefixSum` | `O(1)` | `O(1)` | Uses subtraction between two prefix values. |
| `BuildPrefixProduct` | `O(n)` | `O(n)` | Creates an extra array of partial products. |
| `RangeProduct` | `O(k)` | `O(1)` | Uses a direct loop because zero values make product queries trickier. |

## Notes

These algorithms work with `int` values because they need numeric operations such as addition and comparison.

The `IEnumerable<int>` overloads copy the sequence into an array and then reuse the array implementation. The main learning implementation is the array or custom dynamic array version with a normal `for` loop.

`TargetSum` assumes that the input is sorted. If the input is not sorted, this version can return the wrong result because moving the pointers depends on sorted order.

Prefix sums are usually worth it when we have many range sum queries for the same input. If there is only one query, a normal loop can be simpler and also uses less memory.
