namespace MooVC.Syntax.CSharp.ClassTests;

public sealed class WhenEqualityOperatorClassClassIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Class? left = default;
        Class? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentExtensibilitiesThenReturnsFalse()
    {
        // Arrange
        Class left = ClassTestsData.Create(extensibility: Extensibility.Abstract);
        Class right = ClassTestsData.Create(extensibility: Extensibility.Sealed);

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentNamesThenReturnsFalse()
    {
        // Arrange
        Class left = ClassTestsData.Create();
        Class right = ClassTestsData.Create(name: new Declaration { Name = "Other" });

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Class left = ClassTestsData.Create(isStatic: true, scope: Scope.Internal);
        Class right = ClassTestsData.Create(isStatic: true, scope: Scope.Internal);

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsTrue();
        _ = await Assert.That(resultRightLeft).IsTrue();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Class? left = default;
        Class right = ClassTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Class left = ClassTestsData.Create();
        Class? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Class first = ClassTestsData.Create();
        Class second = first;

        // Act
        bool result = first == second;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}