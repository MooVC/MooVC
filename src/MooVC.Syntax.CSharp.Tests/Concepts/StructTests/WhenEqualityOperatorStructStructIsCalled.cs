namespace MooVC.Syntax.CSharp.Concepts.StructTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenEqualityOperatorStructStructIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Struct? left = default;
        Struct? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Struct? left = default;
        Struct right = StructTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Struct left = StructTestsData.Create();
        Struct? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Struct first = StructTestsData.Create();
        Struct second = first;

        // Act
        bool result = first == second;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Struct left = StructTestsData.Create(scope: Scope.Internal);
        Struct right = StructTestsData.Create(scope: Scope.Internal);

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentNamesThenReturnsFalse()
    {
        // Arrange
        Struct left = StructTestsData.Create();
        Struct right = StructTestsData.Create(name: new Declaration { Name = new Identifier("Other") });

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentBehaviorsThenReturnsFalse()
    {
        // Arrange
        Struct left = StructTestsData.Create(behavior: Struct.Kind.Record);
        Struct right = StructTestsData.Create(behavior: Struct.Kind.Ref);

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}