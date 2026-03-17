namespace MooVC.Syntax.CSharp.Elements.ScopeTests;

public sealed class WhenInequalityOperatorScopeStringIsCalled
{
    private const string Same = "internal";
    private const string Different = "public";

    [Test]
    public void GivenSubjectNullValueNullThenReturnsFalse()
    {
        // Arrange
        Scope? left = default;
        string? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenSubjectNullValueThenReturnsTrue()
    {
        // Arrange
        Scope? left = default;
        string right = Same;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenSubjectValueValueNullThenReturnsTrue()
    {
        // Arrange
        Scope left = Same;
        string? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Scope left = Same;
        string right = Same;

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Scope left = Same;
        string right = Different;

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }
}