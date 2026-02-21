namespace MooVC.Syntax.CSharp.Elements.ArgumentTests.FormatterTests;

public sealed class WhenToStringIsCalled
{
    private const string Format = "{0}::{1}";

    [Fact]
    public void GivenFormatterThenStringValueReturned()
    {
        // Arrange
        Argument.Formatter subject = Format;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(Format);
    }
}