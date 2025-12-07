namespace MooVC.Syntax.CSharp.Members.ResultTests.KindTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenEqualityOperatorKindStringIsCalled
{
    private const string Same = "ref";
    private const string Different = "unsafe";

    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Result.Kind? left = default;
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
        Result.Kind? left = default;
        const string right = Same;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Result.Kind left = Result.Kind.Ref;
        string? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Result.Kind left = Result.Kind.Ref;
        const string right = Same;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Result.Kind left = Result.Kind.Ref;
        const string right = Different;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}
