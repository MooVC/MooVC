namespace MooVC.Syntax.CSharp.Members.PropertyTests.MethodsTests;

using MooVC.Syntax.Elements;

public sealed class WhenEqualsObjectIsCalled
{
    [Fact]
    public void GivenNullThenFalseIsReturned()
    {
        // Arrange
        var subject = new Property.Methods
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
    public void GivenSameReferenceThenTrueIsReturned()
    {
        // Arrange
        var subject = new Property.Methods
        {
            Get = Snippet.From("value"),
            Set = new Property.Setter { Behaviour = Snippet.From("value = input") },
        };

        object target = subject;

        // Act
        bool result = subject.Equals(target);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEquivalentInstanceThenTrueIsReturned()
    {
        // Arrange
        var subject = new Property.Methods
        {
            Get = Snippet.From("value"),
            Set = new Property.Setter { Behaviour = Snippet.From("value = input") },
        };

        object target = new Property.Methods
        {
            Get = Snippet.From("value"),
            Set = new Property.Setter { Behaviour = Snippet.From("value = input") },
        };

        // Act
        bool result = subject.Equals(target);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentTypeThenFalseIsReturned()
    {
        // Arrange
        var subject = new Property.Methods
        {
            Get = Snippet.From("value"),
        };

        object target = new Property.Methods
        {
            Get = Snippet.From("alternative"),
        };

        // Act
        bool result = subject.Equals(target);

        // Assert
        result.ShouldBeFalse();
    }
}