namespace MooVC.Syntax.CSharp.ScopesTests;

public sealed class WhenEqualsScopeIsCalled
{
    private const string Same = "internal";

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Scopes left = Same;
        Scopes right = "public";

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Scopes left = Same;
        Scopes right = Same;

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        Scopes subject = Same;
        Scopes? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Scopes subject = Same;
        Scopes other = subject;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}