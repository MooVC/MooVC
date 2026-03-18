namespace MooVC.Syntax.CSharp.Members.PropertyTests.MethodsTests;

using MooVC.Syntax.Elements;

public sealed class WhenEqualsMethodsIsCalled
{
    [Test]
    public async Task GivenNullThenFalseIsReturned()
    {
        // Arrange
        var subject = new Property.Methods { Get = Snippet.From("value") };
        Property.Methods? target = default!;

        // Act
        bool result = subject.Equals(target);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenTrueIsReturned()
    {
        // Arrange
        var subject = new Property.Methods
        {
            Get = Snippet.From("value"),
            Set = new Property.Setter { Behaviour = Snippet.From("value = input") },
        };

        Property.Methods target = subject;

        // Act
        bool result = subject.Equals(target);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEquivalentInstanceThenTrueIsReturned()
    {
        // Arrange
        var subject = new Property.Methods
        {
            Get = Snippet.From("value"),
            Set = new Property.Setter { Behaviour = Snippet.From("value = input") },
        };

        var target = new Property.Methods
        {
            Get = Snippet.From("value"),
            Set = new Property.Setter { Behaviour = Snippet.From("value = input") },
        };

        // Act
        bool resultSubjectTarget = subject.Equals(target);
        bool resultTargetSubject = target.Equals(subject);

        // Assert
        _ = await Assert.That(resultSubjectTarget).IsTrue();
        _ = await Assert.That(resultTargetSubject).IsTrue();
    }

    [Test]
    public async Task GivenDifferentInstanceThenFalseIsReturned()
    {
        // Arrange
        var subject = new Property.Methods
        {
            Get = Snippet.From("value"),
        };

        var target = new Property.Methods
        {
            Get = Snippet.From("alternative"),
        };

        // Act
        bool resultSubjectTarget = subject.Equals(target);
        bool resultTargetSubject = target.Equals(subject);

        // Assert
        _ = await Assert.That(resultSubjectTarget).IsFalse();
        _ = await Assert.That(resultTargetSubject).IsFalse();
    }
}