namespace MooVC.Syntax.Attributes.Resource.HeaderTests;

using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenHeaderIsUndefined()
    {
        // Act
        var subject = new Header();

        // Assert
        await Assert.That(subject.Name).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.Value).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.IsUndefined).IsTrue();
    }

    [Test]
    public async Task GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        var name = Snippet.From(HeaderTestsData.DefaultName);
        var value = Snippet.From(HeaderTestsData.DefaultValue);

        // Act
        var subject = new Header
        {
            Name = name,
            Value = value,
        };

        // Assert
        await Assert.That(subject.Name).IsEqualTo(name);
        await Assert.That(subject.Value).IsEqualTo(value);
        await Assert.That(subject.IsUndefined).IsFalse();
    }
}