using System.Diagnostics;
using DataStructures.Algorithms.Arrays;
using DataStructures.CustomDynamicArrays;
using Xunit.Abstractions;

namespace DataStructures.Tests.Algorithms.Arrays;

public class TwoPointersTests
{
    private readonly ITestOutputHelper _output;

    public TwoPointersTests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void IsPalindrome_WhenStringIsPalindrome_ReturnsTrue()
    {
        // Arrange
        const string word = "racecar";

        // Act
        bool isPalindrome = TwoPointers.IsPalindrome(word);

        // Assert
        Assert.True(isPalindrome);
    }

    [Fact]
    public void IsPalindrome_WhenStringIsNotPalindrome_ReturnsFalse()
    {
        // Arrange
        const string word = "hello";

        // Act
        bool isPalindrome = TwoPointers.IsPalindrome(word);

        // Assert
        Assert.False(isPalindrome);
    }

    [Fact]
    public void IsPalindrome_WhenStringIsEmpty_ReturnsTrue()
    {
        // Arrange
        string word = string.Empty;

        // Act
        bool isPalindrome = TwoPointers.IsPalindrome(word);

        // Assert
        Assert.True(isPalindrome);
    }

    [Fact]
    public void IsPalindrome_WhenStringHasOneCharacter_ReturnsTrue()
    {
        // Arrange
        const string word = "a";

        // Act
        bool isPalindrome = TwoPointers.IsPalindrome(word);

        // Assert
        Assert.True(isPalindrome);
    }

    [Fact]
    public void IsPalindrome_WhenStringUsesDifferentLetterCasing_ReturnsFalse()
    {
        // Arrange
        const string word = "Racecar";

        // Act
        bool isPalindrome = TwoPointers.IsPalindrome(word);

        // Assert
        Assert.False(isPalindrome);
    }

    [Fact]
    public void IsPalindrome_WhenArrayIsPalindrome_ReturnsTrue()
    {
        // Arrange
        int[] nums = { 1, 2, 3, 2, 1 };

        // Act
        bool isPalindrome = TwoPointers.IsPalindrome(nums);

        // Assert
        Assert.True(isPalindrome);
    }

    [Fact]
    public void IsPalindrome_WhenArrayIsNotPalindrome_ReturnsFalse()
    {
        // Arrange
        int[] nums = { 1, 2, 3 };

        // Act
        bool isPalindrome = TwoPointers.IsPalindrome(nums);

        // Assert
        Assert.False(isPalindrome);
    }

    [Fact]
    public void IsPalindrome_WhenArrayIsEmpty_ReturnsTrue()
    {
        // Arrange
        int[] nums = Array.Empty<int>();

        // Act
        bool isPalindrome = TwoPointers.IsPalindrome(nums);

        // Assert
        Assert.True(isPalindrome);
    }

    [Fact]
    public void IsPalindrome_WhenUsingCustomDynamicArray_ReturnsTrue()
    {
        // Arrange
        CustomDynamicArray<int> nums = CreateDynamicArray(1, 2, 3, 2, 1);

        // Act
        bool isPalindrome = TwoPointers.IsPalindrome(nums);

        // Assert
        Assert.True(isPalindrome);
    }

    [Fact]
    public void IsPalindrome_WhenUsingEnumerableSequence_ReturnsTrue()
    {
        // Arrange
        IEnumerable<int> nums = new List<int> { 1, 2, 3, 2, 1 };

        // Act
        bool isPalindrome = TwoPointers.IsPalindrome(nums);

        // Assert
        Assert.True(isPalindrome);
    }

    [Fact]
    public void IsPalindrome_WhenStringIsNull_ThrowsArgumentNullException()
    {
        // Arrange
        string word = null!;

        // Act
        Action act = () => TwoPointers.IsPalindrome(word);

        // Assert
        Assert.Throws<ArgumentNullException>(act);
    }

    [Fact]
    public void IsPalindrome_WhenArrayIsNull_ThrowsArgumentNullException()
    {
        // Arrange
        int[] nums = null!;

        // Act
        Action act = () => TwoPointers.IsPalindrome(nums);

        // Assert
        Assert.Throws<ArgumentNullException>(act);
    }

    [Fact]
    public void TargetSum_WhenSortedArrayHasPair_ReturnsPairIndexes()
    {
        // Arrange
        int[] nums = { 2, 7, 11, 15 };
        const int target = 9;

        // Act
        int[]? indexes = TwoPointers.TargetSum(nums, target);

        // Assert
        Assert.Equal(new[] { 0, 1 }, indexes);
    }

