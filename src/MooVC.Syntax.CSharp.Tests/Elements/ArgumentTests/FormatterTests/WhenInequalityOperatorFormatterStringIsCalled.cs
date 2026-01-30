namespace MooVC.Syntax.CSharp.Elements.ArgumentTests.FormatterTests;

public sealed class WhenInequalityOperatorFormatterStringIsCalled
{
    private const string Same = "{0}: {1}";
    private const string Different = "{0} = {1}";

    [Fact]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Argument.Formatter? left = default;
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
        Argument.Formatter? left = default;
        const string right = Same;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        Argument.Formatter left = Argument.Formatter.Call;
        string? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Argument.Formatter left = Argument.Formatter.Call;
        const string right = Same;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Argument.Formatter left = Argument.Formatter.Call;
        const string right = Different;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}