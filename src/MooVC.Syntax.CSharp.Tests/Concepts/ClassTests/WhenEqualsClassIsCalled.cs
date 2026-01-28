namespace MooVC.Syntax.CSharp.Concepts.ClassTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenEqualsClassIsCalled
{
    [Fact]
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

    [Fact]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Class subject = ClassTestsData.Create(extensibility: Extensibility.Implicit);

        // Act
        bool result = subject.Equals(subject);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
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

    [Fact]
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