namespace MooVC.Syntax.Attributes.Solution.ItemTests;

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
        Item child = ItemTestsData.CreateChild();
        Item subject = ItemTestsData.Create(item: child);

        var childElement = new XElement(
            nameof(Item),
            new XAttribute(nameof(Item.Id), "ChildId"),
            new XAttribute(nameof(Item.Name), "ChildName"),
            new XAttribute(nameof(Item.Path), "assets/child.txt"),
            new XAttribute(nameof(Item.Type), "ChildType"));

        var element = new XElement(
            nameof(Item),
            new XAttribute(nameof(Item.Id), ItemTestsData.DefaultId),
            new XAttribute(nameof(Item.Name), ItemTestsData.DefaultName),
            new XAttribute(nameof(Item.Path), ItemTestsData.DefaultPath),
            new XAttribute(nameof(Item.Type), ItemTestsData.DefaultType),
            childElement);

        string expected = element + Environment.NewLine;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(expected);
    }
}