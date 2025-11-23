namespace MooVC.Syntax.CSharp.Members.ArgumentTests.FormatterTests;

using MooVC.Syntax.CSharp.Members;

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
