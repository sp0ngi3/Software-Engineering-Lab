using System.Reflection;
using DataStructures.CustomDynamicArray;

namespace DataStructures.Tests.CustomDynamicArray;

public class CustomDynamicArrayTests
{
    [Fact]
    public void Constructor_WhenArrayIsCreated_SetsInitialSizeToZero()
    {
        // Arrange & Act
        CustomDynamicArray<int> array = new CustomDynamicArray<int>();

        // Assert
        Assert.Equal(0, array.Count);
        Assert.Equal(0, GetPrivateInt(array, "_size"));
    }

    [Fact]
    public void Constructor_WhenArrayIsCreated_SetsInitialCapacityToEight()
    {
        // Arrange & Act
        CustomDynamicArray<int> array = new CustomDynamicArray<int>();

        // Assert
        Assert.Equal(8, array.Capacity);
        Assert.Equal(8, GetPrivateInt(array, "_capacity"));
    }

    [Fact]
    public void Constructor_WhenArrayIsCreated_CreatesInternalArrayWithInitialCapacity()
    {
        // Arrange & Act
        CustomDynamicArray<int> array = new CustomDynamicArray<int>();

        // Assert
        int[] internalArray = GetPrivateArray(array);
        Assert.Equal(8, internalArray.Length);
    }

    [Fact]
    public void Add_WhenValueIsAdded_StoresValueAtNextFreeIndex()
    {
        // Arrange
        CustomDynamicArray<int> array = new CustomDynamicArray<int>();

        // Act
        array.Add(10);

        // Assert
        Assert.Equal(10, array.Get(0));
        Assert.Equal(1, array.Count);
        Assert.Equal(1, GetPrivateInt(array, "_size"));
    }

    [Fact]
    public void Add_WhenMultipleValuesAreAdded_PreservesInsertionOrder()
    {
        // Arrange
        CustomDynamicArray<int> array = new CustomDynamicArray<int>();

        // Act
        array.Add(10);
        array.Add(20);
        array.Add(30);

        // Assert
        Assert.Equal(10, array.Get(0));
        Assert.Equal(20, array.Get(1));
        Assert.Equal(30, array.Get(2));
        Assert.Equal(3, array.Count);
        Assert.Equal(3, GetPrivateInt(array, "_size"));
    }

    [Fact]
    public void Add_WhenCapacityIsFull_ResizesInternalArray()
    {
        // Arrange
        CustomDynamicArray<int> array = new CustomDynamicArray<int>();

        // Act
        for (int value = 1; value <= 9; value++)
        {
            array.Add(value);
        }

        // Assert
        Assert.Equal(9, array.Count);
        Assert.Equal(16, array.Capacity);
        Assert.Equal(9, GetPrivateInt(array, "_size"));
        Assert.Equal(16, GetPrivateInt(array, "_capacity"));
        Assert.Equal(16, GetPrivateArray(array).Length);
    }

    [Fact]
    public void Add_WhenCapacityIsFull_PreservesExistingValuesAfterResize()
    {
        // Arrange
        CustomDynamicArray<int> array = new CustomDynamicArray<int>();

        // Act
        for (int value = 1; value <= 9; value++)
        {
            array.Add(value);
        }

        // Assert
        for (int index = 0; index < 9; index++)
        {
            Assert.Equal(index + 1, array.Get(index));
        }
    }

