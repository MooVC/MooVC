namespace MooVC.Syntax.CSharp.ArgumentTests.OptionsTests.FormattersTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Test]
    public async Task GivenFormattersThenReturnsUnderlyingValue()
    {
        // Arrange
        Argument.Options.Formatters subject = Argument.Options.Formatters.Call;

        // Act
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo("{0}: {1}");
    }
}