namespace MooVC.Syntax.CSharp.Concepts.ClassTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenEqualityOperatorClassClassIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Class? left = default;
        Class? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Class? left = default;
        Class right = ClassTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Class left = ClassTestsData.Create();
        Class? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Class first = ClassTestsData.Create();
        Class second = first;

        // Act
        bool result = first == second;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Class left = ClassTestsData.Create(isStatic: true, scope: Scope.Internal);
        Class right = ClassTestsData.Create(isStatic: true, scope: Scope.Internal);

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
        Class left = ClassTestsData.Create();
        Class right = ClassTestsData.Create(name: new Declaration { Name = "Other" });

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentExtensibilitiesThenReturnsFalse()
    {
        // Arrange
        Class left = ClassTestsData.Create(extensibility: Extensibility.Abstract);
        Class right = ClassTestsData.Create(extensibility: Extensibility.Sealed);

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}