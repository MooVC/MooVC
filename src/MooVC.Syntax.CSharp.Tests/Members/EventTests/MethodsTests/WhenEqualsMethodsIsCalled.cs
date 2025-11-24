namespace MooVC.Syntax.CSharp.Members.EventTests.MethodsTests;

public sealed class WhenEqualsMethodsIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Event.Methods? subject = default;

        var target = new Event.Methods
        {
            Add = Snippet.From("value"),
        };

        // Act
        bool result = target.Equals(subject);

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

        Event.Methods target = subject;

        // Act
        bool result = target.Equals(subject);

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

        var target = new Event.Methods
        {
            Add = Snippet.From("value"),
        };

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValueThenReturnsFalse()
    {
        // Arrange
        var subject = new Event.Methods
        {
            Add = Snippet.From("value"),
        };

        var target = new Event.Methods
        {
            Remove = Snippet.From("value"),
        };

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeFalse();
    }
}