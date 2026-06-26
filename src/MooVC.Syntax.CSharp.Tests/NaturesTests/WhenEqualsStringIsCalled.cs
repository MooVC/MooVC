namespace MooVC.Syntax.CSharp.NaturesTests;

using System.Diagnostics.CodeAnalysis;

public sealed class WhenEqualsStringIsCalled
{
    private const string Same = "class";
    private const string Different = "struct";

    [Test]
    [SuppressMessage("Globalization", "CA1309:Use ordinal string comparison", Justification = "Suggestion defeats the purpose of the test.")]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Natures left = Same;
        string right = Different;

        // Act
        bool resultLeftRight = left.Equals(right);
        bool resultRightLeft = right.Equals(left);

        // Assert
        _ = await Assert.That(resultLeftRight).IsFalse();
        _ = await Assert.That(resultRightLeft).IsFalse();
    }

    [Test]
    [SuppressMessage("Globalization", "CA1309:Use ordinal string comparison", Justification = "Suggestion defeats the purpose of the test.")]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Natures left = Same;
        string right = Same;

        // Act
        bool resultLeftRight = left.Equals(right);
        bool resultRightLeft = right.Equals(left);

        // Assert
        _ = await Assert.That(resultLeftRight).IsTrue();
        _ = await Assert.That(resultRightLeft).IsTrue();
    }

    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        Natures subject = Same;
        string? other = default;

        // Act
        bool resultLeftRight = subject.Equals(other);
        bool resultRightLeft = ((Natures?)other)?.Equals(subject) ?? false;

        // Assert
        _ = await Assert.That(resultLeftRight).IsFalse();
        _ = await Assert.That(resultRightLeft).IsFalse();
    }
}