namespace MooVC.Syntax.CSharp.ResultTests.ModifiersTests;

public sealed class WhenEqualityOperatorModifiersStringIsCalled
{
    [Test]
    public async Task GivenEqualValueThenReturnsTrue()
    {
        // Arrange
        Result.Modifiers subject = Result.Modifiers.RefReadOnly;

        // Act
        bool result = subject == "ref readonly";

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}