namespace MooVC.Syntax.CSharp.Members.IdentifierTests.OptionsTests;

public sealed class WhenEqualityOperatorOptionsOptionsIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Identifier.Options? left = default;
        Identifier.Options? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Identifier.Options? left = default;
        var right = new Identifier.Options();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Identifier.Options();
        var right = new Identifier.Options();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Identifier.Options();
        var right = new Identifier.Options { UseUnderscores = true };

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}