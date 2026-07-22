using System.Reflection;
using DataStructures.SinglyLinkedList;

namespace DataStructures.Tests.SinglyLinkedList;

public class SinglyLinkedListTests
{
    [Fact]
    public void Constructor_WhenListIsCreated_SetsCountToZero()
    {
        // Arrange & Act
        SinglyLinkedList<int> list = new SinglyLinkedList<int>();

        // Assert
        Assert.Equal(0, list.Count);
    }

    [Fact]
    public void Constructor_WhenListIsCreated_CreatesEmptyList()
    {
        // Arrange & Act
        SinglyLinkedList<int> list = new SinglyLinkedList<int>();

        // Assert
        Assert.True(list.IsEmpty());
    }

    [Fact]
    public void Append_WhenValueIsAdded_IncreasesCount()
    {
        // Arrange
        SinglyLinkedList<int> list = new SinglyLinkedList<int>();

        // Act
        list.Append(10);

        // Assert
        Assert.Equal(1, list.Count);
    }

    [Fact]
    public void Append_WhenValueIsAdded_ListIsNoLongerEmpty()
    {
        // Arrange
        SinglyLinkedList<int> list = new SinglyLinkedList<int>();

        // Act
        list.Append(10);

        // Assert
        Assert.False(list.IsEmpty());
    }

    [Fact]
    public void Append_WhenFirstValueIsAdded_SetsHeadAndTailToSameNode()
    {
        // Arrange
        SinglyLinkedList<int> list = new SinglyLinkedList<int>();

        // Act
        list.Append(10);

        // Assert
        SinglyLinkedListNode<int>? head = GetPrivateNode(list, "_head");
        SinglyLinkedListNode<int>? tail = GetPrivateNode(list, "_tail");

        Assert.NotNull(head);
        Assert.Same(head, tail);
        Assert.Equal(10, head.Value);
        Assert.Null(head.Next);
    }

    [Fact]
    public void Append_WhenMultipleValuesAreAdded_LinksNodesInAppendOrder()
    {
        // Arrange
        SinglyLinkedList<int> list = new SinglyLinkedList<int>();

        // Act
        list.Append(10);
        list.Append(20);
        list.Append(30);

        // Assert
        SinglyLinkedListNode<int>? head = GetPrivateNode(list, "_head");
        SinglyLinkedListNode<int>? tail = GetPrivateNode(list, "_tail");

        Assert.NotNull(head);
        Assert.NotNull(tail);
        Assert.Equal(10, head.Value);
        Assert.Equal(20, head.Next!.Value);
        Assert.Equal(30, head.Next.Next!.Value);
        Assert.Null(head.Next.Next.Next);
        Assert.Same(tail, head.Next.Next);
        Assert.Equal(3, list.Count);
    }

    private static SinglyLinkedListNode<T>? GetPrivateNode<T>(
        SinglyLinkedList<T> list,
        string fieldName)
    {
        FieldInfo? field = typeof(SinglyLinkedList<T>).GetField(
            fieldName,
            BindingFlags.Instance | BindingFlags.NonPublic);

        return (SinglyLinkedListNode<T>?)field!.GetValue(list);
    }
}
