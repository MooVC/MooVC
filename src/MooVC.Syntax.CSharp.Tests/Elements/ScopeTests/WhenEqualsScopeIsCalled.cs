namespace MooVC.Syntax.CSharp.Elements.ScopeTests;

public sealed class WhenEqualsScopeIsCalled
{
    private const string Same = "internal";

    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        Scope subject = Same;
        Scope? other = default;

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
        Scope other = subject;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Scope left = Same;
        Scope right = Same;

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Scope left = Same;
        Scope right = "public";

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}