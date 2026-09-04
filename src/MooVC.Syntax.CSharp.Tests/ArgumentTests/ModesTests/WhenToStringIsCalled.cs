namespace MooVC.Syntax.CSharp.ArgumentTests.ModesTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenParamsModeThenReturnsParamsKeyword()
    {
        // Arrange
        Argument.Modes subject = Argument.Modes.Params;

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo("params");
    }
}