namespace MooVC.Syntax.CSharp.Members.IndexerTests.MethodsTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        var subject = new Indexer.Methods
        {
            Get = Snippet.From("value"),
        };

        object? target = default;

        // Act
        bool result = subject.Equals(target);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        var subject = new Indexer.Methods
        {
            Get = Snippet.From("value"),
        };

        object target = subject;

        // Act
        bool result = subject.Equals(target);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEquivalentValueThenReturnsTrue()
    {
        // Arrange
        var subject = new Indexer.Methods
        {
            Get = Snippet.From("value"),
        };

        object target = new Indexer.Methods
        {
            Get = Snippet.From("value"),
        };

        // Act
        bool result = subject.Equals(target);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentTypeThenReturnsFalse()
    {
        // Arrange
        var subject = new Indexer.Methods
        {
            Get = Snippet.From("value"),
        };

        object target = new();

        // Act
        bool result = subject.Equals(target);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentValueThenReturnsFalse()
    {
        // Arrange
        var subject = new Indexer.Methods
        {
            Get = Snippet.From("value"),
        };

        object target = new Indexer.Methods
        {
            Set = Snippet.From("value"),
        };

        // Act
        bool result = subject.Equals(target);

        // Assert
        result.ShouldBeFalse();
    }
}
