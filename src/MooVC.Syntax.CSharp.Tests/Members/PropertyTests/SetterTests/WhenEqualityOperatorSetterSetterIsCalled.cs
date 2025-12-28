namespace MooVC.Syntax.CSharp.Members.PropertyTests.SetterTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenEqualityOperatorSetterSetterIsCalled
{
    [Fact]
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

    [Fact]
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

    [Fact]
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

    [Fact]
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

    [Fact]
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

    [Fact]
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