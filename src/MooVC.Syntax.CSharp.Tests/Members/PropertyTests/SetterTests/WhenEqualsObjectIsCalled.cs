namespace MooVC.Syntax.CSharp.Members.PropertyTests.SetterTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenNullThenFalseIsReturned()
    {
        // Arrange
        var subject = new Property.Setter { Behaviour = Snippet.From("value") };
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
        var subject = new Property.Setter { Behaviour = Snippet.From("value") };
        object target = subject;

        // Act
        bool result = subject.Equals(target);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEquivalentInstanceThenTrueIsReturned()
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
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentTypeThenFalseIsReturned()
    {
        // Arrange
        var subject = new Property.Setter { Behaviour = Snippet.From("value") };
        object target = new Property.Setter { Behaviour = Snippet.From("alternative") };

        // Act
        bool result = subject.Equals(target);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}