namespace MooVC.Syntax.CSharp.PropertyTests.MethodsTests.SetterTests;

public sealed class WhenEqualsSetterIsCalled
{
    [Test]
    public async Task GivenDifferentInstanceThenFalseIsReturned()
    {
        // Arrange
        var subject = new Property.Methods.Setter { Behaviour = Snippet.From("value") };
        var target = new Property.Methods.Setter { Behaviour = Snippet.From("alternative") };

        // Act
        bool resultSubjectTarget = subject.Equals(target);
        bool resultTargetSubject = target.Equals(subject);

        // Assert
        _ = await Assert.That(resultSubjectTarget).IsFalse();
        _ = await Assert.That(resultTargetSubject).IsFalse();
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

        var target = new Property.Methods.Setter
        {
            Behaviour = Snippet.From("value"),
            Mode = Property.Methods.Setter.Modes.Init,
            Scope = Scopes.Internal,
        };

        // Act
        bool resultSubjectTarget = subject.Equals(target);
        bool resultTargetSubject = target.Equals(subject);

        // Assert
        _ = await Assert.That(resultSubjectTarget).IsTrue();
        _ = await Assert.That(resultTargetSubject).IsTrue();
    }

    [Test]
    public async Task GivenNullThenFalseIsReturned()
    {
        // Arrange
        var subject = new Property.Methods.Setter { Behaviour = Snippet.From("value") };
        Property.Methods.Setter? target = default!;

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
        Property.Methods.Setter target = subject;

        // Act
        bool result = subject.Equals(target);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}