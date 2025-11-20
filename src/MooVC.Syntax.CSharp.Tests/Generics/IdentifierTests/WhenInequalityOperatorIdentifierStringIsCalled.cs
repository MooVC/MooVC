namespace MooVC.Syntax.CSharp.Generics.IdentifierTests;

public sealed class WhenInequalityOperatorIdentifierStringIsCalled
{
    private const string Alternative = "Other";
    private const string Value = "Value";

    [Fact]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Identifier? left = default;
        string? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Identifier? left = default;
        string right = Value;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        Identifier left = Value;
        string? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsFalse()
    {
        // Arrange
        Identifier first = Value;
        string second = first;

        // Act
        bool result = first != second;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Identifier left = Value;
        string right = Value;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Identifier left = Value;
        string right = Alternative;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}
