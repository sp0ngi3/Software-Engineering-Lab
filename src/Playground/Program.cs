using DataStructures.Algorithms.Arrays;
using DataStructures.CustomDynamicArrays;
using DataStructures.CustomStack;
using DataStructures.SinglyLinkedList;
using System.Diagnostics;

Console.WriteLine("Software Engineering Lab");
Console.WriteLine("Debug playground for data structures and algorithms.");
Console.WriteLine();

RunPrefixSums();

static void RunLinkedList()
{
    Console.WriteLine("Linked List");

    CustomLinkedList<int> linkedList = new();

    linkedList.AddToTail(5);
    linkedList.AddToTail(10);
    linkedList.AddToTail(15);
    linkedList.AddToTail(20);
    int count = linkedList.Count;
    bool isEmpty = linkedList.IsEmpty();
    int testGet = linkedList.Get(1);
    int testHeadBeforeInserting = linkedList.Get(0);
    linkedList.AddToHead(99);
    int testHeadAfterInserting= linkedList.Get(0);
    int getHeadBeforeReversing = linkedList.GetHead();
    int getTailBeforeReversing = linkedList.GetTail();
    linkedList.Reverse();
    int getHeadAfterReversing = linkedList.GetHead();
    int getTailAfterReversing = linkedList.GetTail();
    
    foreach (int val in linkedList)
    {
        Console.WriteLine(val);
    }
    Console.ReadLine();
    if (Debugger.IsAttached)
    {
        Debugger.Break();
    }
}

static void RunCustomDynamicArray()
{
    Console.WriteLine("Custom Dynamic Array");

    CustomDynamicArray<int> dynamicArray = new();

    dynamicArray.Add(5);
    dynamicArray.Add(10);
    dynamicArray.Add(15);
    dynamicArray.Add(20);

    int countAfterAdding = dynamicArray.Count;
    int capacityAfterAdding = dynamicArray.Capacity;
    int firstValue = dynamicArray.Get(0);
    int secondValue = dynamicArray.Get(1);

    dynamicArray.Insert(99, 1);

    int updatedSecondValue = dynamicArray.Get(1);

    for (int value = 25; value <= 100; value += 5)
    {
        dynamicArray.Add(value);
    }

    int capacityAfterGrowing = dynamicArray.Capacity;

    dynamicArray.RemoveAt(1);
    dynamicArray.RemoveLast();

    while (dynamicArray.Count > 3)
    {
        dynamicArray.RemoveLast();
    }

    int countAfterShrinking = dynamicArray.Count;
    int capacityAfterShrinking = dynamicArray.Capacity;
    int[] valuesAfterShrinking = dynamicArray.ToArray();

    CustomDynamicArray<int> kadaneInput = new();
    kadaneInput.Add(-2);
    kadaneInput.Add(1);
    kadaneInput.Add(-3);
    kadaneInput.Add(4);
    kadaneInput.Add(-1);
    kadaneInput.Add(2);
    kadaneInput.Add(1);
    kadaneInput.Add(-5);
    kadaneInput.Add(4);

    int maxSubarraySum = KadaneAlgorithm.MaxSubarraySum(kadaneInput);
    int[] maxSubarrayRange = KadaneAlgorithm.FindMaxSubarrayRange(kadaneInput);

    Console.WriteLine($"Count after adding: {countAfterAdding}");
    Console.WriteLine($"Capacity after adding: {capacityAfterAdding}");
    Console.WriteLine($"First value: {firstValue}");
    Console.WriteLine($"Second value: {secondValue}");
    Console.WriteLine($"Updated second value: {updatedSecondValue}");
    Console.WriteLine($"Capacity after growing: {capacityAfterGrowing}");
    Console.WriteLine($"Count after shrinking: {countAfterShrinking}");
    Console.WriteLine($"Capacity after shrinking: {capacityAfterShrinking}");
    Console.WriteLine($"Values after shrinking: {string.Join(", ", valuesAfterShrinking)}");
    Console.WriteLine($"Kadane max subarray sum: {maxSubarraySum}");
    Console.WriteLine($"Kadane max subarray range: {maxSubarrayRange[0]} - {maxSubarrayRange[1]}");

    Console.ReadLine();
    if (Debugger.IsAttached)
    {
        Debugger.Break();
    }
}

