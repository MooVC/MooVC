namespace MooVC.Syntax.CSharp.Attributes.Project.ItemGroupTests;

using System;
using System.Xml.Linq;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        ItemGroup subject = ItemGroup.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenValuesThenReturnsFragment()
    {
        // Arrange
        Item item = ItemGroupTestsData.CreateItem();
        ItemGroup subject = ItemGroupTestsData.Create(item: item);

        var itemElement = new XElement(
            nameof(Item),
            new XAttribute(nameof(Item.Include), ItemGroupTestsData.DefaultInclude));

        var element = new XElement(
            nameof(ItemGroup),
            new XAttribute(nameof(ItemGroup.Condition), ItemGroupTestsData.DefaultCondition),
            new XAttribute(nameof(ItemGroup.Label), ItemGroupTestsData.DefaultLabel),
            itemElement);

        string expected = element + Environment.NewLine;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(expected);
    }
}