namespace MooVC.Syntax.CSharp.Concepts.InterfaceTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        Interface subject = InterfaceTestsData.Create();
        object? value = default;

        // Act
        bool result = subject.Equals(value);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Interface subject = InterfaceTestsData.Create(isPartial: true);
        object value = subject;

        // Act
        bool result = subject.Equals(value);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Interface subject = InterfaceTestsData.Create(scope: Scope.Internal);
        object value = InterfaceTestsData.Create(scope: Scope.Internal);

        // Act
        bool result = subject.Equals(value);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Interface subject = InterfaceTestsData.Create(isPartial: true);
        object value = InterfaceTestsData.Create(isPartial: false);

        // Act
        bool result = subject.Equals(value);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}