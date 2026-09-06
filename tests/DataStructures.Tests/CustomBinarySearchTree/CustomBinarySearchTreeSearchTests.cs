using DataStructures.CustomBinarySearchTree;

namespace DataStructures.Tests.CustomBinarySearchTree;

public class CustomBinarySearchTreeSearchTests
{
    [Fact]
    public void SearchNode_WhenRootIsNull_ReturnsFalse()
    {
        // Arrange
        CustomBinarySearchTreeNode<int>? root = null;

        // Act
        bool result = CustomBinarySearchTreeSearch.SearchNode(root, 10);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void SearchNode_WhenTargetIsRootValue_ReturnsTrue()
    {
        // Arrange
        CustomBinarySearchTreeNode<int> root = CreateTestTree();

        // Act
        bool result = CustomBinarySearchTreeSearch.SearchNode(root, 10);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void SearchNode_WhenTargetExistsOnLeftSide_ReturnsTrue()
    {
        // Arrange
        CustomBinarySearchTreeNode<int> root = CreateTestTree();

        // Act
        bool result = CustomBinarySearchTreeSearch.SearchNode(root, 7);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void SearchNode_WhenTargetExistsOnRightSide_ReturnsTrue()
    {
        // Arrange
        CustomBinarySearchTreeNode<int> root = CreateTestTree();

        // Act
        bool result = CustomBinarySearchTreeSearch.SearchNode(root, 20);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void SearchNode_WhenTargetDoesNotExist_ReturnsFalse()
    {
        // Arrange
        CustomBinarySearchTreeNode<int> root = CreateTestTree();

        // Act
        bool result = CustomBinarySearchTreeSearch.SearchNode(root, 99);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void SearchNode_WhenUsingStrings_ReturnsTrueForExistingValue()
    {
        // Arrange
        CustomBinarySearchTreeNode<string> root =
            new CustomBinarySearchTreeNode<string>(
                "m",
                new CustomBinarySearchTreeNode<string>("c"),
                new CustomBinarySearchTreeNode<string>("t"));

        // Act
        bool result = CustomBinarySearchTreeSearch.SearchNode(root, "t");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void LearningContract_WhenSearchIsReimplemented_ShouldPreserveCoreBehavior()
    {
        // Arrange
        CustomBinarySearchTreeNode<int> root = CreateTestTree();

        // Act
        bool rootResult = CustomBinarySearchTreeSearch.SearchNode(root, 10);
        bool leftResult = CustomBinarySearchTreeSearch.SearchNode(root, 3);
        bool rightResult = CustomBinarySearchTreeSearch.SearchNode(root, 20);
        bool missingResult = CustomBinarySearchTreeSearch.SearchNode(root, 8);

        // Assert
        Assert.True(rootResult);
        Assert.True(leftResult);
        Assert.True(rightResult);
        Assert.False(missingResult);
    }

    private static CustomBinarySearchTreeNode<int> CreateTestTree()
    {
        /*
         * Tree used in tests:
         *
         *         10
         *        /  \
         *       5    15
         *      / \     \
         *     3   7     20
         */

        CustomBinarySearchTreeNode<int> root =
            new CustomBinarySearchTreeNode<int>(
                10,
                new CustomBinarySearchTreeNode<int>(
                    5,
                    new CustomBinarySearchTreeNode<int>(3),
                    new CustomBinarySearchTreeNode<int>(7)),
                new CustomBinarySearchTreeNode<int>(
                    15,
                    null,
                    new CustomBinarySearchTreeNode<int>(20)));

        return root;
    }
}
