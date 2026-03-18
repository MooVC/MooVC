namespace MooVC.Syntax.CSharp.Concepts.RecordTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Record subject = RecordTestsData.Create();
        object? value = default;

        // Act
        bool result = subject.Equals(value);

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Record subject = RecordTestsData.Create(isPartial: true);
        object value = subject;

        // Act
        bool result = subject.Equals(value);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Record subject = RecordTestsData.Create(scope: Scope.Internal);
        object value = RecordTestsData.Create(scope: Scope.Internal);

        // Act
        bool result = subject.Equals(value);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Record subject = RecordTestsData.Create(extensibility: Extensibility.Abstract);
        object value = RecordTestsData.Create(extensibility: Extensibility.Sealed);

        // Act
        bool result = subject.Equals(value);

        // Assert
        result.ShouldBeFalse();
    }
}