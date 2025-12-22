namespace MooVC.Syntax.CSharp.Concepts.StructTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenEqualsStructIsCalled
{
    [Fact]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Struct first = StructTestsData.Create();
        Struct second = first;

        // Act
        bool result = first.Equals(second);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValueThenReturnsTrue()
    {
        // Arrange
        Struct left = StructTestsData.Create(scope: Scope.Internal);
        Struct right = StructTestsData.Create(scope: Scope.Internal);

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValueThenReturnsFalse()
    {
        // Arrange
        Struct left = StructTestsData.Create(behavior: Struct.Kind.Ref);
        Struct right = StructTestsData.Create();

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeFalse();
    }
}