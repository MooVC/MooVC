namespace MooVC.Syntax.CSharp.Members.ScopeTests;

public sealed class WhenEqualityOperatorScopeStringIsCalled
{
    private const string Same = "internal";
    private const string Different = "public";

    [Fact]
    public void GivenSubjectNullValueNullThenReturnsTrue()
    {
        // Arrange
        Scope? left = default;
        string? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenSubjectNullValueThenReturnsFalse()
    {
        // Arrange
        Scope? left = default;
        string right = Same;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenSubjectValueValueNullThenReturnsFalse()
    {
        // Arrange
        Scope left = Same;
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
        Scope left = Same;
        string right = Same;

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Scope left = Same;
        string right = Different;

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }
}