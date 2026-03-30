namespace MooVC.Syntax.CSharp.AttributeTests.SpecifierTests;

using System.Diagnostics.CodeAnalysis;

public sealed class WhenEqualsStringIsCalled
{
    private const string Same = "assembly";
    private const string Different = "struct";

    [Test]
    [SuppressMessage("Globalization", "CA1309:Use ordinal string comparison", Justification = "Suggestion would defeat the purpose of the test.")]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Attribute.Specifier subject = Attribute.Specifier.Assembly;
        string other = Different;

        // Act
        bool resultLeftRight = subject.Equals(other);
        bool resultRightLeft = other.Equals(subject);

        // Assert
        _ = await Assert.That(resultLeftRight).IsFalse();
        _ = await Assert.That(resultRightLeft).IsFalse();
    }

    [Test]
    [SuppressMessage("Globalization", "CA1309:Use ordinal string comparison", Justification = "Suggestion would defeat the purpose of the test.")]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Attribute.Specifier subject = Attribute.Specifier.Assembly;
        string other = Same;

        // Act
        bool resultLeftRight = subject.Equals(other);
        bool resultRightLeft = other.Equals(subject);

        // Assert
        _ = await Assert.That(resultLeftRight).IsTrue();
        _ = await Assert.That(resultRightLeft).IsTrue();
    }

    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        Attribute.Specifier subject = Attribute.Specifier.Assembly;
        string? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}