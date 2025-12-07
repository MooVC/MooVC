namespace MooVC.Syntax.CSharp.Members.ResultTests.KindTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenEqualsKindIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Result.Kind? subject = default;
        Result.Kind target = Result.Kind.Unsafe;

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Result.Kind subject = Result.Kind.Unsafe;
        Result.Kind target = subject;

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Result.Kind subject = Result.Kind.Unsafe;
        Result.Kind target = Result.Kind.Unsafe;

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Result.Kind subject = Result.Kind.Unsafe;
        Result.Kind target = Result.Kind.Ref;

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeFalse();
    }
}
