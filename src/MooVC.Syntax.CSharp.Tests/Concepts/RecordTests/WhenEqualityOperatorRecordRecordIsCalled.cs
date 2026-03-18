namespace MooVC.Syntax.CSharp.Concepts.RecordTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenEqualityOperatorRecordRecordIsCalled
{
    [Test]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Record? left = default;
        Record? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Record? left = default;
        Record right = RecordTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Record left = RecordTestsData.Create();
        Record? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Record first = RecordTestsData.Create();
        Record second = first;

        // Act
        bool result = first == second;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Record left = RecordTestsData.Create(scope: Scope.Internal);
        Record right = RecordTestsData.Create(scope: Scope.Internal);

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentNamesThenReturnsFalse()
    {
        // Arrange
        Record left = RecordTestsData.Create();
        Record right = RecordTestsData.Create(name: new Declaration { Name = "Other" });

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenDifferentExtensibilitiesThenReturnsFalse()
    {
        // Arrange
        Record left = RecordTestsData.Create(extensibility: Extensibility.Abstract);
        Record right = RecordTestsData.Create(extensibility: Extensibility.Sealed);

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}