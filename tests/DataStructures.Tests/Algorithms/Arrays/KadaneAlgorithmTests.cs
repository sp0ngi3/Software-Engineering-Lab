using System.Diagnostics;
using DataStructures.Algorithms.Arrays;
using DataStructures.CustomDynamicArrays;
using Xunit.Abstractions;

namespace DataStructures.Tests.Algorithms.Arrays;

public class KadaneAlgorithmTests
{
    private readonly ITestOutputHelper _output;

    public KadaneAlgorithmTests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void MaxSubarraySum_WhenArrayHasMixedValues_ReturnsMaximumSubarraySum()
    {
        // Arrange
        int[] nums = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };

        // Act
        int maxSum = KadaneAlgorithm.MaxSubarraySum(nums);

        // Assert
        Assert.Equal(6, maxSum);
    }

    [Fact]
    public void MaxSubarraySum_WhenAllValuesAreNegative_ReturnsLargestNegativeValue()
    {
        // Arrange
        int[] nums = { -8, -3, -6, -2, -5 };

        // Act
        int maxSum = KadaneAlgorithm.MaxSubarraySum(nums);

        // Assert
        Assert.Equal(-2, maxSum);
    }

    [Fact]
    public void MaxSubarraySum_WhenSequenceHasOneValue_ReturnsThatValue()
    {
        // Arrange
        int[] nums = { 7 };

        // Act
        int maxSum = KadaneAlgorithm.MaxSubarraySum(nums);

        // Assert
        Assert.Equal(7, maxSum);
    }

    [Fact]
    public void MaxSubarraySum_WhenUsingCustomDynamicArray_ReturnsMaximumSubarraySum()
    {
        // Arrange
        CustomDynamicArray<int> nums = CreateDynamicArray(-2, 1, -3, 4, -1, 2, 1, -5, 4);

        // Act
        int maxSum = KadaneAlgorithm.MaxSubarraySum(nums);

        // Assert
        Assert.Equal(6, maxSum);
    }

    [Fact]
    public void MaxSubarraySum_WhenUsingEnumerableSequence_ReturnsMaximumSubarraySum()
    {
        // Arrange
        IEnumerable<int> nums = new List<int> { -2, 1, -3, 4, -1, 2, 1, -5, 4 };

        // Act
        int maxSum = KadaneAlgorithm.MaxSubarraySum(nums);

        // Assert
        Assert.Equal(6, maxSum);
    }

    [Fact]
    public void MaxSubarraySum_WhenSequenceIsEmpty_ThrowsArgumentException()
    {
        // Arrange
        int[] nums = Array.Empty<int>();

        // Act
        Action act = () => KadaneAlgorithm.MaxSubarraySum(nums);

        // Assert
        Assert.Throws<ArgumentException>(act);
    }

    [Fact]
    public void MaxSubarraySum_WhenSequenceIsNull_ThrowsArgumentNullException()
    {
        // Arrange
        IEnumerable<int> nums = null!;

        // Act
        Action act = () => KadaneAlgorithm.MaxSubarraySum(nums);

        // Assert
        Assert.Throws<ArgumentNullException>(act);
    }

    [Fact]
    public void FindMaxSubarrayRange_WhenArrayHasMixedValues_ReturnsStartAndEndIndexes()
    {
        // Arrange
        int[] nums = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };

        // Act
        int[] range = KadaneAlgorithm.FindMaxSubarrayRange(nums);

        // Assert
        Assert.Equal(new[] { 3, 6 }, range);
    }

    [Fact]
    public void FindMaxSubarrayRange_WhenAllValuesAreNegative_ReturnsIndexOfLargestNegativeValue()
    {
        // Arrange
        int[] nums = { -8, -3, -6, -2, -5 };

        // Act
        int[] range = KadaneAlgorithm.FindMaxSubarrayRange(nums);

        // Assert
        Assert.Equal(new[] { 3, 3 }, range);
    }

    [Fact]
    public void FindMaxSubarrayRange_WhenSequenceHasOneValue_ReturnsZeroRange()
    {
        // Arrange
        int[] nums = { 7 };

        // Act
        int[] range = KadaneAlgorithm.FindMaxSubarrayRange(nums);

        // Assert
        Assert.Equal(new[] { 0, 0 }, range);
    }

    [Fact]
    public void FindMaxSubarrayRange_WhenUsingCustomDynamicArray_ReturnsStartAndEndIndexes()
    {
        // Arrange
        CustomDynamicArray<int> nums = CreateDynamicArray(-2, 1, -3, 4, -1, 2, 1, -5, 4);

        // Act
        int[] range = KadaneAlgorithm.FindMaxSubarrayRange(nums);

        // Assert
        Assert.Equal(new[] { 3, 6 }, range);
    }

    [Fact]
    public void FindMaxSubarrayRange_WhenUsingEnumerableSequence_ReturnsStartAndEndIndexes()
    {
        // Arrange
        IEnumerable<int> nums = new List<int> { -2, 1, -3, 4, -1, 2, 1, -5, 4 };

        // Act
        int[] range = KadaneAlgorithm.FindMaxSubarrayRange(nums);

        // Assert
        Assert.Equal(new[] { 3, 6 }, range);
    }

    [Fact]
    public void FindMaxSubarrayRange_WhenSequenceIsEmpty_ThrowsArgumentException()
    {
        // Arrange
        int[] nums = Array.Empty<int>();

        // Act
        Action act = () => KadaneAlgorithm.FindMaxSubarrayRange(nums);

        // Assert
        Assert.Throws<ArgumentException>(act);
    }

    [Fact]
    public void FindMaxSubarrayRange_WhenSequenceIsNull_ThrowsArgumentNullException()
    {
        // Arrange
        IEnumerable<int> nums = null!;

        // Act
        Action act = () => KadaneAlgorithm.FindMaxSubarrayRange(nums);

        // Assert
        Assert.Throws<ArgumentNullException>(act);
    }

    [Fact]
    public void LearningContract_WhenAlgorithmIsReimplemented_ShouldHandleCommonEdgeCases()
    {
        // Arrange
        int[] mixedNumbers = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
        int[] negativeNumbers = { -8, -3, -6, -2, -5 };
        int[] oneNumber = { 7 };

        // Act
        int mixedMaxSum = KadaneAlgorithm.MaxSubarraySum(mixedNumbers);
        int[] mixedRange = KadaneAlgorithm.FindMaxSubarrayRange(mixedNumbers);
        int negativeMaxSum = KadaneAlgorithm.MaxSubarraySum(negativeNumbers);
        int[] negativeRange = KadaneAlgorithm.FindMaxSubarrayRange(negativeNumbers);
        int oneNumberMaxSum = KadaneAlgorithm.MaxSubarraySum(oneNumber);
        int[] oneNumberRange = KadaneAlgorithm.FindMaxSubarrayRange(oneNumber);

        // Assert
        Assert.Equal(6, mixedMaxSum);
        Assert.Equal(new[] { 3, 6 }, mixedRange);
        Assert.Equal(-2, negativeMaxSum);
        Assert.Equal(new[] { 3, 3 }, negativeRange);
        Assert.Equal(7, oneNumberMaxSum);
        Assert.Equal(new[] { 0, 0 }, oneNumberRange);
    }

    [Fact]
    public void Timing_MaxSubarraySumForLargeArray_WritesElapsedTime()
    {
        // Arrange
        const int numberOfValues = 100_000;
        int[] nums = new int[numberOfValues];

        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] = 1;
        }

        // Act
        int maxSum = 0;
        TimeSpan elapsed = Measure(() =>
        {
            maxSum = KadaneAlgorithm.MaxSubarraySum(nums);
        });

        // Assert
        Assert.Equal(numberOfValues, maxSum);
        _output.WriteLine($"Kadane MaxSubarraySum int[{numberOfValues}]: {elapsed.TotalMilliseconds:F3} ms");
    }

    [Fact]
    public void Timing_MaxSubarrayRangeForCustomDynamicArray_WritesElapsedTime()
    {
        // Arrange
        const int numberOfValues = 10_000;
        CustomDynamicArray<int> nums = new CustomDynamicArray<int>();

        for (int i = 0; i < numberOfValues; i++)
        {
            nums.Add(1);
        }

        // Act
        int[] range = Array.Empty<int>();
        TimeSpan elapsed = Measure(() =>
        {
            range = KadaneAlgorithm.FindMaxSubarrayRange(nums);
        });

        // Assert
        Assert.Equal(new[] { 0, numberOfValues - 1 }, range);
        _output.WriteLine($"Kadane FindMaxSubarrayRange CustomDynamicArray with {numberOfValues} values: {elapsed.TotalMilliseconds:F3} ms");
    }

    private static CustomDynamicArray<int> CreateDynamicArray(params int[] values)
    {
        CustomDynamicArray<int> nums = new CustomDynamicArray<int>();

        foreach (int value in values)
        {
            nums.Add(value);
        }

        return nums;
    }

    private static TimeSpan Measure(Action act)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        act();

        stopwatch.Stop();
        return stopwatch.Elapsed;
    }
}
