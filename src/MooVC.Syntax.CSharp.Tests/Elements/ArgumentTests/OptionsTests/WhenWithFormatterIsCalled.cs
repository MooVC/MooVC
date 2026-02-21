namespace MooVC.Syntax.CSharp.Elements.ArgumentTests.OptionsTests;

public sealed class WhenWithFormatterIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        var options = new Argument.Options();
        Argument.Formatter value = Argument.Formatter.Declaration;

        // Act
        Argument.Options result = options.WithFormatter(value);

        // Assert
        result.ShouldNotBeSameAs(options);
        result.Formatter.ShouldBe(value);
        options.Formatter.ShouldNotBe(value);
    }
}