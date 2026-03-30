namespace MooVC.Syntax.CSharp.ScopeTests;

public sealed class WhenEqualsObjectIsCalled
{
    private const string Same = "internal";
    private const string Different = "public";

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Scope left = Same;
        object right = (Scope)Different;

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Scope left = Same;
        object right = (Scope)Same;

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenNonScopeThenReturnsFalse()
    {
        // Arrange
        Scope subject = Same;
        object other = Same;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        Scope subject = Same;
        object? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Scope subject = Same;
        object other = subject;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}