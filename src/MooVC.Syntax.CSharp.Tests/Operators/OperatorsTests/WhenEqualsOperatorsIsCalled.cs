namespace MooVC.Syntax.CSharp.Operators.OperatorsTests;

using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Operators.BinaryTests;

public sealed class WhenEqualsOperatorsIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Operators? subject = default;
        Operators target = OperatorsSubjectData.Create();

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Operators subject = OperatorsSubjectData.Create();
        Operators target = subject;

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEquivalentValueThenReturnsTrue()
    {
        // Arrange
        ImmutableArray<Binary> binaries = [BinaryTestsData.Create()];
        Operators subject = OperatorsSubjectData.Create(binaries: binaries);
        Operators target = OperatorsSubjectData.Create(binaries: binaries);

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValueThenReturnsFalse()
    {
        // Arrange
        Operators subject = OperatorsSubjectData.Create();
        Operators target = OperatorsSubjectData.Create(binaries: [BinaryTestsData.Create()]);

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeFalse();
    }
}