    [Fact]
    public void TargetSum_WhenPointersNeedToMoveBothWays_ReturnsPairIndexes()
    {
        // Arrange
        int[] nums = { 1, 3, 4, 5, 7, 11 };
        const int target = 10;

        // Act
        int[]? indexes = TwoPointers.TargetSum(nums, target);

        // Assert
        Assert.Equal(new[] { 1, 4 }, indexes);
    }

    [Fact]
    public void TargetSum_WhenNoPairExists_ReturnsNull()
    {
        // Arrange
        int[] nums = { 1, 2, 3, 4 };
        const int target = 20;

        // Act
        int[]? indexes = TwoPointers.TargetSum(nums, target);

        // Assert
        Assert.Null(indexes);
    }

    [Fact]
    public void TargetSum_WhenArrayIsEmpty_ReturnsNull()
    {
        // Arrange
        int[] nums = Array.Empty<int>();
        const int target = 10;

        // Act
        int[]? indexes = TwoPointers.TargetSum(nums, target);

        // Assert
        Assert.Null(indexes);
    }

    [Fact]
    public void TargetSum_WhenUsingCustomDynamicArray_ReturnsPairIndexes()
    {
        // Arrange
        CustomDynamicArray<int> nums = CreateDynamicArray(2, 7, 11, 15);
        const int target = 9;

        // Act
        int[]? indexes = TwoPointers.TargetSum(nums, target);

        // Assert
        Assert.Equal(new[] { 0, 1 }, indexes);
    }

    [Fact]
    public void TargetSum_WhenUsingEnumerableSequence_ReturnsPairIndexes()
    {
        // Arrange
        IEnumerable<int> nums = new List<int> { 2, 7, 11, 15 };
        const int target = 9;

        // Act
        int[]? indexes = TwoPointers.TargetSum(nums, target);

        // Assert
        Assert.Equal(new[] { 0, 1 }, indexes);
    }

    [Fact]
    public void TargetSum_WhenArrayIsNull_ThrowsArgumentNullException()
    {
        // Arrange
        int[] nums = null!;
        const int target = 9;

        // Act
        Action act = () => TwoPointers.TargetSum(nums, target);

        // Assert
        Assert.Throws<ArgumentNullException>(act);
    }

    [Fact]
    public void LearningContract_WhenTwoPointersIsReimplemented_ShouldHandleCommonScenarios()
    {
        // Arrange
        string palindromeWord = "racecar";
        string notPalindromeWord = "learning";
        int[] palindromeArray = { 1, 2, 3, 2, 1 };
        int[] sortedNums = { 1, 2, 4, 6, 8, 11 };

        // Act
        bool wordResult = TwoPointers.IsPalindrome(palindromeWord);
        bool notPalindromeResult = TwoPointers.IsPalindrome(notPalindromeWord);
        bool arrayResult = TwoPointers.IsPalindrome(palindromeArray);
        int[]? targetSumResult = TwoPointers.TargetSum(sortedNums, 10);
        int[]? noTargetSumResult = TwoPointers.TargetSum(sortedNums, 100);

        // Assert
        Assert.True(wordResult);
        Assert.False(notPalindromeResult);
        Assert.True(arrayResult);
        Assert.Equal(new[] { 1, 4 }, targetSumResult);
        Assert.Null(noTargetSumResult);
    }

    [Fact]
    public void Timing_IsPalindromeForLargeArray_WritesElapsedTime()
    {
        // Arrange
        const int numberOfValues = 100_000;
        int[] nums = new int[numberOfValues];

        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] = i < nums.Length / 2 ? i : nums.Length - i - 1;
        }

        // Act
        bool isPalindrome = false;
        TimeSpan elapsed = Measure(() =>
        {
            isPalindrome = TwoPointers.IsPalindrome(nums);
        });

        // Assert
        Assert.True(isPalindrome);
        _output.WriteLine($"TwoPointers IsPalindrome int[{numberOfValues}]: {elapsed.TotalMilliseconds:F3} ms");
    }

    [Fact]
    public void Timing_TargetSumForLargeSortedArray_WritesElapsedTime()
    {
        // Arrange
        const int numberOfValues = 100_000;
        int[] nums = new int[numberOfValues];

        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] = i + 1;
        }

        int target = nums[^2] + nums[^1];

        // Act
        int[]? indexes = null;
        TimeSpan elapsed = Measure(() =>
        {
            indexes = TwoPointers.TargetSum(nums, target);
        });

        // Assert
        Assert.Equal(new[] { numberOfValues - 2, numberOfValues - 1 }, indexes);
        _output.WriteLine($"TwoPointers TargetSum int[{numberOfValues}]: {elapsed.TotalMilliseconds:F3} ms");
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
