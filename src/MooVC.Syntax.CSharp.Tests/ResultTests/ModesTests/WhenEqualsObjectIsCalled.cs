namespace MooVC.Syntax.CSharp.ResultTests.ModesTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenEquivalentObjectThenReturnsTrue()
    {
        // Arrange
        Result.Modes subject = Result.Modes.Asynchronous;
        object other = Result.Modes.Asynchronous;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}