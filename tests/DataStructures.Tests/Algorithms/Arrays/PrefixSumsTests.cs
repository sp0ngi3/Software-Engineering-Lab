using System.Diagnostics;
using DataStructures.Algorithms.Arrays;
using DataStructures.CustomDynamicArrays;
using Xunit.Abstractions;

namespace DataStructures.Tests.Algorithms.Arrays;

public class PrefixSumsTests
{
    private readonly ITestOutputHelper _output;

    public PrefixSumsTests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void BuildPrefixSum_WhenArrayHasValues_ReturnsPrefixSumArray()
    {
        // Arrange
        int[] nums = { 2, -1, 3, 5 };

        // Act
        int[] prefixSums = PrefixSums.BuildPrefixSum(nums);

        // Assert
        Assert.Equal(new[] { 0, 2, 1, 4, 9 }, prefixSums);
    }

    [Fact]
    public void BuildPrefixSum_WhenArrayIsEmpty_ReturnsArrayWithStartingZero()
    {
        // Arrange
        int[] nums = Array.Empty<int>();

        // Act
        int[] prefixSums = PrefixSums.BuildPrefixSum(nums);

        // Assert
        Assert.Equal(new[] { 0 }, prefixSums);
    }

    [Fact]
    public void BuildPrefixSum_WhenUsingCustomDynamicArray_ReturnsPrefixSumArray()
    {
        // Arrange
        CustomDynamicArray<int> nums = CreateDynamicArray(2, -1, 3, 5);

        // Act
        int[] prefixSums = PrefixSums.BuildPrefixSum(nums);

        // Assert
        Assert.Equal(new[] { 0, 2, 1, 4, 9 }, prefixSums);
    }

    [Fact]
    public void BuildPrefixSum_WhenUsingEnumerableSequence_ReturnsPrefixSumArray()
    {
        // Arrange
        IEnumerable<int> nums = new List<int> { 2, -1, 3, 5 };

        // Act
        int[] prefixSums = PrefixSums.BuildPrefixSum(nums);

        // Assert
        Assert.Equal(new[] { 0, 2, 1, 4, 9 }, prefixSums);
    }

    [Fact]
    public void BuildPrefixSum_WhenArrayIsNull_ThrowsArgumentNullException()
    {
        // Arrange
        int[] nums = null!;

        // Act
        Action act = () => PrefixSums.BuildPrefixSum(nums);

        // Assert
        Assert.Throws<ArgumentNullException>(act);
    }

    [Fact]
    public void RangeSumFromPrefixSum_WhenRangeHasMultipleValues_ReturnsRangeSum()
    {
        // Arrange
        int[] nums = { 2, -1, 3, 5 };
        int[] prefixSums = PrefixSums.BuildPrefixSum(nums);

        // Act
        int rangeSum = PrefixSums.RangeSumFromPrefixSum(prefixSums, 1, 3);

        // Assert
        Assert.Equal(7, rangeSum);
    }

    [Fact]
    public void RangeSumFromPrefixSum_WhenRangeHasOneValue_ReturnsThatValue()
    {
        // Arrange
        int[] nums = { 2, -1, 3, 5 };
        int[] prefixSums = PrefixSums.BuildPrefixSum(nums);

        // Act
        int rangeSum = PrefixSums.RangeSumFromPrefixSum(prefixSums, 2, 2);

        // Assert
        Assert.Equal(3, rangeSum);
    }

    [Fact]
    public void RangeSumFromPrefixSum_WhenPrefixSumArrayIsNull_ThrowsArgumentNullException()
    {
        // Arrange
        int[] prefixSums = null!;

        // Act
        Action act = () => PrefixSums.RangeSumFromPrefixSum(prefixSums, 0, 1);

        // Assert
        Assert.Throws<ArgumentNullException>(act);
    }

    [Theory]
    [InlineData(-1, 1)]
    [InlineData(2, 1)]
    [InlineData(0, 4)]
    public void RangeSumFromPrefixSum_WhenRangeIsInvalid_ThrowsArgumentOutOfRangeException(int left, int right)
    {
        // Arrange
        int[] nums = { 2, -1, 3, 5 };
        int[] prefixSums = PrefixSums.BuildPrefixSum(nums);

        // Act
        Action act = () => PrefixSums.RangeSumFromPrefixSum(prefixSums, left, right);

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(act);
    }

    [Fact]
    public void BuildPrefixProduct_WhenArrayHasValues_ReturnsPrefixProductArray()
    {
        // Arrange
        int[] nums = { 2, 3, 4 };

        // Act
        int[] prefixProducts = PrefixSums.BuildPrefixProduct(nums);

        // Assert
        Assert.Equal(new[] { 1, 2, 6, 24 }, prefixProducts);
    }

    [Fact]
    public void BuildPrefixProduct_WhenArrayIsEmpty_ReturnsArrayWithStartingOne()
    {
        // Arrange
        int[] nums = Array.Empty<int>();

        // Act
        int[] prefixProducts = PrefixSums.BuildPrefixProduct(nums);

        // Assert
        Assert.Equal(new[] { 1 }, prefixProducts);
    }

    [Fact]
    public void BuildPrefixProduct_WhenUsingCustomDynamicArray_ReturnsPrefixProductArray()
    {
        // Arrange
        CustomDynamicArray<int> nums = CreateDynamicArray(2, 3, 4);

        // Act
        int[] prefixProducts = PrefixSums.BuildPrefixProduct(nums);

        // Assert
        Assert.Equal(new[] { 1, 2, 6, 24 }, prefixProducts);
    }

