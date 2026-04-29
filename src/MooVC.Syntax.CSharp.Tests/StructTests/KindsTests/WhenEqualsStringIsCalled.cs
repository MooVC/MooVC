namespace MooVC.Syntax.CSharp.StructTests.KindsTests;

public sealed class WhenEqualsStringIsCalled
{
    [Test]
    public async Task GivenMatchingStringThenReturnsTrue()
    {
        // Arrange
        Struct.Kinds subject = Struct.Kinds.ReadOnly;

        // Act
        bool result = subject.Equals("readonly");

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenNonMatchingStringThenReturnsFalse()
    {
        // Arrange
        Struct.Kinds subject = Struct.Kinds.ReadOnly;

        // Act
        bool result = subject.Equals("record");

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}