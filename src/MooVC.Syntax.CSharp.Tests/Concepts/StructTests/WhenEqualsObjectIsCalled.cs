namespace MooVC.Syntax.CSharp.Concepts.StructTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenEqualsObjectIsCalled
{
    [Fact]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Struct first = StructTestsData.Create();
        object second = first;

        // Act
        bool result = first.Equals(second);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenOtherTypeThenReturnsFalse()
    {
        // Arrange
        object other = new();
        Struct subject = StructTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValueThenReturnsTrue()
    {
        // Arrange
        object other = StructTestsData.Create(scope: Scope.Internal);
        Struct subject = StructTestsData.Create(scope: Scope.Internal);

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValueThenReturnsFalse()
    {
        // Arrange
        object other = StructTestsData.Create(name: new Declaration { Name = new Variable("Other") });
        Struct subject = StructTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}