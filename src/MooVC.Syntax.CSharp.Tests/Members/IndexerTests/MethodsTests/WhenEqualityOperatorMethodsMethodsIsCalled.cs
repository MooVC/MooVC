namespace MooVC.Syntax.CSharp.Members.IndexerTests.MethodsTests;

using MooVC.Syntax.Elements;

public sealed class WhenEqualityOperatorMethodsMethodsIsCalled
{
    [Test]
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

    [Test]
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Indexer.Methods? left = default;
        var right = new Indexer.Methods
        {
            Get = Snippet.From("value"),
        };

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        var left = new Indexer.Methods
        {
            Get = Snippet.From("value"),
        };

        Indexer.Methods? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        var first = new Indexer.Methods
        {
            Get = Snippet.From("value"),
        };

        Indexer.Methods second = first;

        // Act
        bool result = first == second;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Indexer.Methods
        {
            Get = Snippet.From("value"),
        };

        var right = new Indexer.Methods
        {
            Get = Snippet.From("value"),
        };

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Indexer.Methods
        {
            Get = Snippet.From("value"),
        };

        var right = new Indexer.Methods
        {
            Set = Snippet.From("value"),
        };

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }

    [Test]
    public void GivenDifferentGetValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Indexer.Methods
        {
            Get = Snippet.From("value"),
        };

        var right = new Indexer.Methods
        {
            Get = Snippet.From("alternative"),
        };

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }

    [Test]
    public void GivenDifferentSetValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Indexer.Methods
        {
            Set = Snippet.From("value"),
        };

        var right = new Indexer.Methods
        {
            Set = Snippet.From("alternative"),
        };

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }
}