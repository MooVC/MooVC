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
        _ = await Assert.That(subject.Condition).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(subject.Exclude).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(subject.Include).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(subject.KeepDuplicates).IsFalse();
        _ = await Assert.That(subject.MatchOnMetadata).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(subject.MatchOnMetadataOptions).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(subject.Metadata).IsEmpty();
        _ = await Assert.That(subject.Remove).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(subject.RemoveMetadata).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(subject.Update).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(subject.IsUndefined).IsTrue();
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
        _ = await Assert.That(subject.Condition).IsEqualTo(Snippet.From(ItemTestsData.DefaultCondition));
        _ = await Assert.That(subject.Exclude).IsEqualTo(Snippet.From(ItemTestsData.DefaultExclude));
        _ = await Assert.That(subject.Include).IsEqualTo(Snippet.From(ItemTestsData.DefaultInclude));
        _ = await Assert.That(subject.KeepDuplicates).IsTrue();
        _ = await Assert.That(subject.MatchOnMetadata).IsEqualTo(Snippet.From(ItemTestsData.DefaultMatchOnMetadata));
        _ = await Assert.That(subject.MatchOnMetadataOptions).IsEqualTo(Snippet.From(ItemTestsData.DefaultMatchOnMetadataOptions));
        _ = await Assert.That(subject.Metadata).IsEquivalentTo([metadata]);
        _ = await Assert.That(subject.Remove).IsEqualTo(Snippet.From(ItemTestsData.DefaultRemove));
        _ = await Assert.That(subject.RemoveMetadata).IsEqualTo(Snippet.From(ItemTestsData.DefaultRemoveMetadata));
        _ = await Assert.That(subject.Update).IsEqualTo(Snippet.From(ItemTestsData.DefaultUpdate));
        _ = await Assert.That(subject.IsUndefined).IsFalse();
    }
}