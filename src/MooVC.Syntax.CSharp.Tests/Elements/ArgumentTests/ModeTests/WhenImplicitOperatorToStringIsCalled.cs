namespace MooVC.Syntax.CSharp.Elements.ArgumentTests.ModeTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Fact]
    public void GivenModeThenReturnsUnderlyingValue()
    {
        // Arrange
        Argument.Mode subject = Argument.Mode.Out;

        // Act
        string result = subject;

        // Assert
        result.ShouldBe("out");
    }
}