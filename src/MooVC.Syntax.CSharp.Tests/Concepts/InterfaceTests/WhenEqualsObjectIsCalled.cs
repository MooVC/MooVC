namespace MooVC.Syntax.CSharp.Concepts.InterfaceTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Interface subject = InterfaceTestsData.Create();
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
        Interface subject = InterfaceTestsData.Create(isPartial: true);
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
        Interface subject = InterfaceTestsData.Create(scope: Scope.Internal);
        object value = InterfaceTestsData.Create(scope: Scope.Internal);

        // Act
        bool result = subject.Equals(value);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Interface subject = InterfaceTestsData.Create(isPartial: true);
        object value = InterfaceTestsData.Create(isPartial: false);

        // Act
        bool result = subject.Equals(value);

        // Assert
        result.ShouldBeFalse();
    }
}