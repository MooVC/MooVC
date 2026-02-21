namespace MooVC.Syntax.CSharp.Generics.IdentifierTests;

public sealed class WhenEqualityOperatorIdentifierStringIsCalled
{
    private const string Alternative = "Other";
    private const string Value = "Value";

    [Fact]
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

    [Fact]
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

    [Fact]
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

    [Fact]
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

    [Fact]
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

    [Fact]
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