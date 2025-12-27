namespace MooVC.Syntax.CSharp.Members.ArgumentTests.ModeTests;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenParamsModeThenReturnsParamsKeyword()
    {
        // Arrange
        Argument.Mode subject = Argument.Mode.Params;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe("params");
    }
}