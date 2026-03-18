namespace MooVC.Syntax.CSharp.Members.IndexerTests.MethodsTests;

using MooVC.Syntax.Elements;

public sealed class WhenInequalityOperatorMethodsMethodsIsCalled
{
    [Test]
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

    [Test]
    public void GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Indexer.Methods? left = default;

        var right = new Indexer.Methods
        {
            Get = Snippet.From("value"),
        };

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        var left = new Indexer.Methods
        {
            Get = Snippet.From("value"),
        };

        Indexer.Methods? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenSameReferenceThenReturnsFalse()
    {
        // Arrange
        var first = new Indexer.Methods
        {
            Get = Snippet.From("value"),
        };

        Indexer.Methods second = first;

        // Act
        bool result = first != second;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenEqualValuesThenReturnsFalse()
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
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsTrue()
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
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentGetValuesThenReturnsTrue()
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
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentSetValuesThenReturnsTrue()
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
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }
}