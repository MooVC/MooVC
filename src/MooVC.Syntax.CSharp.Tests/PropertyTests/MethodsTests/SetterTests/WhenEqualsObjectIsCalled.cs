namespace MooVC.Syntax.CSharp.PropertyTests.MethodsTests.SetterTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenDifferentTypeThenFalseIsReturned()
    {
        // Arrange
        var subject = new Property.Methods.Setter { Behaviour = Snippet.From("value") };
        object target = new Property.Methods.Setter { Behaviour = Snippet.From("alternative") };

        // Act
        bool result = subject.Equals(target);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEquivalentInstanceThenTrueIsReturned()
    {
        // Arrange
        var subject = new Property.Methods.Setter
        {
            Behaviour = Snippet.From("value"),
            Mode = Property.Methods.Setter.Modes.Init,
            Scope = Scopes.Internal,
        };

        object target = new Property.Methods.Setter
        {
            Behaviour = Snippet.From("value"),
            Mode = Property.Methods.Setter.Modes.Init,
            Scope = Scopes.Internal,
        };

        // Act
        bool result = subject.Equals(target);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenNullThenFalseIsReturned()
    {
        // Arrange
        var subject = new Property.Methods.Setter { Behaviour = Snippet.From("value") };
        object? target = default;

        // Act
        bool result = subject.Equals(target);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenTrueIsReturned()
    {
        // Arrange
        var subject = new Property.Methods.Setter { Behaviour = Snippet.From("value") };
        object target = subject;

        // Act
        bool result = subject.Equals(target);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}