namespace MooVC.Syntax.CSharp.ClassTests;

public sealed class WhenEqualsClassIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Class subject = ClassTestsData.Create(extensibility: Modifiers.Sealed);
        Class value = ClassTestsData.Create(extensibility: Modifiers.Abstract);

        // Act
        bool result = subject.Equals(value);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Class subject = ClassTestsData.Create(isStatic: true, scope: Scopes.Internal);
        Class value = ClassTestsData.Create(isStatic: true, scope: Scopes.Internal);

        // Act
        bool result = subject.Equals(value);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        Class subject = ClassTestsData.Create();
        Class? value = default;

        // Act
        bool result = subject.Equals(value);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Class subject = ClassTestsData.Create(extensibility: Modifiers.Implicit);

        // Act
        bool result = subject.Equals(subject);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}