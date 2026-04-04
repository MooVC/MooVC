namespace MooVC.Syntax.CSharp.PropertyTests.MethodsTests.SetterTests;

public sealed class WhenInequalityOperatorSetterSetterIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Property.Methods.Setter? left = default!;
        Property.Methods.Setter? right = default!;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Property.Methods.Setter { Behaviour = Snippet.From("value") };
        var right = new Property.Methods.Setter { Behaviour = Snippet.From("alternative") };

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsTrue();
        _ = await Assert.That(resultRightLeft).IsTrue();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Property.Methods.Setter
        {
            Behaviour = Snippet.From("value"),
            Mode = Property.Methods.Setter.Modes.Init,
            Scope = Scope.Private,
        };

        var right = new Property.Methods.Setter
        {
            Behaviour = Snippet.From("value"),
            Mode = Property.Methods.Setter.Modes.Init,
            Scope = Scope.Private,
        };

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsFalse();
        _ = await Assert.That(resultRightLeft).IsFalse();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Property.Methods.Setter? left = default!;
        var right = new Property.Methods.Setter { Behaviour = Snippet.From("value") };

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        var left = new Property.Methods.Setter { Behaviour = Snippet.From("value") };
        Property.Methods.Setter? right = default!;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsFalse()
    {
        // Arrange
        var first = new Property.Methods.Setter { Behaviour = Snippet.From("value") };
        Property.Methods.Setter second = first;

        // Act
        bool result = first != second;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}