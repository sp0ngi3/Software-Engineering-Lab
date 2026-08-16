using DataStructures.CustomQueue;

namespace DataStructures.Tests.CustomQueue;

public class CustomQueueTests
{
    [Fact]
    public void Constructor_WhenQueueIsCreated_CreatesEmptyQueue()
    {
        // Arrange & Act
        CustomQueue<int> queue = new CustomQueue<int>();

        // Assert
        Assert.Equal(0, queue.Count);
        Assert.Equal(0, queue.Size());
        Assert.True(queue.IsEmpty());
    }

    [Fact]
    public void Enqueue_WhenValueIsAdded_IncreasesSize()
    {
        // Arrange
        CustomQueue<int> queue = new CustomQueue<int>();

        // Act
        queue.Enqueue(10);

        // Assert
        Assert.Equal(1, queue.Count);
        Assert.Equal(1, queue.Size());
        Assert.False(queue.IsEmpty());
    }

    [Fact]
    public void Enqueue_WhenMultipleValuesAreAdded_FirstValueStaysAtFront()
    {
        // Arrange
        CustomQueue<int> queue = new CustomQueue<int>();

        // Act
        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);

        // Assert
        Assert.Equal(3, queue.Count);
        Assert.Equal(10, queue.Peek());
    }

    [Fact]
    public void Peek_WhenQueueHasValues_ReturnsFrontValueWithoutRemovingIt()
    {
        // Arrange
        CustomQueue<int> queue = new CustomQueue<int>();
        queue.Enqueue(10);
        queue.Enqueue(20);

        // Act
        int frontValue = queue.Peek();

        // Assert
        Assert.Equal(10, frontValue);
        Assert.Equal(2, queue.Count);
        Assert.Equal(10, queue.Peek());
    }

    [Fact]
    public void Peek_WhenQueueIsEmpty_ThrowsInvalidOperationException()
    {
        // Arrange
        CustomQueue<int> queue = new CustomQueue<int>();

        // Act
        Action act = () => queue.Peek();

        // Assert
        Assert.Throws<InvalidOperationException>(act);
    }

    [Fact]
    public void Dequeue_WhenQueueHasValues_RemovesAndReturnsFrontValue()
    {
        // Arrange
        CustomQueue<int> queue = new CustomQueue<int>();
        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);

        // Act
        int dequeuedValue = queue.Dequeue();

        // Assert
        Assert.Equal(10, dequeuedValue);
        Assert.Equal(2, queue.Count);
        Assert.Equal(20, queue.Peek());
    }

    [Fact]
    public void Dequeue_WhenCalledMultipleTimes_ReturnsValuesInFifoOrder()
    {
        // Arrange
        CustomQueue<int> queue = new CustomQueue<int>();
        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);

        // Act
        int firstDequeuedValue = queue.Dequeue();
        int secondDequeuedValue = queue.Dequeue();
        int thirdDequeuedValue = queue.Dequeue();

        // Assert
        Assert.Equal(10, firstDequeuedValue);
        Assert.Equal(20, secondDequeuedValue);
        Assert.Equal(30, thirdDequeuedValue);
        Assert.Equal(0, queue.Count);
        Assert.True(queue.IsEmpty());
    }

    [Fact]
    public void Dequeue_WhenQueueBecomesEmpty_AllowsEnqueueAgain()
    {
        // Arrange
        CustomQueue<int> queue = new CustomQueue<int>();
        queue.Enqueue(10);
        queue.Dequeue();

        // Act
        queue.Enqueue(20);
        int dequeuedValue = queue.Dequeue();

        // Assert
        Assert.Equal(20, dequeuedValue);
        Assert.Equal(0, queue.Count);
        Assert.True(queue.IsEmpty());
    }

    [Fact]
    public void Dequeue_WhenQueueIsEmpty_ThrowsInvalidOperationException()
    {
        // Arrange
        CustomQueue<int> queue = new CustomQueue<int>();

        // Act
        Action act = () => queue.Dequeue();

        // Assert
        Assert.Throws<InvalidOperationException>(act);
    }

    [Fact]
    public void Methods_WhenUsingStrings_WorkWithGenericValues()
    {
        // Arrange
        CustomQueue<string> queue = new CustomQueue<string>();

        // Act
        queue.Enqueue("first");
        queue.Enqueue("second");
        queue.Enqueue("third");

        string firstDequeuedValue = queue.Dequeue();
        string frontValue = queue.Peek();

        // Assert
        Assert.Equal("first", firstDequeuedValue);
        Assert.Equal("second", frontValue);
        Assert.Equal(2, queue.Count);
    }

    [Fact]
    public void LearningContract_WhenQueueIsReimplemented_ShouldPreserveCoreBehavior()
    {
        // Arrange
        CustomQueue<int> queue = new CustomQueue<int>();

        // Act
        queue.Enqueue(5);
        queue.Enqueue(10);
        queue.Enqueue(15);
        int peekBeforeDequeue = queue.Peek();
        int firstDequeue = queue.Dequeue();
        queue.Enqueue(20);
        int secondDequeue = queue.Dequeue();
        int thirdDequeue = queue.Dequeue();
        int fourthDequeue = queue.Dequeue();

        // Assert
        Assert.Equal(5, peekBeforeDequeue);
        Assert.Equal(5, firstDequeue);
        Assert.Equal(10, secondDequeue);
        Assert.Equal(15, thirdDequeue);
        Assert.Equal(20, fourthDequeue);
        Assert.Equal(0, queue.Count);
        Assert.True(queue.IsEmpty());
    }
}
