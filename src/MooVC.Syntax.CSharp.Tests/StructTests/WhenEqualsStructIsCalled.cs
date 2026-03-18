namespace MooVC.Syntax.CSharp.StructTests;

public sealed class WhenEqualsStructIsCalled
{
    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Struct first = StructTestsData.Create();
        Struct second = first;

        // Act
        bool result = first.Equals(second);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEqualValueThenReturnsTrue()
    {
        // Arrange
        Struct left = StructTestsData.Create(scope: Scope.Internal);
        Struct right = StructTestsData.Create(scope: Scope.Internal);

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValueThenReturnsFalse()
    {
        // Arrange
        Struct left = StructTestsData.Create(behavior: Struct.Kind.Ref);
        Struct right = StructTestsData.Create();

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}