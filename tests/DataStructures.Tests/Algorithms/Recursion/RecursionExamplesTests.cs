using System.Diagnostics;
using DataStructures.Algorithms.Recursion;
using Xunit.Abstractions;

namespace DataStructures.Tests.Algorithms.Recursion;

public class RecursionExamplesTests
{
    private readonly ITestOutputHelper _output;

    public RecursionExamplesTests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void FactorialRecursive_WhenInputIsFive_ReturnsOneHundredTwenty()
    {
        // Arrange
        const int n = 5;

        // Act
        int result = RecursionExamples.FactorialRecursive(n);

        // Assert
        Assert.Equal(120, result);
    }

    [Fact]
    public void FactorialIterative_WhenInputIsFive_ReturnsOneHundredTwenty()
    {
        // Arrange
        const int n = 5;

        // Act
        int result = RecursionExamples.FactorialIterative(n);

        // Assert
        Assert.Equal(120, result);
    }

    [Theory]
    [InlineData(0, 1)]
    [InlineData(1, 1)]
    [InlineData(3, 6)]
    [InlineData(5, 120)]
    public void FactorialMethods_WhenInputIsValid_ReturnSameResult(int n, int expected)
    {
        // Arrange & Act
        int recursiveResult = RecursionExamples.FactorialRecursive(n);
        int iterativeResult = RecursionExamples.FactorialIterative(n);

        // Assert
        Assert.Equal(expected, recursiveResult);
        Assert.Equal(expected, iterativeResult);
        Assert.Equal(recursiveResult, iterativeResult);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(13)]
    public void FactorialRecursive_WhenInputIsOutsideSupportedRange_ThrowsArgumentOutOfRangeException(int n)
    {
        // Arrange & Act
        Action act = () => RecursionExamples.FactorialRecursive(n);

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(act);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(13)]
    public void FactorialIterative_WhenInputIsOutsideSupportedRange_ThrowsArgumentOutOfRangeException(int n)
    {
        // Arrange & Act
        Action act = () => RecursionExamples.FactorialIterative(n);

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(act);
    }

    [Fact]
    public void FibonacciRecursive_WhenInputIsTen_ReturnsFiftyFive()
    {
        // Arrange
        const int n = 10;

        // Act
        int result = RecursionExamples.FibonacciRecursive(n);

        // Assert
        Assert.Equal(55, result);
    }

    [Fact]
    public void FibonacciIterative_WhenInputIsTen_ReturnsFiftyFive()
    {
        // Arrange
        const int n = 10;

        // Act
        int result = RecursionExamples.FibonacciIterative(n);

        // Assert
        Assert.Equal(55, result);
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(2, 1)]
    [InlineData(3, 2)]
    [InlineData(7, 13)]
    [InlineData(10, 55)]
    public void FibonacciMethods_WhenInputIsValid_ReturnSameResult(int n, int expected)
    {
        // Arrange & Act
        int recursiveResult = RecursionExamples.FibonacciRecursive(n);
        int iterativeResult = RecursionExamples.FibonacciIterative(n);

        // Assert
        Assert.Equal(expected, recursiveResult);
        Assert.Equal(expected, iterativeResult);
        Assert.Equal(recursiveResult, iterativeResult);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(41)]
    public void FibonacciRecursive_WhenInputIsOutsideSupportedRange_ThrowsArgumentOutOfRangeException(int n)
    {
        // Arrange & Act
        Action act = () => RecursionExamples.FibonacciRecursive(n);

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(act);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(47)]
    public void FibonacciIterative_WhenInputIsOutsideSupportedRange_ThrowsArgumentOutOfRangeException(int n)
    {
        // Arrange & Act
        Action act = () => RecursionExamples.FibonacciIterative(n);

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(act);
    }

    [Fact]
    public void LearningContract_WhenRecursionExamplesAreReimplemented_ShouldPreserveCoreBehavior()
    {
        // Arrange
        const int factorialInput = 5;
        const int fibonacciInput = 10;

        // Act
        int recursiveFactorial = RecursionExamples.FactorialRecursive(factorialInput);
        int iterativeFactorial = RecursionExamples.FactorialIterative(factorialInput);
        int recursiveFibonacci = RecursionExamples.FibonacciRecursive(fibonacciInput);
        int iterativeFibonacci = RecursionExamples.FibonacciIterative(fibonacciInput);

        // Assert
        Assert.Equal(120, recursiveFactorial);
        Assert.Equal(120, iterativeFactorial);
        Assert.Equal(55, recursiveFibonacci);
        Assert.Equal(55, iterativeFibonacci);
    }

    [Fact]
    public void Timing_FactorialRecursiveAndIterative_WritesElapsedTime()
    {
        // Arrange
        const int n = 12;

        // Act
        int recursiveResult = 0;
        TimeSpan recursiveElapsed = Measure(() =>
        {
            recursiveResult = RecursionExamples.FactorialRecursive(n);
        });

        int iterativeResult = 0;
        TimeSpan iterativeElapsed = Measure(() =>
        {
            iterativeResult = RecursionExamples.FactorialIterative(n);
        });

        // Assert
        Assert.Equal(479001600, recursiveResult);
        Assert.Equal(479001600, iterativeResult);
        _output.WriteLine($"FactorialRecursive({n}): {recursiveElapsed.TotalMilliseconds:F3} ms");
        _output.WriteLine($"FactorialIterative({n}): {iterativeElapsed.TotalMilliseconds:F3} ms");
    }

    [Fact]
    public void Timing_FibonacciRecursiveAndIterative_WritesElapsedTime()
    {
        // Arrange
        const int n = 20;

        // Act
        int recursiveResult = 0;
        TimeSpan recursiveElapsed = Measure(() =>
        {
            recursiveResult = RecursionExamples.FibonacciRecursive(n);
        });

        int iterativeResult = 0;
        TimeSpan iterativeElapsed = Measure(() =>
        {
            iterativeResult = RecursionExamples.FibonacciIterative(n);
        });

        // Assert
        Assert.Equal(6765, recursiveResult);
        Assert.Equal(6765, iterativeResult);
        _output.WriteLine($"FibonacciRecursive({n}): {recursiveElapsed.TotalMilliseconds:F3} ms");
        _output.WriteLine($"FibonacciIterative({n}): {iterativeElapsed.TotalMilliseconds:F3} ms");
    }

    private static TimeSpan Measure(Action act)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        act();

        stopwatch.Stop();
        return stopwatch.Elapsed;
    }
}
