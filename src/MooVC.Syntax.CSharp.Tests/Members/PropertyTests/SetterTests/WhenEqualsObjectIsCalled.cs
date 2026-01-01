namespace MooVC.Syntax.CSharp.Members.PropertyTests.SetterTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

public sealed class WhenEqualsObjectIsCalled
{
    [Fact]
    public void GivenNullThenFalseIsReturned()
    {
        // Arrange
        var subject = new Property.Setter { Behaviour = Snippet.From("value") };
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
        var subject = new Property.Setter { Behaviour = Snippet.From("value") };
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
        var subject = new Property.Setter
        {
            Behaviour = Snippet.From("value"),
            Mode = Property.Mode.Init,
            Scope = Scope.Internal,
        };

        object target = new Property.Setter
        {
            Behaviour = Snippet.From("value"),
            Mode = Property.Mode.Init,
            Scope = Scope.Internal,
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
        var subject = new Property.Setter { Behaviour = Snippet.From("value") };
        object target = new Property.Setter { Behaviour = Snippet.From("alternative") };

        // Act
        bool result = subject.Equals(target);

        // Assert
        result.ShouldBeFalse();
    }
}