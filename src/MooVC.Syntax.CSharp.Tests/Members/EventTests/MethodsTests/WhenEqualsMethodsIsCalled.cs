namespace MooVC.Syntax.CSharp.Members.EventTests.MethodsTests;

using MooVC.Syntax.Elements;

public sealed class WhenEqualsMethodsIsCalled
{
    [Test]
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

    [Test]
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

    [Test]
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

    [Test]
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

    [Test]
    public void GivenDifferentAddValuesThenReturnsFalse()
    {
        // Arrange
        var subject = new Event.Methods
        {
            Add = Snippet.From("value"),
        };

        var target = new Event.Methods
        {
            Add = Snippet.From("alternative"),
        };

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenDifferentRemoveValuesThenReturnsFalse()
    {
        // Arrange
        var subject = new Event.Methods
        {
            Remove = Snippet.From("value"),
        };

        var target = new Event.Methods
        {
            Remove = Snippet.From("alternative"),
        };

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeFalse();
    }
}