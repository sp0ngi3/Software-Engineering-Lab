using DataStructures.CustomBinarySearchTree;

namespace DataStructures.Tests.CustomBinarySearchTree;

public class CustomBinarySearchTreeNodeTests
{
    [Fact]
    public void Constructor_WhenOnlyValueIsProvided_CreatesNodeWithoutChildren()
    {
        // Arrange & Act
        CustomBinarySearchTreeNode<int> node = new CustomBinarySearchTreeNode<int>(10);

        // Assert
        Assert.Equal(10, node.Value);
        Assert.Null(node.Left);
        Assert.Null(node.Right);
    }

    [Fact]
    public void Constructor_WhenChildrenAreProvided_CreatesNodeWithLeftAndRightChildren()
    {
        // Arrange
        CustomBinarySearchTreeNode<int> left = new CustomBinarySearchTreeNode<int>(5);
        CustomBinarySearchTreeNode<int> right = new CustomBinarySearchTreeNode<int>(15);

        // Act
        CustomBinarySearchTreeNode<int> root = new CustomBinarySearchTreeNode<int>(10, left, right);

        // Assert
        Assert.Equal(10, root.Value);
        Assert.Same(left, root.Left);
        Assert.Same(right, root.Right);
    }

    [Fact]
    public void Properties_WhenChildrenAreAssignedAfterConstructor_StoresChildReferences()
    {
        // Arrange
        CustomBinarySearchTreeNode<int> root = new CustomBinarySearchTreeNode<int>(10);
        CustomBinarySearchTreeNode<int> left = new CustomBinarySearchTreeNode<int>(5);
        CustomBinarySearchTreeNode<int> right = new CustomBinarySearchTreeNode<int>(15);

        // Act
        root.Left = left;
        root.Right = right;

        // Assert
        Assert.Same(left, root.Left);
        Assert.Same(right, root.Right);
    }
}
