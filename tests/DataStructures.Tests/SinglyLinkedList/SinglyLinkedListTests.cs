using DataStructures.SinglyLinkedList;

namespace DataStructures.Tests.SinglyLinkedList;

public class SinglyLinkedListTests
{
    [Fact]
    public void Constructor_WhenListIsCreated_SetsCountToZero()
    {
        // Arrange & Act
        CustomLinkedList<int> list = new CustomLinkedList<int>();

        // Assert
        Assert.Equal(0, list.Count);
    }

    [Fact]
    public void Constructor_WhenListIsCreated_CreatesEmptyList()
    {
        // Arrange & Act
        CustomLinkedList<int> list = new CustomLinkedList<int>();

        // Assert
        Assert.True(list.IsEmpty());
    }

    [Fact]
    public void AddToTail_WhenListIsEmpty_AddsFirstValue()
    {
        // Arrange
        CustomLinkedList<int> list = new CustomLinkedList<int>();

        // Act
        list.AddToTail(10);

        // Assert
        Assert.Equal(1, list.Count);
        Assert.False(list.IsEmpty());
        Assert.Equal(10, list.GetHead());
        Assert.Equal(10, list.GetTail());
        Assert.Equal(10, list.Get(0));
    }

    [Fact]
    public void AddToTail_WhenMultipleValuesAreAdded_PreservesAppendOrder()
    {
        // Arrange
        CustomLinkedList<int> list = new CustomLinkedList<int>();

        // Act
        list.AddToTail(10);
        list.AddToTail(20);
        list.AddToTail(30);

        // Assert
        Assert.Equal(3, list.Count);
        Assert.Equal(10, list.GetHead());
        Assert.Equal(30, list.GetTail());
        AssertListValues(list, 10, 20, 30);
    }

    [Fact]
    public void AddToHead_WhenListIsEmpty_AddsFirstValue()
    {
        // Arrange
        CustomLinkedList<int> list = new CustomLinkedList<int>();

        // Act
        list.AddToHead(10);

        // Assert
        Assert.Equal(1, list.Count);
        Assert.False(list.IsEmpty());
        Assert.Equal(10, list.GetHead());
        Assert.Equal(10, list.GetTail());
        Assert.Equal(10, list.Get(0));
    }

    [Fact]
    public void AddToHead_WhenMultipleValuesAreAdded_ReversesInsertionOrder()
    {
        // Arrange
        CustomLinkedList<int> list = new CustomLinkedList<int>();

        // Act
        list.AddToHead(10);
        list.AddToHead(20);
        list.AddToHead(30);

        // Assert
        Assert.Equal(3, list.Count);
        Assert.Equal(30, list.GetHead());
        Assert.Equal(10, list.GetTail());
        AssertListValues(list, 30, 20, 10);
    }

    [Fact]
    public void Get_WhenIndexIsValid_ReturnsValueAtIndex()
    {
        // Arrange
        CustomLinkedList<int> list = CreateList(10, 20, 30);

        // Act
        int value = list.Get(1);

        // Assert
        Assert.Equal(20, value);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(3)]
    public void Get_WhenIndexIsOutOfRange_ThrowsArgumentOutOfRangeException(int index)
    {
        // Arrange
        CustomLinkedList<int> list = CreateList(10, 20, 30);

        // Act
        Action act = () => list.Get(index);

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(act);
    }

    [Fact]
    public void AddAtIndex_WhenIndexIsZero_AddsValueToHead()
    {
        // Arrange
        CustomLinkedList<int> list = CreateList(20, 30);

        // Act
        list.AddAtIndex(0, 10);

        // Assert
        Assert.Equal(3, list.Count);
        Assert.Equal(10, list.GetHead());
        Assert.Equal(30, list.GetTail());
        AssertListValues(list, 10, 20, 30);
    }

    [Fact]
    public void AddAtIndex_WhenIndexIsCount_AddsValueToTail()
    {
        // Arrange
        CustomLinkedList<int> list = CreateList(10, 20);

        // Act
        list.AddAtIndex(2, 30);

        // Assert
        Assert.Equal(3, list.Count);
        Assert.Equal(10, list.GetHead());
        Assert.Equal(30, list.GetTail());
        AssertListValues(list, 10, 20, 30);
    }

