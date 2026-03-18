namespace MooVC.Syntax.Attributes.Solution.PropertyTests;

using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenPropertyIsUndefined()
    {
        // Act
        var subject = new Property();

        // Assert
        await Assert.That(subject.Name).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.Value).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.IsUndefined).IsTrue();
    }

    [Test]
    public async Task GivenValuesThenPropertiesAreAssigned()
    {
        // Act
        var subject = new Property
        {
            Name = Snippet.From(PropertyTestsData.DefaultName),
            Value = Snippet.From(PropertyTestsData.DefaultValue),
        };

        // Assert
        await Assert.That(subject.Name).IsEqualTo(Snippet.From(PropertyTestsData.DefaultName));
        await Assert.That(subject.Value).IsEqualTo(Snippet.From(PropertyTestsData.DefaultValue));
        await Assert.That(subject.IsUndefined).IsFalse();
    }
}