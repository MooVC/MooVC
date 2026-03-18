namespace MooVC.Syntax.CSharp.Members.PropertyTests.SetterTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

public sealed class WhenEqualityOperatorSetterSetterIsCalled
{
    [Test]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Property.Setter? left = default!;
        Property.Setter? right = default!;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Property.Setter? left = default!;
        var right = new Property.Setter { Behaviour = Snippet.From("value") };

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        var left = new Property.Setter { Behaviour = Snippet.From("value") };
        Property.Setter? right = default!;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        var first = new Property.Setter { Behaviour = Snippet.From("value") };
        Property.Setter second = first;

        // Act
        bool result = first == second;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Property.Setter
        {
            Behaviour = Snippet.From("value"),
            Mode = Property.Mode.Init,
            Scope = Scope.Private,
        };

        var right = new Property.Setter
        {
            Behaviour = Snippet.From("value"),
            Mode = Property.Mode.Init,
            Scope = Scope.Private,
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
        var left = new Property.Setter { Behaviour = Snippet.From("value") };
        var right = new Property.Setter { Behaviour = Snippet.From("alternative") };

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }
}