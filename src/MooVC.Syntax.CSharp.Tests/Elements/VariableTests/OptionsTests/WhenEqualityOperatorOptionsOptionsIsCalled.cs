namespace MooVC.Syntax.CSharp.Elements.VariableTests.OptionsTests;

public sealed class WhenEqualityOperatorOptionsOptionsIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Variable.Options? left = default;
        Variable.Options? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Variable.Options? left = default;
        var right = new Variable.Options();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Variable.Options();
        var right = new Variable.Options();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Variable.Options();
        var right = new Variable.Options { UseUnderscore = true };

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}