namespace MooVC.Syntax.CSharp.Concepts.RecordTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenEqualityOperatorRecordRecordIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Record? left = default;
        Record? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Record? left = default;
        Record right = RecordTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Record left = RecordTestsData.Create();
        Record? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Record first = RecordTestsData.Create();
        Record second = first;

        // Act
        bool result = first == second;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Record left = RecordTestsData.Create(scope: Scope.Internal);
        Record right = RecordTestsData.Create(scope: Scope.Internal);

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsTrue();
        _ = await Assert.That(resultRightLeft).IsTrue();
    }

    [Test]
    public async Task GivenDifferentNamesThenReturnsFalse()
    {
        // Arrange
        Record left = RecordTestsData.Create();
        Record right = RecordTestsData.Create(name: new Declaration { Name = "Other" });

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentExtensibilitiesThenReturnsFalse()
    {
        // Arrange
        Record left = RecordTestsData.Create(extensibility: Extensibility.Abstract);
        Record right = RecordTestsData.Create(extensibility: Extensibility.Sealed);

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}