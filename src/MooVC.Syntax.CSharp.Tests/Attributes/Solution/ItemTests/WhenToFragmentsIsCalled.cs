namespace MooVC.Syntax.CSharp.Attributes.Solution.ItemTests;

using System.Collections.Immutable;
using System.Xml.Linq;

public sealed class WhenToFragmentsIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        Item subject = Item.Undefined;

        // Act
        ImmutableArray<XElement> result = subject.ToFragments();

        // Assert
        result.ShouldBeEmpty();
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

        var expected = new XElement(
            nameof(Item),
            new XAttribute(nameof(Item.Id), ItemTestsData.DefaultId),
            new XAttribute(nameof(Item.Name), ItemTestsData.DefaultName),
            new XAttribute(nameof(Item.Path), ItemTestsData.DefaultPath),
            new XAttribute(nameof(Item.Type), ItemTestsData.DefaultType),
            childElement);

        // Act
        ImmutableArray<XElement> result = subject.ToFragments();

        // Assert
        XElement fragment = result.ShouldHaveSingleItem();
        XNode.DeepEquals(expected, fragment).ShouldBeTrue();
    }
}