    [Fact]
    public void BuildPrefixProduct_WhenUsingEnumerableSequence_ReturnsPrefixProductArray()
    {
        // Arrange
        IEnumerable<int> nums = new List<int> { 2, 3, 4 };

        // Act
        int[] prefixProducts = PrefixSums.BuildPrefixProduct(nums);

        // Assert
        Assert.Equal(new[] { 1, 2, 6, 24 }, prefixProducts);
    }

    [Fact]
    public void BuildPrefixProduct_WhenArrayHasZero_ReturnsZeroAfterZeroAppears()
    {
        // Arrange
        int[] nums = { 2, 0, 4 };

        // Act
        int[] prefixProducts = PrefixSums.BuildPrefixProduct(nums);

        // Assert
        Assert.Equal(new[] { 1, 2, 0, 0 }, prefixProducts);
    }

    [Fact]
    public void RangeProduct_WhenRangeHasMultipleValues_ReturnsProduct()
    {
        // Arrange
        int[] nums = { 2, 3, 4, 5 };

        // Act
        int product = PrefixSums.RangeProduct(nums, 1, 3);

        // Assert
        Assert.Equal(60, product);
    }

    [Fact]
    public void RangeProduct_WhenRangeContainsZero_ReturnsZero()
    {
        // Arrange
        int[] nums = { 2, 0, 4 };

        // Act
        int product = PrefixSums.RangeProduct(nums, 0, 2);

        // Assert
        Assert.Equal(0, product);
    }

    [Fact]
    public void RangeProduct_WhenUsingCustomDynamicArray_ReturnsProduct()
    {
        // Arrange
        CustomDynamicArray<int> nums = CreateDynamicArray(2, 3, 4, 5);

        // Act
        int product = PrefixSums.RangeProduct(nums, 1, 3);

        // Assert
        Assert.Equal(60, product);
    }

    [Fact]
    public void RangeProduct_WhenUsingEnumerableSequence_ReturnsProduct()
    {
        // Arrange
        IEnumerable<int> nums = new List<int> { 2, 3, 4, 5 };

        // Act
        int product = PrefixSums.RangeProduct(nums, 1, 3);

        // Assert
        Assert.Equal(60, product);
    }

    [Fact]
    public void RangeProduct_WhenArrayIsNull_ThrowsArgumentNullException()
    {
        // Arrange
        int[] nums = null!;

        // Act
        Action act = () => PrefixSums.RangeProduct(nums, 0, 1);

        // Assert
        Assert.Throws<ArgumentNullException>(act);
    }

    [Fact]
    public void LearningContract_WhenPrefixSumsIsReimplemented_ShouldHandleCommonScenarios()
    {
        // Arrange
        int[] nums = { 3, -2, 5, 1, 6 };

        // Act
        int[] prefixSums = PrefixSums.BuildPrefixSum(nums);
        int wholeSum = PrefixSums.RangeSumFromPrefixSum(prefixSums, 0, 4);
        int middleSum = PrefixSums.RangeSumFromPrefixSum(prefixSums, 1, 3);
        int[] prefixProducts = PrefixSums.BuildPrefixProduct(new[] { 2, 3, 4 });
        int product = PrefixSums.RangeProduct(new[] { 2, 3, 4, 5 }, 1, 3);

        // Assert
        Assert.Equal(new[] { 0, 3, 1, 6, 7, 13 }, prefixSums);
        Assert.Equal(13, wholeSum);
        Assert.Equal(4, middleSum);
        Assert.Equal(new[] { 1, 2, 6, 24 }, prefixProducts);
        Assert.Equal(60, product);
    }

    [Fact]
    public void Timing_BuildPrefixSumForLargeArray_WritesElapsedTime()
    {
        // Arrange
        const int numberOfValues = 100_000;
        int[] nums = new int[numberOfValues];

        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] = 1;
        }

        // Act
        int[] prefixSums = Array.Empty<int>();
        TimeSpan elapsed = Measure(() =>
        {
            prefixSums = PrefixSums.BuildPrefixSum(nums);
        });

        // Assert
        Assert.Equal(numberOfValues + 1, prefixSums.Length);
        Assert.Equal(numberOfValues, prefixSums[^1]);
        _output.WriteLine($"PrefixSums BuildPrefixSum int[{numberOfValues}]: {elapsed.TotalMilliseconds:F3} ms");
    }

    [Fact]
    public void Timing_RangeSumFromPrefixSumForManyQueries_WritesElapsedTime()
    {
        // Arrange
        const int numberOfValues = 100_000;
        const int numberOfQueries = 10_000;
        int[] nums = new int[numberOfValues];

        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] = 1;
        }

        int[] prefixSums = PrefixSums.BuildPrefixSum(nums);

        // Act
        int total = 0;
        TimeSpan elapsed = Measure(() =>
        {
            for (int i = 0; i < numberOfQueries; i++)
            {
                total += PrefixSums.RangeSumFromPrefixSum(prefixSums, i, i + 9);
            }
        });

        // Assert
        Assert.Equal(numberOfQueries * 10, total);
        _output.WriteLine($"PrefixSums {numberOfQueries} range sum queries: {elapsed.TotalMilliseconds:F3} ms");
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
