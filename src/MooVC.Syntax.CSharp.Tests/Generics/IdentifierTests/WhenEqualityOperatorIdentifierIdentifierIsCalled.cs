namespace MooVC.Syntax.CSharp.Generics.IdentifierTests;

public sealed class WhenEqualityOperatorIdentifierIdentifierIsCalled
{
    private const string Alternative = "Other";
    private const string Value = "Value";

    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Identifier? left = default;
        Identifier? right = default;

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
        Identifier right = Value;

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
        Identifier? right = default;

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
        Identifier second = first;

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
        Identifier right = Value;

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
        Identifier right = Alternative;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}