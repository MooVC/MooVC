namespace MooVC.Syntax.XObjectExtensionsTests;

using System.Xml.Linq;

public sealed class WhenAndIsCalled
{
    [Test]
    public async Task GivenTwoTypedSequencesThenReturnsCombinedObjects()
    {
        // Arrange
        XElement[] first = [new XElement("First")];
        XComment[] second = [new XComment("Second")];

        // Act
        string[] result = [.. first.And(second).Select(item => item.ToString()!)];

        // Assert
        _ = await Assert.That(result).IsEquivalentTo(["<First />", "<!--Second-->"]);
    }

    [Test]
    public async Task GivenXObjectSequenceAndSingleObjectThenReturnsCombinedObjects()
    {
        // Arrange
        XObject[] first = [new XElement("First")];
        var second = new XComment("Second");

        // Act
        string[] result = [.. first.And(second).Select(item => item.ToString()!)];

        // Assert
        _ = await Assert.That(result).IsEquivalentTo(["<First />", "<!--Second-->"]);
    }

    [Test]
    public async Task GivenXObjectSequenceAndTypedSequenceThenReturnsCombinedObjects()
    {
        // Arrange
        XObject[] first = [new XElement("First")];
        XComment[] second = [new XComment("Second")];

        // Act
        string[] result = [.. first.And(second).Select(item => item.ToString()!)];

        // Assert
        _ = await Assert.That(result).IsEquivalentTo(["<First />", "<!--Second-->"]);
    }
}