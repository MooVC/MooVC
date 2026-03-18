namespace MooVC.Syntax.Attributes.Project.ItemTests;

using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenItemIsUndefined()
    {
        // Act
        var subject = new Item();

        // Assert
        await Assert.That(subject.Condition).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.Exclude).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.Include).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.KeepDuplicates).IsFalse();
        await Assert.That(subject.MatchOnMetadata).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.MatchOnMetadataOptions).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.Metadata).IsEmpty();
        await Assert.That(subject.Remove).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.RemoveMetadata).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.Update).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.IsUndefined).IsTrue();
    }

    [Test]
    public async Task GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        Metadata metadata = ItemTestsData.CreateMetadata();

        // Act
        var subject = new Item
        {
            Condition = Snippet.From(ItemTestsData.DefaultCondition),
            Exclude = Snippet.From(ItemTestsData.DefaultExclude),
            Include = Snippet.From(ItemTestsData.DefaultInclude),
            KeepDuplicates = true,
            MatchOnMetadata = Snippet.From(ItemTestsData.DefaultMatchOnMetadata),
            MatchOnMetadataOptions = Snippet.From(ItemTestsData.DefaultMatchOnMetadataOptions),
            Metadata = [metadata],
            Remove = Snippet.From(ItemTestsData.DefaultRemove),
            RemoveMetadata = Snippet.From(ItemTestsData.DefaultRemoveMetadata),
            Update = Snippet.From(ItemTestsData.DefaultUpdate),
        };

        // Assert
        await Assert.That(subject.Condition).IsEqualTo(Snippet.From(ItemTestsData.DefaultCondition));
        await Assert.That(subject.Exclude).IsEqualTo(Snippet.From(ItemTestsData.DefaultExclude));
        await Assert.That(subject.Include).IsEqualTo(Snippet.From(ItemTestsData.DefaultInclude));
        await Assert.That(subject.KeepDuplicates).IsTrue();
        await Assert.That(subject.MatchOnMetadata).IsEqualTo(Snippet.From(ItemTestsData.DefaultMatchOnMetadata));
        await Assert.That(subject.MatchOnMetadataOptions).IsEqualTo(Snippet.From(ItemTestsData.DefaultMatchOnMetadataOptions));
        await Assert.That(subject.Metadata).IsEqualTo(new[] { metadata });
        await Assert.That(subject.Remove).IsEqualTo(Snippet.From(ItemTestsData.DefaultRemove));
        await Assert.That(subject.RemoveMetadata).IsEqualTo(Snippet.From(ItemTestsData.DefaultRemoveMetadata));
        await Assert.That(subject.Update).IsEqualTo(Snippet.From(ItemTestsData.DefaultUpdate));
        await Assert.That(subject.IsUndefined).IsFalse();
    }
}