    [Fact]
    public void AddAtIndex_WhenIndexIsInMiddle_InsertsValueAtIndex()
    {
        // Arrange
        CustomLinkedList<int> list = CreateList(10, 30);

        // Act
        list.AddAtIndex(1, 20);

        // Assert
        Assert.Equal(3, list.Count);
        Assert.Equal(10, list.GetHead());
        Assert.Equal(30, list.GetTail());
        AssertListValues(list, 10, 20, 30);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(4)]
    public void AddAtIndex_WhenIndexIsOutOfRange_ThrowsArgumentOutOfRangeException(int index)
    {
        // Arrange
        CustomLinkedList<int> list = CreateList(10, 20, 30);

        // Act
        Action act = () => list.AddAtIndex(index, 99);

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(act);
    }

    [Fact]
    public void DeleteAtIndex_WhenRemovingHead_RemovesFirstValue()
    {
        // Arrange
        CustomLinkedList<int> list = CreateList(10, 20, 30);

        // Act
        list.DeleteAtIndex(0);

        // Assert
        Assert.Equal(2, list.Count);
        Assert.Equal(20, list.GetHead());
        Assert.Equal(30, list.GetTail());
        AssertListValues(list, 20, 30);
    }

    [Fact]
    public void DeleteAtIndex_WhenRemovingMiddle_RemovesValueAtIndex()
    {
        // Arrange
        CustomLinkedList<int> list = CreateList(10, 20, 30);

        // Act
        list.DeleteAtIndex(1);

        // Assert
        Assert.Equal(2, list.Count);
        Assert.Equal(10, list.GetHead());
        Assert.Equal(30, list.GetTail());
        AssertListValues(list, 10, 30);
    }

    [Fact]
    public void DeleteAtIndex_WhenRemovingTail_UpdatesTail()
    {
        // Arrange
        CustomLinkedList<int> list = CreateList(10, 20, 30);

        // Act
        list.DeleteAtIndex(2);

        // Assert
        Assert.Equal(2, list.Count);
        Assert.Equal(10, list.GetHead());
        Assert.Equal(20, list.GetTail());
        AssertListValues(list, 10, 20);
    }

    [Fact]
    public void DeleteAtIndex_WhenRemovingOnlyValue_ClearsList()
    {
        // Arrange
        CustomLinkedList<int> list = CreateList(10);

        // Act
        list.DeleteAtIndex(0);

        // Assert
        Assert.Equal(0, list.Count);
        Assert.True(list.IsEmpty());
        Assert.Throws<InvalidOperationException>(() => list.GetHead());
        Assert.Throws<InvalidOperationException>(() => list.GetTail());
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(3)]
    public void DeleteAtIndex_WhenIndexIsOutOfRange_ThrowsArgumentOutOfRangeException(int index)
    {
        // Arrange
        CustomLinkedList<int> list = CreateList(10, 20, 30);

        // Act
        Action act = () => list.DeleteAtIndex(index);

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(act);
    }

    [Fact]
    public void DeleteAtIndex_WhenListIsEmpty_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        CustomLinkedList<int> list = new CustomLinkedList<int>();

