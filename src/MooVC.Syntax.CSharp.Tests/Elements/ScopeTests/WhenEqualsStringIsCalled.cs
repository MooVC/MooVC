namespace MooVC.Syntax.CSharp.Elements.ScopeTests;

public sealed class WhenEqualsStringIsCalled
{
    private const string Same = "internal";
    private const string Different = "public";

    [Test]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Scope left = Same;
        string? right = default;

        // Act
        bool result = left.Equals(right);

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
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Scope left = Same;
        string right = Different;

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeFalse();
    }
}