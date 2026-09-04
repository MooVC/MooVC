namespace MooVC.Syntax.CSharp.PropertyTests.MethodsTests.SetterTests;

public sealed class WhenEqualityOperatorSetterSetterIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Property.Methods.Setter? left = default!;
        Property.Methods.Setter? right = default!;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Property.Methods.Setter { Behaviour = Snippet.From("value") };
        var right = new Property.Methods.Setter { Behaviour = Snippet.From("alternative") };

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsFalse();
        _ = await Assert.That(resultRightLeft).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Property.Methods.Setter
        {
            Behaviour = Snippet.From("value"),
            Mode = Property.Methods.Setter.Modes.Init,
            Scope = Scopes.Private,
        };

        var right = new Property.Methods.Setter
        {
            Behaviour = Snippet.From("value"),
            Mode = Property.Methods.Setter.Modes.Init,
            Scope = Scopes.Private,
        };

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsTrue();
        _ = await Assert.That(resultRightLeft).IsTrue();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Property.Methods.Setter? left = default!;
        var right = new Property.Methods.Setter { Behaviour = Snippet.From("value") };

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        var left = new Property.Methods.Setter { Behaviour = Snippet.From("value") };
        Property.Methods.Setter? right = default!;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        var first = new Property.Methods.Setter { Behaviour = Snippet.From("value") };
        Property.Methods.Setter second = first;

        // Act
        bool result = first == second;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}