static void RunCustomStack()
{
    Console.WriteLine("Custom Stack");

    CustomStack<int> stack = new();

    bool isEmptyBeforePushing = stack.IsEmpty();
    int sizeBeforePushing = stack.Size();

    stack.Push(10);
    stack.Push(20);
    stack.Push(30);

    int countAfterPushing = stack.Count;
    int sizeAfterPushing = stack.Size();
    bool isEmptyAfterPushing = stack.IsEmpty();
    int topValueBeforePopping = stack.Peek();

    int firstPoppedValue = stack.Pop();
    int topValueAfterFirstPop = stack.Peek();

    stack.Push(40);

    int topValueAfterPushingAgain = stack.Peek();
    int secondPoppedValue = stack.Pop();
    int thirdPoppedValue = stack.Pop();
    int fourthPoppedValue = stack.Pop();

    bool isEmptyAfterPoppingEverything = stack.IsEmpty();
    int sizeAfterPoppingEverything = stack.Size();

    Console.WriteLine($"Is empty before pushing: {isEmptyBeforePushing}");
    Console.WriteLine($"Size before pushing: {sizeBeforePushing}");
    Console.WriteLine($"Count after pushing: {countAfterPushing}");
    Console.WriteLine($"Size after pushing: {sizeAfterPushing}");
    Console.WriteLine($"Is empty after pushing: {isEmptyAfterPushing}");
    Console.WriteLine($"Top value before popping: {topValueBeforePopping}");
    Console.WriteLine($"First popped value: {firstPoppedValue}");
    Console.WriteLine($"Top value after first pop: {topValueAfterFirstPop}");
    Console.WriteLine($"Top value after pushing again: {topValueAfterPushingAgain}");
    Console.WriteLine($"Second popped value: {secondPoppedValue}");
    Console.WriteLine($"Third popped value: {thirdPoppedValue}");
    Console.WriteLine($"Fourth popped value: {fourthPoppedValue}");
    Console.WriteLine($"Is empty after popping everything: {isEmptyAfterPoppingEverything}");
    Console.WriteLine($"Size after popping everything: {sizeAfterPoppingEverything}");

    Console.ReadLine();
    if (Debugger.IsAttached)
    {
        Debugger.Break();
    }
}

static void RunSlidingWindowVariableSize()
{
    Console.WriteLine("Variable Size Sliding Window");

    int[] sameValueInput = { 4, 2, 2, 3, 3, 3 };
    int longestSameValueLength = SlidingWindowVariableSize.LongestSubarrayWithSameValue(sameValueInput);

    int[] targetInput = { 2, 3, 1, 2, 4, 3 };
    int shortestTargetLength = SlidingWindowVariableSize.ShortestSubarrayWithSumAtLeastTarget(targetInput, 7);

    CustomDynamicArray<int> dynamicArrayInput = new();
    dynamicArrayInput.Add(4);
    dynamicArrayInput.Add(2);
    dynamicArrayInput.Add(2);
    dynamicArrayInput.Add(3);
    dynamicArrayInput.Add(3);
    dynamicArrayInput.Add(3);

    int longestSameValueLengthFromDynamicArray =
        SlidingWindowVariableSize.LongestSubarrayWithSameValue(dynamicArrayInput);

    Console.WriteLine($"Longest same-value subarray length: {longestSameValueLength}");
    Console.WriteLine($"Shortest subarray length with sum >= 7: {shortestTargetLength}");
    Console.WriteLine($"Longest same-value length from custom dynamic array: {longestSameValueLengthFromDynamicArray}");

    Console.ReadLine();
    if (Debugger.IsAttached)
    {
        Debugger.Break();
    }
}

