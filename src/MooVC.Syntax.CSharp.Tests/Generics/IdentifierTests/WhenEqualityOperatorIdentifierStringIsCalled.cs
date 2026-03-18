namespace MooVC.Syntax.CSharp.Generics.IdentifierTests;

public sealed class WhenEqualityOperatorIdentifierStringIsCalled
{
    private const string Alternative = "Other";
    private const string Value = "Value";

    [Test]
    public async Task GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Identifier? left = default;
        string? right = default;

        // Act
        bool result = left == right;

        // Assert
        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Identifier? left = default;
        string right = Value;

        // Act
        bool result = left == right;

        // Assert
        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Identifier left = Value;
        string? right = default;

        // Act
        bool result = left == right;

        // Assert
        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Identifier first = Value;
        string second = first;

        // Act
        bool result = first == second;

        // Assert
        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Identifier left = Value;
        string right = Value;

        // Act
        bool result = left == right;

        // Assert
        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Identifier left = Value;
        string right = Alternative;

        // Act
        bool result = left == right;

        // Assert
        await Assert.That(result).IsFalse();
    }
}