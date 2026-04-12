namespace MooVC.Syntax.CSharp.ResultTests.ModifiersTests;

public sealed class WhenInequalityOperatorModifiersStringIsCalled
{
    [Test]
    public async Task GivenDifferentValueThenReturnsTrue()
    {
        // Arrange
        Result.Modifiers subject = Result.Modifiers.Ref;

        // Act
        bool result = subject != "unsafe";

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}