namespace MooVC.Syntax.CSharp.Elements.IdentifierTests;

using Shouldly;
using Xunit;

public sealed class WhenEqualsStringIsCalled
{
    private const string Same = "Alpha";
    private const string Different = "Beta";

    [Fact]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        var left = new Identifier(Same);
        string? right = default;

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Identifier(Same);
        string right = Same;

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Identifier(Same);
        string right = Different;

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeFalse();
    }
}