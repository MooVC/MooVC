namespace MooVC.Syntax.CSharp.ResultTests.ModifiersTests;

public sealed class WhenEqualsModifiersIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Result.Modifiers subject = Result.Modifiers.Ref;
        Result.Modifiers other = Result.Modifiers.Unsafe;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}