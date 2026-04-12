namespace MooVC.Syntax.CSharp.ResultTests.ModifiersTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenEquivalentObjectThenReturnsTrue()
    {
        // Arrange
        Result.Modifiers subject = Result.Modifiers.Unsafe;
        object other = Result.Modifiers.Unsafe;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}