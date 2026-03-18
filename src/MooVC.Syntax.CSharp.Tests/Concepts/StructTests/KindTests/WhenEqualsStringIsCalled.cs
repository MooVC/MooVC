namespace MooVC.Syntax.CSharp.Concepts.StructTests.KindTests;

public sealed class WhenEqualsStringIsCalled
{
    [Test]
    public void GivenMatchingStringThenReturnsTrue()
    {
        // Arrange
        Struct.Kind subject = Struct.Kind.ReadOnly;

        // Act
        bool result = subject.Equals("readonly");

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenNonMatchingStringThenReturnsFalse()
    {
        // Arrange
        Struct.Kind subject = Struct.Kind.ReadOnly;

        // Act
        bool result = subject.Equals("record");

        // Assert
        result.ShouldBeFalse();
    }
}