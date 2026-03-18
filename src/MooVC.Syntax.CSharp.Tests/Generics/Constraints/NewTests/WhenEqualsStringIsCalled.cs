namespace MooVC.Syntax.CSharp.Generics.Constraints.NewTests;

using System.Diagnostics.CodeAnalysis;

public sealed class WhenEqualsStringIsCalled
{
    private const string Same = "new()";
    private const string Different = "";

    [Test]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        New subject = Same;
        string? other = default;

        // Act
        bool resultLeftRight = subject.Equals(other);
        bool resultRightLeft = ((New?)other)?.Equals(subject) ?? false;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }

    [Test]
    [SuppressMessage("Globalization", "CA1309:Use ordinal string comparison", Justification = "Suggestion defeats the purpose of the test.")]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        New left = Same;
        string right = Same;

        // Act
        bool resultLeftRight = left.Equals(right);
        bool resultRightLeft = right.Equals(left);

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Test]
    [SuppressMessage("Globalization", "CA1309:Use ordinal string comparison", Justification = "Suggestion defeats the purpose of the test.")]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        New left = Same;
        string right = Different;

        // Act
        bool resultLeftRight = left.Equals(right);
        bool resultRightLeft = right.Equals(left);

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }
}