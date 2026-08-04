using DataStructures.Algorithms.Arrays;
using DataStructures.CustomDynamicArray;
using DataStructures.SinglyLinkedList;
using System.Diagnostics;

Console.WriteLine("Software Engineering Lab");
Console.WriteLine("Debug playground for data structures and algorithms.");
Console.WriteLine();

RunCustomDynamicArray();

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
