namespace MooVC.Syntax.CSharp.ResultTests.ModesTests;

public sealed class WhenEqualsStringIsCalled
{
    [Test]
    public async Task GivenEquivalentStringThenReturnsTrue()
    {
        // Arrange
        Result.Modes subject = Result.Modes.Asynchronous;

        // Act
        bool result = subject.Equals("async");

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}