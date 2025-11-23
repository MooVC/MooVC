namespace MooVC.Syntax.CSharp.Members.ArgumentTests.ModeTests;

using MooVC.Syntax.CSharp.Members;

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