        // Act
        Action act = () => list.DeleteAtIndex(0);

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(act);
    }

    [Fact]
    public void Pop_WhenListHasMultipleValues_RemovesTail()
    {
        // Arrange
        CustomLinkedList<int> list = CreateList(10, 20, 30);

        // Act
        list.Pop();

        // Assert
        Assert.Equal(2, list.Count);
        Assert.Equal(10, list.GetHead());
        Assert.Equal(20, list.GetTail());
        AssertListValues(list, 10, 20);
    }

    [Fact]
    public void Pop_WhenListHasOneValue_ClearsList()
    {
        // Arrange
        CustomLinkedList<int> list = CreateList(10);

        // Act
        list.Pop();

        // Assert
        Assert.Equal(0, list.Count);
        Assert.True(list.IsEmpty());
        Assert.Throws<InvalidOperationException>(() => list.GetHead());
        Assert.Throws<InvalidOperationException>(() => list.GetTail());
    }

    [Fact]
    public void Pop_WhenListIsEmpty_ThrowsInvalidOperationException()
    {
        // Arrange
        CustomLinkedList<int> list = new CustomLinkedList<int>();

        // Act
        Action act = () => list.Pop();

        // Assert
        Assert.Throws<InvalidOperationException>(act);
    }

    [Fact]
    public void GetHead_WhenListHasValues_ReturnsFirstValue()
    {
        // Arrange
        CustomLinkedList<int> list = CreateList(10, 20, 30);

        // Act
        int head = list.GetHead();

        // Assert
        Assert.Equal(10, head);
    }

    [Fact]
    public void GetHead_WhenListIsEmpty_ThrowsInvalidOperationException()
    {
        // Arrange
        CustomLinkedList<int> list = new CustomLinkedList<int>();

        // Act
        Action act = () => list.GetHead();

        // Assert
        Assert.Throws<InvalidOperationException>(act);
    }

    [Fact]
    public void GetTail_WhenListHasValues_ReturnsLastValue()
    {
        // Arrange
        CustomLinkedList<int> list = CreateList(10, 20, 30);

        // Act
        int tail = list.GetTail();

        // Assert
        Assert.Equal(30, tail);
    }

    [Fact]
    public void GetTail_WhenListIsEmpty_ThrowsInvalidOperationException()
    {
        // Arrange
        CustomLinkedList<int> list = new CustomLinkedList<int>();

        // Act
        Action act = () => list.GetTail();

        // Assert
        Assert.Throws<InvalidOperationException>(act);
    }

    [Fact]
    public void IsEmpty_WhenListHasValues_ReturnsFalse()
    {
        // Arrange
        CustomLinkedList<int> list = CreateList(10);

        // Act
        bool isEmpty = list.IsEmpty();

        // Assert
        Assert.False(isEmpty);
    }

    [Fact]
    public void IsEmpty_WhenListHasNoValues_ReturnsTrue()
    {
        // Arrange
        CustomLinkedList<int> list = new CustomLinkedList<int>();

        // Act
        bool isEmpty = list.IsEmpty();

        // Assert
        Assert.True(isEmpty);
    }

    [Fact]
    public void Reverse_WhenListHasMultipleValues_ReversesOrderAndUpdatesHeadAndTail()
    {
        // Arrange
        CustomLinkedList<int> list = CreateList(10, 20, 30, 40);

        // Act
        list.Reverse();

        // Assert
        Assert.Equal(4, list.Count);
        Assert.Equal(40, list.GetHead());
        Assert.Equal(10, list.GetTail());
        AssertListValues(list, 40, 30, 20, 10);
    }

    [Fact]
    public void Reverse_WhenListHasOneValue_KeepsSameValue()
    {
        // Arrange
        CustomLinkedList<int> list = CreateList(10);

        // Act
        list.Reverse();

        // Assert
        Assert.Equal(1, list.Count);
        Assert.Equal(10, list.GetHead());
        Assert.Equal(10, list.GetTail());
        AssertListValues(list, 10);
    }

    [Fact]
    public void Reverse_WhenListIsEmpty_KeepsListEmpty()
    {
        // Arrange
        CustomLinkedList<int> list = new CustomLinkedList<int>();

        // Act
        list.Reverse();

        // Assert
        Assert.Equal(0, list.Count);
        Assert.True(list.IsEmpty());
        Assert.Throws<InvalidOperationException>(() => list.GetHead());
        Assert.Throws<InvalidOperationException>(() => list.GetTail());
    }

    [Fact]
    public void Methods_WhenUsingStrings_WorkWithGenericValues()
    {
        // Arrange
        CustomLinkedList<string> list = new CustomLinkedList<string>();

        // Act
        list.AddToHead("middle");
        list.AddToTail("tail");
        list.AddAtIndex(0, "head");
        list.Reverse();

        // Assert
        Assert.Equal(3, list.Count);
        Assert.Equal("tail", list.GetHead());
        Assert.Equal("head", list.GetTail());
        Assert.Equal("tail", list.Get(0));
        Assert.Equal("middle", list.Get(1));
        Assert.Equal("head", list.Get(2));
    }

    private static CustomLinkedList<T> CreateList<T>(params T[] values)
    {
        CustomLinkedList<T> list = new CustomLinkedList<T>();

        foreach (T value in values)
        {
            list.AddToTail(value);
        }

        return list;
    }

    private static void AssertListValues<T>(
        CustomLinkedList<T> list,
        params T[] expectedValues)
    {
        Assert.Equal(expectedValues.Length, list.Count);

        for (int index = 0; index < expectedValues.Length; index++)
        {
            Assert.Equal(expectedValues[index], list.Get(index));
        }
    }
}
