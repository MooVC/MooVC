namespace MooVC.Syntax.CSharp.Elements.ArgumentTests.OptionsTests;

public sealed class WhenWithFormatterIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        var options = new Argument.Options();
        Argument.Formatter value = Argument.Formatter.Declaration;

        // Act
        Argument.Options result = options.WithFormatter(value);

        // Assert
        await Assert.That(ReferenceEquals(result, options)).IsFalse();
        await Assert.That(result.Formatter).IsEqualTo(value);
        await Assert.That(options.Formatter).IsNotEqualTo(value);
    }
}