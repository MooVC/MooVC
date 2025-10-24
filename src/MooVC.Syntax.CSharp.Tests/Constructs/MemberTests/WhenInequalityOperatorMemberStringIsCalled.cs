namespace MooVC.Syntax.CSharp.Constructs.MemberTests;

public sealed class WhenInequalityOperatorMemberStringIsCalled
{
    private const string Same = "Alpha";
    private const string Different = "Beta";

    [Fact]
    public void GivenBothNullWhenComparedThenFalse()
    {
        // Arrange
        Member? left = default;
        string? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftNullRightValueWhenComparedThenTrue()
    {
        // Arrange
        Member? left = default;
        string right = Same;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLeftValueRightNullWhenComparedThenTrue()
    {
        // Arrange
        var left = new Member(Same);
        string? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesWhenComparedThenFalse()
    {
        // Arrange
        var left = new Member(Same);
        string right = Same;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentValuesWhenComparedThenTrue()
    {
        // Arrange
        var left = new Member(Same);
        string right = Different;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}