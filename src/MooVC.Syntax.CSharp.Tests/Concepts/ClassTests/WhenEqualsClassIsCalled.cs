namespace MooVC.Syntax.CSharp.Concepts.ClassTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenEqualsClassIsCalled
{
    [Test]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Class subject = ClassTestsData.Create();
        Class? value = default;

        // Act
        bool result = subject.Equals(value);

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Class subject = ClassTestsData.Create(extensibility: Extensibility.Implicit);

        // Act
        bool result = subject.Equals(subject);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Class subject = ClassTestsData.Create(isStatic: true, scope: Scope.Internal);
        Class value = ClassTestsData.Create(isStatic: true, scope: Scope.Internal);

        // Act
        bool result = subject.Equals(value);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Class subject = ClassTestsData.Create(extensibility: Extensibility.Sealed);
        Class value = ClassTestsData.Create(extensibility: Extensibility.Abstract);

        // Act
        bool result = subject.Equals(value);

        // Assert
        result.ShouldBeFalse();
    }
}