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
        _ = await Assert.That(subject.Id).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(subject.Items).IsEmpty();
        _ = await Assert.That(subject.Name).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(subject.Path).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(subject.Type).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(subject.IsUndefined).IsTrue();
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
        _ = await Assert.That(subject.Id).IsEqualTo(Snippet.From(ItemTestsData.DefaultId));
        _ = await Assert.That(subject.Name).IsEqualTo(Snippet.From(ItemTestsData.DefaultName));
        _ = await Assert.That(subject.Path).IsEqualTo(Snippet.From(ItemTestsData.DefaultPath));
        _ = await Assert.That(subject.Type).IsEqualTo(Snippet.From(ItemTestsData.DefaultType));
        _ = await Assert.That(subject.Items).IsEqualTo(new[] { child });
        _ = await Assert.That(subject.IsUndefined).IsFalse();
    }
}