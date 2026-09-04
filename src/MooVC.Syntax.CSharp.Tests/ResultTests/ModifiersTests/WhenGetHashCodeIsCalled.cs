namespace MooVC.Syntax.CSharp.ResultTests.ModifiersTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenEqualValuesThenHashesMatch()
    {
        // Arrange
        Result.Modifiers first = Result.Modifiers.Ref;
        Result.Modifiers second = Result.Modifiers.Ref;

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsEqualTo(secondHash);
    }
}