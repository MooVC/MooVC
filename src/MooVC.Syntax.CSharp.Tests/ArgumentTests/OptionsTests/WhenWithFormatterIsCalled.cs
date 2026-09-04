namespace MooVC.Syntax.CSharp.ArgumentTests.OptionsTests;

public sealed class WhenWithFormatterIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        var options = new Argument.Options();
        Argument.Options.Formatters value = Argument.Options.Formatters.Declaration;

        // Act
        Argument.Options result = options.WithFormatter(value);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(options);
        _ = await Assert.That(result.Formatter).IsEqualTo(value);
        _ = await Assert.That(options.Formatter).IsNotEqualTo(value);
    }
}