namespace MooVC.Syntax.CSharp.Generics.IdentifierTests;

public sealed class WhenEqualityOperatorIdentifierStringIsCalled
{
    private const string Alternative = "Other";
    private const string Value = "Value";

    [Test]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Identifier? left = default;
        string? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Identifier? left = default;
        string right = Value;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Identifier left = Value;
        string? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Identifier first = Value;
        string second = first;

        // Act
        bool result = first == second;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Identifier left = Value;
        string right = Value;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Identifier left = Value;
        string right = Alternative;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}