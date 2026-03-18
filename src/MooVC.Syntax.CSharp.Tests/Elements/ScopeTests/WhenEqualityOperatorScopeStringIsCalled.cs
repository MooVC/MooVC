namespace MooVC.Syntax.CSharp.Elements.ScopeTests;

public sealed class WhenEqualityOperatorScopeStringIsCalled
{
    private const string Same = "internal";
    private const string Different = "public";

    [Test]
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

    [Test]
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

    [Test]
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

    [Test]
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

    [Test]
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