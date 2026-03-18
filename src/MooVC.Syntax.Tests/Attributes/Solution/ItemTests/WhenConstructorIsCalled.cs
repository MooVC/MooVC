namespace MooVC.Syntax.Attributes.Solution.ItemTests;

using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenItemIsUndefined()
    {
        // Act
        var subject = new Item();

        // Assert
        await Assert.That(subject.Id).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.Items).IsEmpty();
        await Assert.That(subject.Name).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.Path).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.Type).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.IsUndefined).IsTrue();
    }

    [Test]
    public async Task GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        Item child = ItemTestsData.CreateChild();

        // Act
        var subject = new Item
        {
            Id = Snippet.From(ItemTestsData.DefaultId),
            Name = Snippet.From(ItemTestsData.DefaultName),
            Path = Snippet.From(ItemTestsData.DefaultPath),
            Type = Snippet.From(ItemTestsData.DefaultType),
            Items = [child],
        };

        // Assert
        await Assert.That(subject.Id).IsEqualTo(Snippet.From(ItemTestsData.DefaultId));
        await Assert.That(subject.Name).IsEqualTo(Snippet.From(ItemTestsData.DefaultName));
        await Assert.That(subject.Path).IsEqualTo(Snippet.From(ItemTestsData.DefaultPath));
        await Assert.That(subject.Type).IsEqualTo(Snippet.From(ItemTestsData.DefaultType));
        await Assert.That(subject.Items).IsEqualTo(new[] { child });
        await Assert.That(subject.IsUndefined).IsFalse();
    }
}