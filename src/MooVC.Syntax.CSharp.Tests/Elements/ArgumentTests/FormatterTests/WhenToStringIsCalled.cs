namespace MooVC.Syntax.CSharp.Elements.ArgumentTests.FormatterTests;

public sealed class WhenToStringIsCalled
{
    private const string Format = "{0}::{1}";

    [Test]
    public async Task GivenFormatterThenStringValueReturned()
    {
        // Arrange
        Argument.Formatter subject = Format;

        // Act
        string result = subject.ToString();

        // Assert
        await Assert.That(result).IsEqualTo(Format);
    }
}