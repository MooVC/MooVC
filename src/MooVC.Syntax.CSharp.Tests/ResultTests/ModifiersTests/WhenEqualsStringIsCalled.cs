namespace MooVC.Syntax.CSharp.ResultTests.ModifiersTests;

public sealed class WhenEqualsStringIsCalled
{
    [Test]
    public async Task GivenEqualStringThenReturnsTrue()
    {
        // Arrange
        Result.Modifiers subject = Result.Modifiers.Ref;

        // Act
        bool result = subject.Equals("ref");

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}