using DataStructures.CustomBinarySearchTree;

namespace DataStructures.Tests.CustomBinarySearchTree;

public class CustomBinarySearchTreeOperationsTests
{
    [Fact]
    public void Insert_WhenRootIsNull_CreatesNewRootNode()
    {
        // Arrange
        CustomBinarySearchTreeNode<int>? root = null;

        // Act
        root = CustomBinarySearchTreeOperations.Insert(root, 10);

        // Assert
        Assert.NotNull(root);
        Assert.Equal(10, root.Value);
        Assert.Null(root.Left);
        Assert.Null(root.Right);
    }

    [Fact]
    public void Insert_WhenValueIsSmallerThanRoot_AddsValueToLeftSide()
    {
        // Arrange
        CustomBinarySearchTreeNode<int>? root = new CustomBinarySearchTreeNode<int>(10);

        // Act
        root = CustomBinarySearchTreeOperations.Insert(root, 5);

        // Assert
        Assert.NotNull(root.Left);
        Assert.Equal(5, root.Left.Value);
    }

    [Fact]
    public void Insert_WhenValueIsGreaterThanRoot_AddsValueToRightSide()
    {
        // Arrange
        CustomBinarySearchTreeNode<int>? root = new CustomBinarySearchTreeNode<int>(10);

        // Act
        root = CustomBinarySearchTreeOperations.Insert(root, 15);

        // Assert
        Assert.NotNull(root.Right);
        Assert.Equal(15, root.Right.Value);
    }

    [Fact]
    public void Insert_WhenMultipleValuesAreInserted_CreatesValidSearchableTree()
    {
        // Arrange
        CustomBinarySearchTreeNode<int>? root = null;
        int[] values = { 10, 5, 15, 3, 7, 20 };

        // Act
        foreach (int value in values)
        {
            root = CustomBinarySearchTreeOperations.Insert(root, value);
        }

        // Assert
        Assert.True(CustomBinarySearchTreeSearch.SearchNode(root, 10));
        Assert.True(CustomBinarySearchTreeSearch.SearchNode(root, 3));
        Assert.True(CustomBinarySearchTreeSearch.SearchNode(root, 20));
        Assert.False(CustomBinarySearchTreeSearch.SearchNode(root, 99));
    }

    [Fact]
    public void Insert_WhenValueAlreadyExists_DoesNotInsertDuplicateValue()
    {
        // Arrange
        CustomBinarySearchTreeNode<int>? root = null;
        root = CustomBinarySearchTreeOperations.Insert(root, 10);
        root = CustomBinarySearchTreeOperations.Insert(root, 5);
        root = CustomBinarySearchTreeOperations.Insert(root, 15);

        // Act
        root = CustomBinarySearchTreeOperations.Insert(root, 10);

        // Assert
        Assert.Equal(10, root.Value);
        Assert.Equal(5, root.Left!.Value);
        Assert.Equal(15, root.Right!.Value);
    }

    [Fact]
    public void MinValueNode_WhenTreeHasValues_ReturnsMostLeftNode()
    {
        // Arrange
        CustomBinarySearchTreeNode<int>? root = CreateTestTree();

        // Act
        CustomBinarySearchTreeNode<int>? minNode = CustomBinarySearchTreeOperations.MinValueNode(root);

        // Assert
        Assert.NotNull(minNode);
        Assert.Equal(3, minNode.Value);
    }

    [Fact]
    public void MinValueNode_WhenRootIsNull_ReturnsNull()
    {
        // Arrange
        CustomBinarySearchTreeNode<int>? root = null;

        // Act
        CustomBinarySearchTreeNode<int>? minNode = CustomBinarySearchTreeOperations.MinValueNode(root);

        // Assert
        Assert.Null(minNode);
    }

    [Fact]
    public void Remove_WhenRootIsNull_ReturnsNull()
    {
        // Arrange
        CustomBinarySearchTreeNode<int>? root = null;

        // Act
        root = CustomBinarySearchTreeOperations.Remove(root, 10);

        // Assert
        Assert.Null(root);
    }

    [Fact]
    public void Remove_WhenTargetIsLeafNode_RemovesValueFromTree()
    {
        // Arrange
        CustomBinarySearchTreeNode<int>? root = CreateTestTree();

        // Act
        root = CustomBinarySearchTreeOperations.Remove(root, 3);

        // Assert
        Assert.False(CustomBinarySearchTreeSearch.SearchNode(root, 3));
        Assert.True(CustomBinarySearchTreeSearch.SearchNode(root, 5));
        Assert.Null(root!.Left!.Left);
    }

    [Fact]
    public void Remove_WhenTargetHasOneChild_ReplacesNodeWithChild()
    {
        // Arrange
        CustomBinarySearchTreeNode<int>? root = CreateTestTree();

        // Act
        root = CustomBinarySearchTreeOperations.Remove(root, 15);

        // Assert
        Assert.False(CustomBinarySearchTreeSearch.SearchNode(root, 15));
        Assert.True(CustomBinarySearchTreeSearch.SearchNode(root, 20));
        Assert.Equal(20, root!.Right!.Value);
    }

