namespace MooVC.Syntax.CSharp.StructTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Struct first = StructTestsData.Create();
        object second = first;

        // Act
        bool result = first.Equals(second);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenOtherTypeThenReturnsFalse()
    {
        // Arrange
        object other = new();
        Struct subject = StructTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValueThenReturnsTrue()
    {
        // Arrange
        object other = StructTestsData.Create(scope: Scope.Internal);
        Struct subject = StructTestsData.Create(scope: Scope.Internal);

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValueThenReturnsFalse()
    {
        // Arrange
        object other = StructTestsData.Create(name: new Declaration { Name = "Other" });
        Struct subject = StructTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}