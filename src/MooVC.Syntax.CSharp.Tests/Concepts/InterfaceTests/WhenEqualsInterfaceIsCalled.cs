namespace MooVC.Syntax.CSharp.Concepts.InterfaceTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenEqualsInterfaceIsCalled
{
    [Test]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Interface subject = InterfaceTestsData.Create();
        Interface? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Interface subject = InterfaceTestsData.Create(isPartial: true);
        Interface other = subject;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Interface subject = InterfaceTestsData.Create(scope: Scope.Internal);
        Interface other = InterfaceTestsData.Create(scope: Scope.Internal);

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Interface subject = InterfaceTestsData.Create(isPartial: true);
        Interface other = InterfaceTestsData.Create(isPartial: false);

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}