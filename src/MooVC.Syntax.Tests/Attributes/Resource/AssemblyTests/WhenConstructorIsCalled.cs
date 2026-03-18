namespace MooVC.Syntax.Attributes.Resource.AssemblyTests;

using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenAssemblyIsUndefined()
    {
        // Act
        var subject = new Assembly();

        // Assert
        await Assert.That(subject.Alias).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.Name).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.IsUndefined).IsTrue();
    }

    [Test]
    public async Task GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        var alias = Snippet.From(AssemblyTestsData.DefaultAlias);
        var name = Snippet.From(AssemblyTestsData.DefaultName);

        // Act
        var subject = new Assembly
        {
            Alias = alias,
            Name = name,
        };

        // Assert
        await Assert.That(subject.Alias).IsEqualTo(alias);
        await Assert.That(subject.Name).IsEqualTo(name);
        await Assert.That(subject.IsUndefined).IsFalse();
    }
}