static void RunTwoPointers()
{
    Console.WriteLine("Two Pointers");

    string palindromeWord = "racecar";
    bool isWordPalindrome = TwoPointers.IsPalindrome(palindromeWord);

    string notPalindromeWord = "learning";
    bool isSecondWordPalindrome = TwoPointers.IsPalindrome(notPalindromeWord);

    int[] palindromeNumbers = { 1, 2, 3, 2, 1 };
    bool areNumbersPalindrome = TwoPointers.IsPalindrome(palindromeNumbers);

    int[] sortedNumbers = { 2, 7, 11, 15 };
    int[]? targetSumIndexes = TwoPointers.TargetSum(sortedNumbers, 9);

    CustomDynamicArray<int> dynamicArrayInput = new();
    dynamicArrayInput.Add(1);
    dynamicArrayInput.Add(3);
    dynamicArrayInput.Add(4);
    dynamicArrayInput.Add(5);
    dynamicArrayInput.Add(7);
    dynamicArrayInput.Add(11);

    int[]? targetSumIndexesFromDynamicArray = TwoPointers.TargetSum(dynamicArrayInput, 10);

    Console.WriteLine($"Is '{palindromeWord}' a palindrome: {isWordPalindrome}");
    Console.WriteLine($"Is '{notPalindromeWord}' a palindrome: {isSecondWordPalindrome}");
    Console.WriteLine($"Are numbers palindrome: {areNumbersPalindrome}");
    Console.WriteLine($"Target sum indexes: {FormatIndexes(targetSumIndexes)}");
    Console.WriteLine($"Target sum indexes from custom dynamic array: {FormatIndexes(targetSumIndexesFromDynamicArray)}");

    Console.ReadLine();
    if (Debugger.IsAttached)
    {
        Debugger.Break();
    }
}

static string FormatIndexes(int[]? indexes)
{
    if (indexes is null)
    {
        return "not found";
    }

    return $"{indexes[0]}, {indexes[1]}";
}

static void RunPrefixSums()
{
    Console.WriteLine("Prefix Sums");

    int[] nums = { 2, -1, 3, 5 };
    int[] prefixSums = PrefixSums.BuildPrefixSum(nums);
    int rangeSum = PrefixSums.RangeSumFromPrefixSum(prefixSums, 1, 3);

    int[] multiplicationInput = { 2, 3, 4 };
    int[] prefixProducts = PrefixSums.BuildPrefixProduct(multiplicationInput);
    int rangeProduct = PrefixSums.RangeProduct(new[] { 2, 3, 4, 5 }, 1, 3);

    CustomDynamicArray<int> dynamicArrayInput = new();
    dynamicArrayInput.Add(3);
    dynamicArrayInput.Add(-2);
    dynamicArrayInput.Add(5);
    dynamicArrayInput.Add(1);
    dynamicArrayInput.Add(6);

    int[] prefixSumsFromDynamicArray = PrefixSums.BuildPrefixSum(dynamicArrayInput);
    int rangeSumFromDynamicArray = PrefixSums.RangeSumFromPrefixSum(prefixSumsFromDynamicArray, 1, 3);

    Console.WriteLine($"Input: {string.Join(", ", nums)}");
    Console.WriteLine($"Prefix sums: {string.Join(", ", prefixSums)}");
    Console.WriteLine($"Range sum from index 1 to 3: {rangeSum}");
    Console.WriteLine($"Prefix products: {string.Join(", ", prefixProducts)}");
    Console.WriteLine($"Range product from index 1 to 3: {rangeProduct}");
    Console.WriteLine($"Prefix sums from custom dynamic array: {string.Join(", ", prefixSumsFromDynamicArray)}");
    Console.WriteLine($"Range sum from custom dynamic array prefix sums: {rangeSumFromDynamicArray}");

    Console.ReadLine();
    if (Debugger.IsAttached)
    {
        Debugger.Break();
    }
}