    [Fact]
    public void Remove_WhenTargetHasTwoChildren_ReplacesNodeWithMinimumValueFromRightSubtree()
    {
        // Arrange
        CustomBinarySearchTreeNode<int>? root = CreateTestTree();

        // Act
        root = CustomBinarySearchTreeOperations.Remove(root, 10);

        // Assert
        Assert.NotNull(root);
        Assert.Equal(15, root.Value);
        Assert.False(CustomBinarySearchTreeSearch.SearchNode(root, 10));
        Assert.True(CustomBinarySearchTreeSearch.SearchNode(root, 3));
        Assert.True(CustomBinarySearchTreeSearch.SearchNode(root, 20));
    }

    [Fact]
    public void Remove_WhenTargetDoesNotExist_KeepsTreeSearchable()
    {
        // Arrange
        CustomBinarySearchTreeNode<int>? root = CreateTestTree();

        // Act
        root = CustomBinarySearchTreeOperations.Remove(root, 99);

        // Assert
        Assert.True(CustomBinarySearchTreeSearch.SearchNode(root, 10));
        Assert.True(CustomBinarySearchTreeSearch.SearchNode(root, 3));
        Assert.True(CustomBinarySearchTreeSearch.SearchNode(root, 20));
        Assert.False(CustomBinarySearchTreeSearch.SearchNode(root, 99));
    }

    [Fact]
    public void Remove_WhenOnlyRootExists_RemovesRootAndReturnsNull()
    {
        // Arrange
        CustomBinarySearchTreeNode<int>? root = new CustomBinarySearchTreeNode<int>(10);

        // Act
        root = CustomBinarySearchTreeOperations.Remove(root, 10);

        // Assert
        Assert.Null(root);
    }

    [Fact]
    public void LearningContract_WhenInsertAndRemoveAreReimplemented_ShouldPreserveCoreBehavior()
    {
        // Arrange
        CustomBinarySearchTreeNode<int>? root = null;
        int[] values = { 10, 5, 15, 3, 7, 20 };

        // Act
        foreach (int value in values)
        {
            root = CustomBinarySearchTreeOperations.Insert(root, value);
        }

        bool foundBeforeRemove = CustomBinarySearchTreeSearch.SearchNode(root, 7);
        root = CustomBinarySearchTreeOperations.Remove(root, 7);
        bool foundAfterRemove = CustomBinarySearchTreeSearch.SearchNode(root, 7);
        root = CustomBinarySearchTreeOperations.Remove(root, 10);

        // Assert
        Assert.True(foundBeforeRemove);
        Assert.False(foundAfterRemove);
        Assert.NotNull(root);
        Assert.Equal(15, root.Value);
        Assert.True(CustomBinarySearchTreeSearch.SearchNode(root, 20));
    }

    [Fact]
    public void ToPrettyString_WhenTreeHasValues_ReturnsReadableTreeShape()
    {
        // Arrange
        CustomBinarySearchTreeNode<int>? root = CreateTestTree();
        string expected =
            "Root: 10" + Environment.NewLine +
            "|-- L: 5" + Environment.NewLine +
            "|   |-- L: 3" + Environment.NewLine +
            "|   `-- R: 7" + Environment.NewLine +
            "`-- R: 15" + Environment.NewLine +
            "    `-- R: 20" + Environment.NewLine;

        // Act
        string prettyTree = CustomBinarySearchTreeOperations.ToPrettyString(root);

        // Assert
        Assert.Equal(expected, prettyTree);
    }

    [Fact]
    public void ToPrettyString_WhenTreeIsEmpty_ReturnsEmptyTreeText()
    {
        // Arrange
        CustomBinarySearchTreeNode<int>? root = null;

        // Act
        string prettyTree = CustomBinarySearchTreeOperations.ToPrettyString(root);

        // Assert
        Assert.Equal("<empty tree>" + Environment.NewLine, prettyTree);
    }

    [Fact]
    public void Print_WhenTreeHasValues_WritesReadableTreeShapeToConsole()
    {
        // Arrange
        CustomBinarySearchTreeNode<int>? root = CreateTestTree();
        StringWriter writer = new StringWriter();
        TextWriter originalOutput = Console.Out;

        try
        {
            Console.SetOut(writer);

            // Act
            CustomBinarySearchTreeOperations.Print(root);
        }
        finally
        {
            Console.SetOut(originalOutput);
        }

        // Assert
        Assert.Contains("Root: 10", writer.ToString());
        Assert.Contains("|-- L: 5", writer.ToString());
        Assert.Contains("`-- R: 15", writer.ToString());
    }

    private static CustomBinarySearchTreeNode<int> CreateTestTree()
    {
        CustomBinarySearchTreeNode<int>? root = null;
        int[] values = { 10, 5, 15, 3, 7, 20 };

        foreach (int value in values)
        {
            root = CustomBinarySearchTreeOperations.Insert(root, value);
        }

        return root!;
    }
}
