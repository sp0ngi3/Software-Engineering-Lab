using DataStructures.SinglyLinkedList;

namespace DataStructures.Tests.SinglyLinkedList;

public class SinglyLinkedListNodeTests
{
    [Fact]
    public void Constructor_WhenValueIsProvided_SetsValue()
    {
        // Arrange
        const int value = 10;

        // Act
        var node = new SinglyLinkedListNode<int>(value);

        // Assert
        Assert.Equal(value, node.Value);
    }

    [Fact]
    public void Constructor_WhenNodeIsCreated_SetsNextToNull()
    {
        // Arrange
        const int value = 10;

        // Act
        var node = new SinglyLinkedListNode<int>(value);

        // Assert
        Assert.Null(node.Next);
    }

    [Fact]
    public void Next_WhenAssigned_PointsToNextNode()
    {
        // Arrange
        var firstNode = new SinglyLinkedListNode<int>(10);
        var secondNode = new SinglyLinkedListNode<int>(20);

        // Act
        firstNode.Next = secondNode;

        // Assert
        Assert.Same(secondNode, firstNode.Next);
        Assert.Equal(20, firstNode.Next.Value);
    }
}
