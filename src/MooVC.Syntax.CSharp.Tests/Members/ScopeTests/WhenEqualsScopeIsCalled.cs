namespace MooVC.Syntax.CSharp.Members.ScopeTests;

public sealed class WhenEqualsScopeIsCalled
{
    private const string Same = "internal";

    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Scope subject = Same;
        Scope? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Scope subject = Same;
        Scope other = subject;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Scope left = Same;
        Scope right = Same;

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Scope left = Same;
        Scope right = "public";

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeFalse();
    }
}