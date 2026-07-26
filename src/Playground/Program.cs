using DataStructures.SinglyLinkedList;
using System.Diagnostics;

Console.WriteLine("Software Engineering Lab");
Console.WriteLine("Debug playground for data structures and algorithms.");
Console.WriteLine();

RunLinkedList();

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
    Console.ReadLine();
    if (Debugger.IsAttached)
    {
        Debugger.Break();
    }
}
