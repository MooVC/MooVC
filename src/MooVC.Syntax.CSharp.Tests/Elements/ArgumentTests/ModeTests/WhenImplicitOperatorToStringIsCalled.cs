namespace MooVC.Syntax.CSharp.Elements.ArgumentTests.ModeTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Test]
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