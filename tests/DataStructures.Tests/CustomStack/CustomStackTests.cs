using DataStructures.CustomStack;

namespace DataStructures.Tests.CustomStack;

public class CustomStackTests
{
    [Fact]
    public void Constructor_WhenStackIsCreated_CreatesEmptyStack()
    {
        // Arrange & Act
        CustomStack<int> stack = new CustomStack<int>();

        // Assert
        Assert.Equal(0, stack.Count);
        Assert.Equal(0, stack.Size());
        Assert.True(stack.IsEmpty());
    }

    [Fact]
    public void Push_WhenValueIsAdded_IncreasesSize()
    {
        // Arrange
        CustomStack<int> stack = new CustomStack<int>();

        // Act
        stack.Push(10);

        // Assert
        Assert.Equal(1, stack.Count);
        Assert.Equal(1, stack.Size());
        Assert.False(stack.IsEmpty());
    }

    [Fact]
    public void Push_WhenMultipleValuesAreAdded_LastValueBecomesTop()
    {
        // Arrange
        CustomStack<int> stack = new CustomStack<int>();

        // Act
        stack.Push(10);
        stack.Push(20);
        stack.Push(30);

        // Assert
        Assert.Equal(3, stack.Count);
        Assert.Equal(30, stack.Peek());
    }

    [Fact]
    public void Peek_WhenStackHasValues_ReturnsTopValueWithoutRemovingIt()
    {
        // Arrange
        CustomStack<int> stack = new CustomStack<int>();
        stack.Push(10);
        stack.Push(20);

        // Act
        int topValue = stack.Peek();

        // Assert
        Assert.Equal(20, topValue);
        Assert.Equal(2, stack.Count);
        Assert.Equal(20, stack.Peek());
    }

    [Fact]
    public void Peek_WhenStackIsEmpty_ThrowsInvalidOperationException()
    {
        // Arrange
        CustomStack<int> stack = new CustomStack<int>();

        // Act
        Action act = () => stack.Peek();

        // Assert
        Assert.Throws<InvalidOperationException>(act);
    }

    [Fact]
    public void Pop_WhenStackHasValues_RemovesAndReturnsTopValue()
    {
        // Arrange
        CustomStack<int> stack = new CustomStack<int>();
        stack.Push(10);
        stack.Push(20);
        stack.Push(30);

        // Act
        int poppedValue = stack.Pop();

        // Assert
        Assert.Equal(30, poppedValue);
        Assert.Equal(2, stack.Count);
        Assert.Equal(20, stack.Peek());
    }

    [Fact]
    public void Pop_WhenCalledMultipleTimes_ReturnsValuesInLifoOrder()
    {
        // Arrange
        CustomStack<int> stack = new CustomStack<int>();
        stack.Push(10);
        stack.Push(20);
        stack.Push(30);

        // Act
        int firstPoppedValue = stack.Pop();
        int secondPoppedValue = stack.Pop();
        int thirdPoppedValue = stack.Pop();

        // Assert
        Assert.Equal(30, firstPoppedValue);
        Assert.Equal(20, secondPoppedValue);
        Assert.Equal(10, thirdPoppedValue);
        Assert.Equal(0, stack.Count);
        Assert.True(stack.IsEmpty());
    }

    [Fact]
    public void Pop_WhenStackIsEmpty_ThrowsInvalidOperationException()
    {
        // Arrange
        CustomStack<int> stack = new CustomStack<int>();

        // Act
        Action act = () => stack.Pop();

        // Assert
        Assert.Throws<InvalidOperationException>(act);
    }

    [Fact]
    public void Methods_WhenUsingStrings_WorkWithGenericValues()
    {
        // Arrange
        CustomStack<string> stack = new CustomStack<string>();

        // Act
        stack.Push("first");
        stack.Push("second");
        stack.Push("third");

        string firstPoppedValue = stack.Pop();
        string topValue = stack.Peek();

        // Assert
        Assert.Equal("third", firstPoppedValue);
        Assert.Equal("second", topValue);
        Assert.Equal(2, stack.Count);
    }

    [Fact]
    public void LearningContract_WhenStackIsReimplemented_ShouldPreserveCoreBehavior()
    {
        // Arrange
        CustomStack<int> stack = new CustomStack<int>();

        // Act
        stack.Push(5);
        stack.Push(10);
        stack.Push(15);
        int peekBeforePop = stack.Peek();
        int firstPop = stack.Pop();
        stack.Push(20);
        int secondPop = stack.Pop();
        int thirdPop = stack.Pop();
        int fourthPop = stack.Pop();

        // Assert
        Assert.Equal(15, peekBeforePop);
        Assert.Equal(15, firstPop);
        Assert.Equal(20, secondPop);
        Assert.Equal(10, thirdPop);
        Assert.Equal(5, fourthPop);
        Assert.Equal(0, stack.Count);
        Assert.True(stack.IsEmpty());
    }
}
