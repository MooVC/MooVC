namespace MooVC.Syntax.Attributes.Project.ItemTests;

using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenItemIsUndefined()
    {
        // Act
        var subject = new Item();

        // Assert
        subject.Condition.ShouldBe(Snippet.Empty);
        subject.Exclude.ShouldBe(Snippet.Empty);
        subject.Include.ShouldBe(Snippet.Empty);
        subject.KeepDuplicates.ShouldBeFalse();
        subject.MatchOnMetadata.ShouldBe(Snippet.Empty);
        subject.MatchOnMetadataOptions.ShouldBe(Snippet.Empty);
        subject.Metadata.ShouldBeEmpty();
        subject.Remove.ShouldBe(Snippet.Empty);
        subject.RemoveMetadata.ShouldBe(Snippet.Empty);
        subject.Update.ShouldBe(Snippet.Empty);
        subject.IsUndefined.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
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
        subject.Condition.ShouldBe(Snippet.From(ItemTestsData.DefaultCondition));
        subject.Exclude.ShouldBe(Snippet.From(ItemTestsData.DefaultExclude));
        subject.Include.ShouldBe(Snippet.From(ItemTestsData.DefaultInclude));
        subject.KeepDuplicates.ShouldBeTrue();
        subject.MatchOnMetadata.ShouldBe(Snippet.From(ItemTestsData.DefaultMatchOnMetadata));
        subject.MatchOnMetadataOptions.ShouldBe(Snippet.From(ItemTestsData.DefaultMatchOnMetadataOptions));
        subject.Metadata.ShouldBe(new[] { metadata });
        subject.Remove.ShouldBe(Snippet.From(ItemTestsData.DefaultRemove));
        subject.RemoveMetadata.ShouldBe(Snippet.From(ItemTestsData.DefaultRemoveMetadata));
        subject.Update.ShouldBe(Snippet.From(ItemTestsData.DefaultUpdate));
        subject.IsUndefined.ShouldBeFalse();
    }
}