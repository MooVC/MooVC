namespace MooVC.Syntax.CSharp.Elements.ArgumentTests.FormatterTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Test]
    public async Task GivenFormatterThenReturnsUnderlyingValue()
    {
        // Arrange
        Argument.Formatter subject = Argument.Formatter.Call;

        // Act
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo("{0}: {1}");
    }
}