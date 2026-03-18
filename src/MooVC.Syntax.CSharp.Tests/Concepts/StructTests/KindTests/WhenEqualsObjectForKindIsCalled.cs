namespace MooVC.Syntax.CSharp.Concepts.StructTests.KindTests;

public sealed class WhenEqualsObjectForKindIsCalled
{
    [Test]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Struct.Kind subject = Struct.Kind.Record;
        object other = subject;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenOtherTypeThenReturnsFalse()
    {
        // Arrange
        Struct.Kind subject = Struct.Kind.Record;

        // Act
        bool result = subject.Equals(new object());

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenDifferentValueThenReturnsFalse()
    {
        // Arrange
        Struct.Kind subject = Struct.Kind.Record;
        object other = Struct.Kind.Ref;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}