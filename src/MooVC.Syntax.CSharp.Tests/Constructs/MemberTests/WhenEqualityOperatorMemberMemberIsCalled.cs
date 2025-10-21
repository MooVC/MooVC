namespace MooVC.Syntax.CSharp.Constructs.MemberTests;

public sealed class WhenEqualityOperatorMemberMemberIsCalled
{
    private const string Same = "Alpha";
    private const string Different = "Beta";

    [Fact]
    public void GivenBothNullWhenComparedThenTrue()
    {
        // Arrange
        Member? left = default;
        Member? right = default;

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
        var right = new Member(Same);

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
        Member? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenSameReferenceWhenComparedThenTrue()
    {
        // Arrange
        var first = new Member(Same);
        Member second = first;

        // Act
        bool result = first == second;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesWhenComparedThenTrue()
    {
        // Arrange
        var left = new Member(Same);
        var right = new Member(Same);

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesWhenComparedThenFalse()
    {
        // Arrange
        var left = new Member(Same);
        var right = new Member(Different);

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }
}