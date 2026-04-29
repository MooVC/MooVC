namespace MooVC.Syntax.CSharp.ArgumentTests.OptionsTests.FormattersTests;

public sealed class WhenToStringIsCalled
{
    private const string Format = "{0}::{1}";

    [Test]
    public async Task GivenFormattersThenStringValueReturned()
    {
        // Arrange
        Argument.Options.Formatters subject = Format;

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo(Format);
    }
}