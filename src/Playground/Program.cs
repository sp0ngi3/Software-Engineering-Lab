using DataStructures.SinglyLinkedList;
using System.Diagnostics;

Console.WriteLine("Software Engineering Lab");
Console.WriteLine("Debug playground for data structures and algorithms.");
Console.WriteLine();

RunLinkedList();

static void RunLinkedList()
{
    Console.WriteLine("Linked List");

    SinglyLinkedList<int> linkedList = new();

    linkedList.Append(5);
    linkedList.Append(10);
    linkedList.Append(15);
    linkedList.Append(20);
    int count = linkedList.Count;
    bool isEmpty = linkedList.IsEmpty();

    Console.ReadLine();

    if (Debugger.IsAttached)
    {
        Debugger.Break();
    }
}
