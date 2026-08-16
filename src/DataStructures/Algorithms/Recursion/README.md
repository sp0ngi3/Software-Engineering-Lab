# Recursion

Recursion is when a method calls itself, usually with a smaller input.

A recursive method breaks a problem into smaller sub-problems until it reaches a simple case that can be returned immediately.

That simple stopping point is called the base case.

## Recursive Method Parts

Most recursive methods have two important parts:

- Base case
- Recursive case

The base case stops the recursion.

The recursive case calls the same method again with a smaller version of the problem.

Without a base case, the method would keep calling itself until the call stack runs out of space.

## Factorial

Factorial is a good example of one-branch recursion.

The formula is:

```text
n! = n * (n - 1) * (n - 2) * ... * 1
```

Example:

```text
5! = 5 * 4 * 3 * 2 * 1 = 120
```

Recursive idea:

```text
Factorial(5)
= 5 * Factorial(4)
= 5 * 4 * Factorial(3)
= 5 * 4 * 3 * Factorial(2)
= 5 * 4 * 3 * 2 * Factorial(1)
= 5 * 4 * 3 * 2 * 1
= 120
```

The base case is:

```text
Factorial(0) = 1
Factorial(1) = 1
```

The recursive case is:

```text
Factorial(n) = n * Factorial(n - 1)
```

## Iteration And Recursion

Most recursive algorithms can also be written iteratively.

Factorial iterative idea:

```text
result = 1

while n > 1:
    result = result * n
    n = n - 1
```

For factorial, the iterative version is usually simpler and more memory efficient.

The recursive version uses the function call stack.

The iterative version only needs a few variables.

## Fibonacci

Fibonacci is a classic example of multi-branch recursion.

The sequence starts with:

```text
0, 1, 1, 2, 3, 5, 8, 13, 21, 34...
```

The base cases are:

```text
F(0) = 0
F(1) = 1
```

The recursive case is:

```text
F(n) = F(n - 1) + F(n - 2)
```

This means `FibonacciRecursive(5)` becomes a tree of calls:

```text
F(5)
|-- F(4)
|   |-- F(3)
|   |   |-- F(2)
|   |   |-- F(1)
|   |-- F(2)
|-- F(3)
|   |-- F(2)
|   |-- F(1)
```

Some values are recalculated many times.

That is why this naive recursive Fibonacci implementation is slow.

## Complexity

| Method | Time complexity | Space complexity | Notes |
| --- | --- | --- | --- |
| `FactorialRecursive(n)` | `O(n)` | `O(n)` | Uses one recursive call per value. |
| `FactorialIterative(n)` | `O(n)` | `O(1)` | Uses a loop and a result variable. |
| `FibonacciRecursive(n)` | `O(2^n)` | `O(n)` | Simple but repeats a lot of work. |
| `FibonacciIterative(n)` | `O(n)` | `O(1)` | Builds the sequence from the bottom up. |

## Pros Of Recursion

- Can make tree and graph problems easier to express.
- Often maps nicely to problems that are naturally made of smaller sub-problems.
- Useful for divide and conquer algorithms.
- Helps understand the call stack.

## Cons Of Recursion

- Can use more memory because of the call stack.
- Can be slower if the same sub-problems are recalculated.
- Can cause stack overflow if the recursion is too deep.
- Sometimes iteration is easier to read.

## Notes For This Implementation

Current public methods:

- `FactorialRecursive`
- `FactorialIterative`
- `FibonacciRecursive`
- `FibonacciIterative`

This implementation uses `int`, so the supported input range is intentionally limited.

Current limits:

- Factorial supports `0 <= n <= 12`.
- Iterative Fibonacci supports `0 <= n <= 46`.
- Recursive Fibonacci supports `0 <= n <= 40` to avoid accidentally running a very slow example.

Future ideas:

- Add memoized Fibonacci.
- Add tail recursion examples.
- Add recursion examples for linked lists.
- Add recursion examples for trees.
