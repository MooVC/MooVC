namespace MooVC.Syntax.CSharp.Members.IndexerTests.MethodsTests;

using MooVC.Syntax.Elements;

public sealed class WhenInequalityOperatorMethodsMethodsIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Indexer.Methods? left = default;
        Indexer.Methods? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Indexer.Methods? left = default;

        var right = new Indexer.Methods
        {
            Get = "value",
        };

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        var left = new Indexer.Methods
        {
            Get = "value",
        };

        Indexer.Methods? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsFalse()
    {
        // Arrange
        var first = new Indexer.Methods
        {
            Get = "value",
        };

        Indexer.Methods second = first;

        // Act
        bool result = first != second;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Indexer.Methods
        {
            Get = "value",
        };

        var right = new Indexer.Methods
        {
            Get = "value",
        };

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Indexer.Methods
        {
            Get = "value",
        };

        var right = new Indexer.Methods
        {
            Set = "value",
        };

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentGetValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Indexer.Methods
        {
            Get = "value",
        };

        var right = new Indexer.Methods
        {
            Get = "alternative",
        };

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentSetValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Indexer.Methods
        {
            Set = "value",
        };

        var right = new Indexer.Methods
        {
            Set = "alternative",
        };

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }
}