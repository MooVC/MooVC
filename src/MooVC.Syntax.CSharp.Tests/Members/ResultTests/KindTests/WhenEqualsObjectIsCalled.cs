namespace MooVC.Syntax.CSharp.Members.ResultTests.KindTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenEqualsObjectIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Result.Kind subject = Result.Kind.Unsafe;
        object? comparison = default;

        // Act
        bool result = subject.Equals(comparison);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentTypeThenReturnsFalse()
    {
        // Arrange
        Result.Kind subject = Result.Kind.Unsafe;
        object comparison = string.Empty;

        // Act
        bool result = subject.Equals(comparison);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValueThenReturnsTrue()
    {
        // Arrange
        Result.Kind subject = Result.Kind.Unsafe;
        object comparison = Result.Kind.Unsafe;

        // Act
        bool result = subject.Equals(comparison);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValueThenReturnsFalse()
    {
        // Arrange
        Result.Kind subject = Result.Kind.Unsafe;
        object comparison = Result.Kind.Ref;

        // Act
        bool result = subject.Equals(comparison);

        // Assert
        result.ShouldBeFalse();
    }
}
