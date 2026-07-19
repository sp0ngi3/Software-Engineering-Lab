using System.Diagnostics;

Console.WriteLine("Software Engineering Lab");
Console.WriteLine("Debug playground for data structures and algorithms.");
Console.WriteLine();

RunLinkedList();

static void RunLinkedList()
{
    Console.WriteLine("Linked List");

    if (Debugger.IsAttached)
    {
        Debugger.Break();
    }
}
