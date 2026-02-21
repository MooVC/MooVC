namespace MooVC.Syntax.CSharp.Members.EventTests.MethodsTests;

using MooVC.Syntax.Elements;

public sealed class WhenEqualsMethodsIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Event.Methods? subject = default;

        var target = new Event.Methods
        {
            Add = "value",
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
            Add = "value",
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
            Add = "value",
        };

        var target = new Event.Methods
        {
            Add = "value",
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
            Add = "value",
        };

        var target = new Event.Methods
        {
            Remove = "value",
        };

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentAddValuesThenReturnsFalse()
    {
        // Arrange
        var subject = new Event.Methods
        {
            Add = "value",
        };

        var target = new Event.Methods
        {
            Add = "alternative",
        };

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentRemoveValuesThenReturnsFalse()
    {
        // Arrange
        var subject = new Event.Methods
        {
            Remove = "value",
        };

        var target = new Event.Methods
        {
            Remove = "alternative",
        };

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeFalse();
    }
}