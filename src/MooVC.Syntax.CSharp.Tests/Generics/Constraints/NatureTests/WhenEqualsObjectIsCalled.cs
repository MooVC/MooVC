namespace MooVC.Syntax.CSharp.Generics.Constraints.NatureTests;

public sealed class WhenEqualsObjectIsCalled
{
    private const string Same = "class";
    private const string Different = "struct";

    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Nature subject = Same;
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
        Nature subject = Same;
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
        Nature left = Same;
        object right = (Nature)Same;

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Nature left = Same;
        object right = (Nature)Different;

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenNonNatureThenReturnsFalse()
    {
        // Arrange
        Nature subject = Same;
        object other = Same;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}