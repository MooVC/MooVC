namespace MooVC.Syntax.CSharp.Elements.ScopeTests;

public sealed class WhenEqualsObjectIsCalled
{
    private const string Same = "internal";
    private const string Different = "public";

    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Scope subject = Same;
        object? other = default;

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
        object other = subject;

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
        object right = (Scope)Same;

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
        object right = (Scope)Different;

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenNonScopeThenReturnsFalse()
    {
        // Arrange
        Scope subject = Same;
        object other = Same;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}