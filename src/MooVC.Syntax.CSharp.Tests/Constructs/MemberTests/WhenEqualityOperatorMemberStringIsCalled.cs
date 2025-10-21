namespace MooVC.Syntax.CSharp.Constructs.MemberTests;

public sealed class WhenEqualityOperatorMemberStringIsCalled
{
    private const string Same = "Alpha";
    private const string Different = "Beta";

    [Fact]
    public void GivenBothNullWhenComparedThenTrue()
    {
        // Arrange
        Member? left = default;
        string? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLeftNullRightValueWhenComparedThenFalse()
    {
        // Arrange
        Member? left = default;
        string right = Same;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftValueRightNullWhenComparedThenFalse()
    {
        // Arrange
        var left = new Member(Same);
        string? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesWhenComparedThenTrue()
    {
        // Arrange
        var left = new Member(Same);
        string right = Same;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesWhenComparedThenFalse()
    {
        // Arrange
        var left = new Member(Same);
        string right = Different;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}