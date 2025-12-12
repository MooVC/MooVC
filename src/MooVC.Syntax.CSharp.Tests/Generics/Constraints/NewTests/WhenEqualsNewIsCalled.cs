namespace MooVC.Syntax.CSharp.Generics.Constraints.NewTests;

public sealed class WhenEqualsNewIsCalled
{
    private const string Same = "new()";
    private const string Different = "";

    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        New subject = Same;
        New? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        New subject = Same;
        New other = subject;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        New left = Same;
        New right = Same;

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        New left = Same;
        New right = Different;

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeFalse();
    }
}