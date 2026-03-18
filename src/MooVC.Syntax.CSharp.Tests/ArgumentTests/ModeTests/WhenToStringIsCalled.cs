namespace MooVC.Syntax.CSharp.ArgumentTests.ModeTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenParamsModeThenReturnsParamsKeyword()
    {
        // Arrange
        Argument.Mode subject = Argument.Mode.Params;

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo("params");
    }
}