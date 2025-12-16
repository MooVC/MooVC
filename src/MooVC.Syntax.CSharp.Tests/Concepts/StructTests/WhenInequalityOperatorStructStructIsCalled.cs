namespace MooVC.Syntax.CSharp.Concepts.StructTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenInequalityOperatorStructStructIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Struct? left = default;
        Struct? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Struct? left = default;
        Struct right = StructTestsData.Create();

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        Struct left = StructTestsData.Create();
        Struct? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsFalse()
    {
        // Arrange
        Struct first = StructTestsData.Create();
        Struct second = first;

        // Act
        bool result = first != second;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Struct left = StructTestsData.Create(scope: Scope.Internal);
        Struct right = StructTestsData.Create(scope: Scope.Internal);

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentNamesThenReturnsTrue()
    {
        // Arrange
        Struct left = StructTestsData.Create();
        Struct right = StructTestsData.Create(name: new Declaration { Name = new Identifier("Other") });

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentBehaviorsThenReturnsTrue()
    {
        // Arrange
        Struct left = StructTestsData.Create(behavior: Struct.Kind.Record);
        Struct right = StructTestsData.Create(behavior: Struct.Kind.Ref);

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}
