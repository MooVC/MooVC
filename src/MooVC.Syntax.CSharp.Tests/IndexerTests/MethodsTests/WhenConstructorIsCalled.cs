namespace MooVC.Syntax.CSharp.IndexerTests.MethodsTests;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenMethodsIsDefault()
    {
        // Act
        var subject = new Indexer.Methods();

        // Assert
        _ = await Assert.That(subject.Get).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(subject.IsDefault).IsTrue();
        _ = await Assert.That(subject.Set).IsEqualTo(Snippet.Empty);
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
        _ = await Assert.That(subject.Get).IsEqualTo(get);
        _ = await Assert.That(subject.IsDefault).IsFalse();
        _ = await Assert.That(subject.Set).IsEqualTo(set);
    }
}