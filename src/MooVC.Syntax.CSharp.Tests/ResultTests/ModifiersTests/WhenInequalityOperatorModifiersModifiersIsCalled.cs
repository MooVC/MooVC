namespace MooVC.Syntax.CSharp.ResultTests.ModifiersTests;

public sealed class WhenInequalityOperatorModifiersModifiersIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Result.Modifiers left = Result.Modifiers.Ref;
        Result.Modifiers right = Result.Modifiers.Unsafe;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}