namespace MooVC.Syntax.CSharp.Attributes.Project.ItemTests;

using System;
using System.Xml.Linq;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        Item subject = Item.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenValuesThenReturnsFragment()
    {
        // Arrange
        Metadata metadata = ItemTestsData.CreateMetadata();
        Item subject = ItemTestsData.Create(metadata: metadata, keepDuplicates: true);

        var element = new XElement(
            nameof(Item),
            new XAttribute(nameof(Item.Condition), ItemTestsData.DefaultCondition),
            new XAttribute(nameof(Item.Exclude), ItemTestsData.DefaultExclude),
            new XAttribute(nameof(Item.Include), ItemTestsData.DefaultInclude),
            new XAttribute(nameof(Item.KeepDuplicates), true.ToString().ToLowerInvariant()),
            new XAttribute(nameof(Item.MatchOnMetadata), ItemTestsData.DefaultMatchOnMetadata),
            new XAttribute(nameof(Item.MatchOnMetadataOptions), ItemTestsData.DefaultMatchOnMetadataOptions),
            new XAttribute(nameof(Item.Remove), ItemTestsData.DefaultRemove),
            new XAttribute(nameof(Item.RemoveMetadata), ItemTestsData.DefaultRemoveMetadata),
            new XAttribute(nameof(Item.Update), ItemTestsData.DefaultUpdate),
            new XElement(metadata.Name.ToXmlElementName(),
                new XAttribute(nameof(Metadata.Condition), ItemTestsData.DefaultMetadataCondition),
                ItemTestsData.DefaultMetadataValue));

        string expected = element + Environment.NewLine;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(expected);
    }
}