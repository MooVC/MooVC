namespace MooVC.Syntax.CSharp.Members.IndexerTests.MethodsTests;

using MooVC.Syntax.Elements;

public sealed class WhenEqualityOperatorMethodsMethodsIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Indexer.Methods? left = default;
        Indexer.Methods? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Indexer.Methods? left = default;
        var right = new Indexer.Methods
        {
            Get = "value",
        };

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        var left = new Indexer.Methods
        {
            Get = "value",
        };

        Indexer.Methods? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        var first = new Indexer.Methods
        {
            Get = "value",
        };

        Indexer.Methods second = first;

        // Act
        bool result = first == second;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
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
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
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
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentGetValuesThenReturnsFalse()
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
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentSetValuesThenReturnsFalse()
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
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }
}