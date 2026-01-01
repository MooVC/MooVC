namespace MooVC.Syntax.CSharp.Elements.ArgumentTests.FormatterTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Fact]
    public void GivenFormatterThenReturnsUnderlyingValue()
    {
        // Arrange
        Argument.Formatter subject = Argument.Formatter.Call;

        // Act
        string result = subject;

        // Assert
        result.ShouldBe("{0}: {1}");
    }
}