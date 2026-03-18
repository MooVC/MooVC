namespace MooVC.Syntax.CSharp.NewTests;

using System.Diagnostics.CodeAnalysis;

public sealed class WhenEqualsStringIsCalled
{
    private const string Same = "new()";
    private const string Different = "";

    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        New subject = Same;
        string? other = default;

        // Act
        bool resultLeftRight = subject.Equals(other);
        bool resultRightLeft = ((New?)other)?.Equals(subject) ?? false;

        // Assert
        _ = await Assert.That(resultLeftRight).IsFalse();
        _ = await Assert.That(resultRightLeft).IsFalse();
    }

    [Test]
    [SuppressMessage("Globalization", "CA1309:Use ordinal string comparison", Justification = "Suggestion defeats the purpose of the test.")]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        New left = Same;
        string right = Same;

        // Act
        bool resultLeftRight = left.Equals(right);
        bool resultRightLeft = right.Equals(left);

        // Assert
        _ = await Assert.That(resultLeftRight).IsTrue();
        _ = await Assert.That(resultRightLeft).IsTrue();
    }

    [Test]
    [SuppressMessage("Globalization", "CA1309:Use ordinal string comparison", Justification = "Suggestion defeats the purpose of the test.")]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        New left = Same;
        string right = Different;

        // Act
        bool resultLeftRight = left.Equals(right);
        bool resultRightLeft = right.Equals(left);

        // Assert
        _ = await Assert.That(resultLeftRight).IsFalse();
        _ = await Assert.That(resultRightLeft).IsFalse();
    }
}