namespace MooVC.Syntax.CSharp.ResultTests.ModifiersTests;

public sealed class WhenEqualityOperatorModifiersModifiersIsCalled
{
    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Result.Modifiers left = Result.Modifiers.Ref;
        Result.Modifiers right = Result.Modifiers.Ref;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}