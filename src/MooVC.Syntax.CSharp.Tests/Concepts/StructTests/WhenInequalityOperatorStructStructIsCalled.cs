namespace MooVC.Syntax.CSharp.Concepts.StructTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenInequalityOperatorStructStructIsCalled
{
    [Test]
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

    [Test]
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

    [Test]
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

    [Test]
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

    [Test]
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

    [Test]
    public void GivenDifferentNamesThenReturnsTrue()
    {
        // Arrange
        Struct left = StructTestsData.Create();
        Struct right = StructTestsData.Create(name: new Declaration { Name = "Other" });

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
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