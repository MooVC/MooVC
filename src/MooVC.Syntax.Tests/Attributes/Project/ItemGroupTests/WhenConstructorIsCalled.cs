namespace MooVC.Syntax.Attributes.Project.ItemGroupTests;

using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenItemGroupIsUndefined()
    {
        // Act
        var subject = new ItemGroup();

        // Assert
        await Assert.That(subject.Condition).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.Label).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.Items).IsEmpty();
        await Assert.That(subject.IsUndefined).IsTrue();
    }

    [Test]
    public async Task GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        Item item = ItemGroupTestsData.CreateItem();

        // Act
        var subject = new ItemGroup
        {
            Condition = Snippet.From(ItemGroupTestsData.DefaultCondition),
            Label = Snippet.From(ItemGroupTestsData.DefaultLabel),
            Items = [item],
        };

        // Assert
        await Assert.That(subject.Condition).IsEqualTo(Snippet.From(ItemGroupTestsData.DefaultCondition));
        await Assert.That(subject.Label).IsEqualTo(Snippet.From(ItemGroupTestsData.DefaultLabel));
        await Assert.That(subject.Items).IsEqualTo(new[] { item });
        await Assert.That(subject.IsUndefined).IsFalse();
    }
}