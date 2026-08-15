using System.Diagnostics;
using DataStructures.Algorithms.Arrays;
using DataStructures.CustomDynamicArrays;
using Xunit.Abstractions;

namespace DataStructures.Tests.Algorithms.Arrays;

public class SlidingWindowVariableSizeTests
{
    private readonly ITestOutputHelper _output;

    public SlidingWindowVariableSizeTests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void LongestSubarrayWithSameValue_WhenArrayHasRepeatedValues_ReturnsLongestRunLength()
    {
        // Arrange
        int[] nums = { 4, 2, 2, 3, 3, 3 };

        // Act
        int length = SlidingWindowVariableSize.LongestSubarrayWithSameValue(nums);

        // Assert
        Assert.Equal(3, length);
    }

    [Fact]
    public void LongestSubarrayWithSameValue_WhenAllValuesAreTheSame_ReturnsArrayLength()
    {
        // Arrange
        int[] nums = { 7, 7, 7, 7 };

        // Act
        int length = SlidingWindowVariableSize.LongestSubarrayWithSameValue(nums);

        // Assert
        Assert.Equal(4, length);
    }

    [Fact]
    public void LongestSubarrayWithSameValue_WhenAllValuesAreDifferent_ReturnsOne()
    {
        // Arrange
        int[] nums = { 1, 2, 3, 4 };

        // Act
        int length = SlidingWindowVariableSize.LongestSubarrayWithSameValue(nums);

        // Assert
        Assert.Equal(1, length);
    }

    [Fact]
    public void LongestSubarrayWithSameValue_WhenArrayIsEmpty_ReturnsZero()
    {
        // Arrange
        int[] nums = Array.Empty<int>();

        // Act
        int length = SlidingWindowVariableSize.LongestSubarrayWithSameValue(nums);

        // Assert
        Assert.Equal(0, length);
    }

    [Fact]
    public void LongestSubarrayWithSameValue_WhenUsingCustomDynamicArray_ReturnsLongestRunLength()
    {
        // Arrange
        CustomDynamicArray<int> nums = CreateDynamicArray(4, 2, 2, 3, 3, 3);

        // Act
        int length = SlidingWindowVariableSize.LongestSubarrayWithSameValue(nums);

        // Assert
        Assert.Equal(3, length);
    }

    [Fact]
    public void LongestSubarrayWithSameValue_WhenUsingEnumerableSequence_ReturnsLongestRunLength()
    {
        // Arrange
        IEnumerable<int> nums = new List<int> { 4, 2, 2, 3, 3, 3 };

        // Act
        int length = SlidingWindowVariableSize.LongestSubarrayWithSameValue(nums);

        // Assert
        Assert.Equal(3, length);
    }

    [Fact]
    public void LongestSubarrayWithSameValue_WhenArrayIsNull_ThrowsArgumentNullException()
    {
        // Arrange
        int[] nums = null!;

        // Act
        Action act = () => SlidingWindowVariableSize.LongestSubarrayWithSameValue(nums);

        // Assert
        Assert.Throws<ArgumentNullException>(act);
    }

    [Fact]
    public void ShortestSubarrayWithSumAtLeastTarget_WhenValidWindowExists_ReturnsShortestLength()
    {
        // Arrange
        int[] nums = { 2, 3, 1, 2, 4, 3 };
        const int target = 7;

        // Act
        int length = SlidingWindowVariableSize.ShortestSubarrayWithSumAtLeastTarget(nums, target);

        // Assert
        Assert.Equal(2, length);
    }

    [Fact]
    public void ShortestSubarrayWithSumAtLeastTarget_WhenSingleValueReachesTarget_ReturnsOne()
    {
        // Arrange
        int[] nums = { 1, 2, 10, 1 };
        const int target = 7;

        // Act
        int length = SlidingWindowVariableSize.ShortestSubarrayWithSumAtLeastTarget(nums, target);

        // Assert
        Assert.Equal(1, length);
    }

    [Fact]
    public void ShortestSubarrayWithSumAtLeastTarget_WhenNoWindowReachesTarget_ReturnsZero()
    {
        // Arrange
        int[] nums = { 1, 1, 1, 1 };
        const int target = 10;

        // Act
        int length = SlidingWindowVariableSize.ShortestSubarrayWithSumAtLeastTarget(nums, target);

        // Assert
        Assert.Equal(0, length);
    }

