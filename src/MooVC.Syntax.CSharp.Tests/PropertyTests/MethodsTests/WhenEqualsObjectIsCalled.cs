namespace MooVC.Syntax.CSharp.PropertyTests.MethodsTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenDifferentTypeThenFalseIsReturned()
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
        _ = await Assert.That(result).IsFalse();
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

        object target = new Property.Methods
        {
            Get = Snippet.From("value"),
            Set = new Property.Setter { Behaviour = Snippet.From("value = input") },
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
        var subject = new Property.Methods
        {
            Get = Snippet.From("value"),
        };

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
        var subject = new Property.Methods
        {
            Get = Snippet.From("value"),
            Set = new Property.Setter { Behaviour = Snippet.From("value = input") },
        };

        object target = subject;

        // Act
        bool result = subject.Equals(target);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}