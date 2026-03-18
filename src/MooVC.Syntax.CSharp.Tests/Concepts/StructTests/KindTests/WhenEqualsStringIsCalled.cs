namespace MooVC.Syntax.CSharp.Concepts.StructTests.KindTests;

public sealed class WhenEqualsStringIsCalled
{
    [Test]
    public async Task GivenMatchingStringThenReturnsTrue()
    {
        // Arrange
        Struct.Kind subject = Struct.Kind.ReadOnly;

        // Act
        bool result = subject.Equals("readonly");

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenNonMatchingStringThenReturnsFalse()
    {
        // Arrange
        Struct.Kind subject = Struct.Kind.ReadOnly;

        // Act
        bool result = subject.Equals("record");

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}