    [Fact]
    public void ShortestSubarrayWithSumAtLeastTarget_WhenArrayIsEmpty_ReturnsZero()
    {
        // Arrange
        int[] nums = Array.Empty<int>();
        const int target = 7;

        // Act
        int length = SlidingWindowVariableSize.ShortestSubarrayWithSumAtLeastTarget(nums, target);

        // Assert
        Assert.Equal(0, length);
    }

    [Fact]
    public void ShortestSubarrayWithSumAtLeastTarget_WhenUsingCustomDynamicArray_ReturnsShortestLength()
    {
        // Arrange
        CustomDynamicArray<int> nums = CreateDynamicArray(2, 3, 1, 2, 4, 3);
        const int target = 7;

        // Act
        int length = SlidingWindowVariableSize.ShortestSubarrayWithSumAtLeastTarget(nums, target);

        // Assert
        Assert.Equal(2, length);
    }

    [Fact]
    public void ShortestSubarrayWithSumAtLeastTarget_WhenUsingEnumerableSequence_ReturnsShortestLength()
    {
        // Arrange
        IEnumerable<int> nums = new List<int> { 2, 3, 1, 2, 4, 3 };
        const int target = 7;

        // Act
        int length = SlidingWindowVariableSize.ShortestSubarrayWithSumAtLeastTarget(nums, target);

        // Assert
        Assert.Equal(2, length);
    }

    [Fact]
    public void ShortestSubarrayWithSumAtLeastTarget_WhenArrayIsNull_ThrowsArgumentNullException()
    {
        // Arrange
        int[] nums = null!;
        const int target = 7;

        // Act
        Action act = () => SlidingWindowVariableSize.ShortestSubarrayWithSumAtLeastTarget(nums, target);

        // Assert
        Assert.Throws<ArgumentNullException>(act);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void ShortestSubarrayWithSumAtLeastTarget_WhenTargetIsNotPositive_ThrowsArgumentOutOfRangeException(int target)
    {
        // Arrange
        int[] nums = { 1, 2, 3 };

        // Act
        Action act = () => SlidingWindowVariableSize.ShortestSubarrayWithSumAtLeastTarget(nums, target);

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(act);
    }

    [Fact]
    public void LearningContract_WhenSlidingWindowIsReimplemented_ShouldHandleCommonScenarios()
    {
        // Arrange
        int[] sameValueInput = { 4, 2, 2, 3, 3, 3 };
        int[] targetInput = { 2, 3, 1, 2, 4, 3 };

        // Act
        int longestSameValueLength = SlidingWindowVariableSize.LongestSubarrayWithSameValue(sameValueInput);
        int shortestTargetLength = SlidingWindowVariableSize.ShortestSubarrayWithSumAtLeastTarget(targetInput, 7);
        int noTargetLength = SlidingWindowVariableSize.ShortestSubarrayWithSumAtLeastTarget(new[] { 1, 1, 1 }, 10);

        // Assert
        Assert.Equal(3, longestSameValueLength);
        Assert.Equal(2, shortestTargetLength);
        Assert.Equal(0, noTargetLength);
    }

    [Fact]
    public void Timing_LongestSubarrayWithSameValueForLargeArray_WritesElapsedTime()
    {
        // Arrange
        const int numberOfValues = 100_000;
        int[] nums = new int[numberOfValues];

        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] = i < 50_000 ? 1 : 2;
        }

        // Act
        int length = 0;
        TimeSpan elapsed = Measure(() =>
        {
            length = SlidingWindowVariableSize.LongestSubarrayWithSameValue(nums);
        });

        // Assert
        Assert.Equal(50_000, length);
        _output.WriteLine($"SlidingWindow LongestSubarrayWithSameValue int[{numberOfValues}]: {elapsed.TotalMilliseconds:F3} ms");
    }

    [Fact]
    public void Timing_ShortestSubarrayWithSumAtLeastTargetForLargeArray_WritesElapsedTime()
    {
        // Arrange
        const int numberOfValues = 100_000;
        int[] nums = new int[numberOfValues];

        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] = 1;
        }

        // Act
        int length = 0;
        TimeSpan elapsed = Measure(() =>
        {
            length = SlidingWindowVariableSize.ShortestSubarrayWithSumAtLeastTarget(nums, 500);
        });

        // Assert
        Assert.Equal(500, length);
        _output.WriteLine($"SlidingWindow ShortestSubarrayWithSumAtLeastTarget int[{numberOfValues}]: {elapsed.TotalMilliseconds:F3} ms");
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
