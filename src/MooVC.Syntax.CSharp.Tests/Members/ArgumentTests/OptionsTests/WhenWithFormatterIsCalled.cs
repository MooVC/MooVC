namespace MooVC.Syntax.CSharp.Members.ArgumentTests.OptionsTests;

using MooVC.Syntax.CSharp.Members;

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