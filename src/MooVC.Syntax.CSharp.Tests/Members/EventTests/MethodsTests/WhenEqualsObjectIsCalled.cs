namespace MooVC.Syntax.CSharp.Members.EventTests.MethodsTests;

using MooVC.Syntax.Elements;

public sealed class WhenEqualsObjectIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        var subject = new Event.Methods
        {
            Add = Snippet.From("value"),
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
        var subject = new Event.Methods
        {
            Add = Snippet.From("value"),
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
        var subject = new Event.Methods
        {
            Add = Snippet.From("value"),
        };

        object target = new Event.Methods
        {
            Add = Snippet.From("value"),
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
        var subject = new Event.Methods
        {
            Add = Snippet.From("value"),
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
        var subject = new Event.Methods
        {
            Add = Snippet.From("value"),
        };

        object target = new Event.Methods
        {
            Add = Snippet.From("alternative"),
        };

        // Act
        bool result = subject.Equals(target);

        // Assert
        result.ShouldBeFalse();
    }
}