namespace MooVC.Syntax.Solution.PropertyTests;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenPropertyIsUndefined()
    {
        // Act
        var subject = new Property();

        // Assert
        _ = await Assert.That(subject.Name).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(subject.Value).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(subject.IsUndefined).IsTrue();
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
        _ = await Assert.That(subject.Name).IsEqualTo(Snippet.From(PropertyTestsData.DefaultName));
        _ = await Assert.That(subject.Value).IsEqualTo(Snippet.From(PropertyTestsData.DefaultValue));
        _ = await Assert.That(subject.IsUndefined).IsFalse();
    }
}