    [Fact]
    public void Get_WhenIndexIsValid_ReturnsValueAtIndex()
    {
        // Arrange
        CustomDynamicArray<int> array = CreateArray(10, 20, 30);

        // Act
        int value = array.Get(1);

        // Assert
        Assert.Equal(20, value);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public void Get_WhenArrayIsEmpty_ThrowsIndexOutOfRangeException(int index)
    {
        // Arrange
        CustomDynamicArray<int> array = new CustomDynamicArray<int>();

        // Act
        Action act = () => array.Get(index);

        // Assert
        Assert.Throws<IndexOutOfRangeException>(act);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(3)]
    public void Get_WhenIndexIsOutOfRange_ThrowsIndexOutOfRangeException(int index)
    {
        // Arrange
        CustomDynamicArray<int> array = CreateArray(10, 20, 30);

        // Act
        Action act = () => array.Get(index);

        // Assert
        Assert.Throws<IndexOutOfRangeException>(act);
    }

    [Fact]
    public void Insert_WhenIndexIsValid_ReplacesValueAtIndex()
    {
        // Arrange
        CustomDynamicArray<int> array = CreateArray(10, 20, 30);

        // Act
        array.Insert(99, 1);

        // Assert
        Assert.Equal(10, array.Get(0));
        Assert.Equal(99, array.Get(1));
        Assert.Equal(30, array.Get(2));
        Assert.Equal(3, GetPrivateInt(array, "_size"));
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(3)]
    public void Insert_WhenIndexIsOutOfRange_ThrowsIndexOutOfRangeException(int index)
    {
        // Arrange
        CustomDynamicArray<int> array = CreateArray(10, 20, 30);

        // Act
        Action act = () => array.Insert(99, index);

        // Assert
        Assert.Throws<IndexOutOfRangeException>(act);
    }

    [Fact]
    public void Methods_WhenUsingStrings_WorkWithGenericValues()
    {
        // Arrange
        CustomDynamicArray<string> array = new CustomDynamicArray<string>();

        // Act
        array.Add("first");
        array.Add("second");
        array.Insert("updated", 1);

        // Assert
        Assert.Equal("first", array.Get(0));
        Assert.Equal("updated", array.Get(1));
        Assert.Equal(2, array.Count);
        Assert.Equal(2, GetPrivateInt(array, "_size"));
    }

    [Fact]
    public void RemoveAt_WhenRemovingFirstValue_ShiftsValuesToLeft()
    {
        // Arrange
        CustomDynamicArray<int> array = CreateArray(10, 20, 30);

        // Act
        array.RemoveAt(0);

        // Assert
        Assert.Equal(2, array.Count);
        Assert.Equal(20, array.Get(0));
        Assert.Equal(30, array.Get(1));
    }

    [Fact]
    public void RemoveAt_WhenRemovingMiddleValue_ShiftsValuesToLeft()
    {
        // Arrange
        CustomDynamicArray<int> array = CreateArray(10, 20, 30, 40);

        // Act
        array.RemoveAt(1);

        // Assert
        Assert.Equal(3, array.Count);
        Assert.Equal(10, array.Get(0));
        Assert.Equal(30, array.Get(1));
        Assert.Equal(40, array.Get(2));
    }

    [Fact]
    public void RemoveAt_WhenRemovingLastValue_DecreasesCount()
    {
        // Arrange
        CustomDynamicArray<int> array = CreateArray(10, 20, 30);

        // Act
        array.RemoveAt(2);

        // Assert
        Assert.Equal(2, array.Count);
        Assert.Equal(10, array.Get(0));
        Assert.Equal(20, array.Get(1));
        Assert.Throws<IndexOutOfRangeException>(() => array.Get(2));
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(3)]
    public void RemoveAt_WhenIndexIsOutOfRange_ThrowsIndexOutOfRangeException(int index)
    {
        // Arrange
        CustomDynamicArray<int> array = CreateArray(10, 20, 30);

        // Act
        Action act = () => array.RemoveAt(index);

        // Assert
        Assert.Throws<IndexOutOfRangeException>(act);
    }

    [Fact]
    public void RemoveLast_WhenArrayHasValues_RemovesLastValue()
    {
        // Arrange
        CustomDynamicArray<int> array = CreateArray(10, 20, 30);

        // Act
        array.RemoveLast();

        // Assert
        Assert.Equal(2, array.Count);
        Assert.Equal(10, array.Get(0));
        Assert.Equal(20, array.Get(1));
        Assert.Throws<IndexOutOfRangeException>(() => array.Get(2));
    }

    [Fact]
    public void RemoveLast_WhenArrayIsEmpty_ThrowsInvalidOperationException()
    {
        // Arrange
        CustomDynamicArray<int> array = new CustomDynamicArray<int>();

        // Act
        Action act = () => array.RemoveLast();

        // Assert
        Assert.Throws<InvalidOperationException>(act);
    }

    [Fact]
    public void RemoveLast_WhenSizeDropsToQuarterCapacity_ShrinksInternalArray()
    {
        // Arrange
        CustomDynamicArray<int> array = new CustomDynamicArray<int>();

        for (int value = 1; value <= 17; value++)
        {
            array.Add(value);
        }

        // Act
        while (array.Count > 8)
        {
            array.RemoveLast();
        }

        // Assert
        Assert.Equal(8, array.Count);
        Assert.Equal(16, array.Capacity);
        Assert.Equal(16, GetPrivateArray(array).Length);
    }

    [Fact]
    public void RemoveLast_WhenManyValuesAreRemoved_DoesNotShrinkBelowInitialCapacity()
    {
        // Arrange
        CustomDynamicArray<int> array = new CustomDynamicArray<int>();

        for (int value = 1; value <= 17; value++)
        {
            array.Add(value);
        }

        // Act
        while (array.Count > 0)
        {
            array.RemoveLast();
        }

        // Assert
        Assert.Equal(0, array.Count);
        Assert.Equal(8, array.Capacity);
        Assert.Equal(8, GetPrivateArray(array).Length);
    }

    [Fact]
    public void RemoveAt_WhenManyValuesAreRemoved_PreservesRemainingValuesAfterShrinking()
    {
        // Arrange
        CustomDynamicArray<int> array = new CustomDynamicArray<int>();

        for (int value = 1; value <= 17; value++)
        {
            array.Add(value);
        }

        // Act
        while (array.Count > 3)
        {
            array.RemoveAt(0);
        }

        // Assert
        Assert.Equal(3, array.Count);
        Assert.Equal(8, array.Capacity);
        Assert.Equal(15, array.Get(0));
        Assert.Equal(16, array.Get(1));
        Assert.Equal(17, array.Get(2));
    }

    private static CustomDynamicArray<T> CreateArray<T>(params T[] values)
    {
        CustomDynamicArray<T> array = new CustomDynamicArray<T>();

        foreach (T value in values)
        {
            array.Add(value);
        }

        return array;
    }

    private static int GetPrivateInt<T>(
        CustomDynamicArray<T> array,
        string fieldName)
    {
        FieldInfo? field = typeof(CustomDynamicArray<T>).GetField(
            fieldName,
            BindingFlags.Instance | BindingFlags.NonPublic);

        return (int)field!.GetValue(array)!;
    }

    private static T[] GetPrivateArray<T>(CustomDynamicArray<T> array)
    {
        FieldInfo? field = typeof(CustomDynamicArray<T>).GetField(
            "_arr",
            BindingFlags.Instance | BindingFlags.NonPublic);

        return (T[])field!.GetValue(array)!;
    }
}
