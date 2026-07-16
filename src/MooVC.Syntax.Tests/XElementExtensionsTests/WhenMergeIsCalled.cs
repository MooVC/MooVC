namespace MooVC.Syntax.XElementExtensionsTests;

using System.Collections.Immutable;
using System.Xml.Linq;

public sealed class WhenMergeIsCalled
{
    [Test]
    public async Task GivenDefaultArrayThenReturnsEmpty()
    {
        // Arrange
        ImmutableArray<XElement> subject = default;

        // Act
        string result = subject.Merge();

        // Assert
        _ = await Assert.That(result).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task GivenElementsThenReturnsMergedXmlLines()
    {
        // Arrange
        ImmutableArray<XElement> subject =
        [
            new XElement("First"),
            new XElement("Second"),
        ];

        string expected = string.Concat(subject[0], Environment.NewLine, subject[1], Environment.NewLine);

        // Act
        string result = subject.Merge();

        // Assert
        _ = await Assert.That(result).IsEqualTo(expected);
    }
}