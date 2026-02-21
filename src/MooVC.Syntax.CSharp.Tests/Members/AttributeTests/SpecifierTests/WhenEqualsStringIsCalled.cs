namespace MooVC.Syntax.CSharp.Members.AttributeTests.SpecifierTests;

using System.Diagnostics.CodeAnalysis;

public sealed class WhenEqualsStringIsCalled
{
    private const string Same = "assembly";
    private const string Different = "struct";

    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Attribute.Specifier subject = Attribute.Specifier.Assembly;
        string? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    [SuppressMessage("Globalization", "CA1309:Use ordinal string comparison", Justification = "Suggestion would defeat the purpose of the test.")]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Attribute.Specifier subject = Attribute.Specifier.Assembly;
        string other = Same;

        // Act
        bool resultLeftRight = subject.Equals(other);
        bool resultRightLeft = other.Equals(subject);

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Fact]
    [SuppressMessage("Globalization", "CA1309:Use ordinal string comparison", Justification = "Suggestion would defeat the purpose of the test.")]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Attribute.Specifier subject = Attribute.Specifier.Assembly;
        string other = Different;

        // Act
        bool resultLeftRight = subject.Equals(other);
        bool resultRightLeft = other.Equals(subject);

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }
}