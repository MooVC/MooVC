namespace MooVC.Syntax.CSharp.Operators.BinaryTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public void GivenNonBinaryObjectThenReturnsFalse()
    {
        // Arrange
        Binary subject = BinaryTestsData.Create();

        // Act
        bool result = subject.Equals(new object());

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenBinaryObjectThenReturnsResultOfBinaryEquals()
    {
        // Arrange
        Binary subject = BinaryTestsData.Create();
        object target = BinaryTestsData.Create();

        // Act
        bool result = subject.Equals(target);

        // Assert
        result.ShouldBeTrue();
    }
}