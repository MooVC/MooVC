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
            Condition = ItemTestsData.DefaultCondition,
            Exclude = ItemTestsData.DefaultExclude,
            Include = ItemTestsData.DefaultInclude,
            KeepDuplicates = true,
            MatchOnMetadata = ItemTestsData.DefaultMatchOnMetadata,
            MatchOnMetadataOptions = ItemTestsData.DefaultMatchOnMetadataOptions,
            Metadata = [metadata],
            Remove = ItemTestsData.DefaultRemove,
            RemoveMetadata = ItemTestsData.DefaultRemoveMetadata,
            Update = ItemTestsData.DefaultUpdate,
        };

        // Assert
        subject.Condition.ShouldBe(ItemTestsData.DefaultCondition);
        subject.Exclude.ShouldBe(ItemTestsData.DefaultExclude);
        subject.Include.ShouldBe(ItemTestsData.DefaultInclude);
        subject.KeepDuplicates.ShouldBeTrue();
        subject.MatchOnMetadata.ShouldBe(ItemTestsData.DefaultMatchOnMetadata);
        subject.MatchOnMetadataOptions.ShouldBe(ItemTestsData.DefaultMatchOnMetadataOptions);
        subject.Metadata.ShouldBe(new[] { metadata });
        subject.Remove.ShouldBe(ItemTestsData.DefaultRemove);
        subject.RemoveMetadata.ShouldBe(ItemTestsData.DefaultRemoveMetadata);
        subject.Update.ShouldBe(ItemTestsData.DefaultUpdate);
        subject.IsUndefined.ShouldBeFalse();
    }
}