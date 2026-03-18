namespace MooVC.Syntax.CSharp.Members.IndexerTests.MethodsTests;

using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenMethodsIsDefault()
    {
        // Act
        var subject = new Indexer.Methods();

        // Assert
        await Assert.That(subject.Get).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.IsDefault).IsTrue();
        await Assert.That(subject.Set).IsEqualTo(Snippet.Empty);
    }

    [Test]
    public async Task GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        var get = Snippet.From("value");
        var set = Snippet.From("value = input");

        // Act
        var subject = new Indexer.Methods
        {
            Get = get,
            Set = set,
        };

        // Assert
        await Assert.That(subject.Get).IsEqualTo(get);
        await Assert.That(subject.IsDefault).IsFalse();
        await Assert.That(subject.Set).IsEqualTo(set);
    }
}