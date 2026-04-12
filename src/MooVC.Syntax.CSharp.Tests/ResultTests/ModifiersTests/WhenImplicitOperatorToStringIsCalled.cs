namespace MooVC.Syntax.CSharp.ResultTests.ModifiersTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsString()
    {
        // Arrange
        Result.Modifiers subject = Result.Modifiers.Unsafe;

        // Act
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo("unsafe");
    }
}