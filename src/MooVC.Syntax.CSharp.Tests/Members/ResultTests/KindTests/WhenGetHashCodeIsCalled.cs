namespace MooVC.Syntax.CSharp.Members.ResultTests.KindTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
    public void GivenEqualValuesThenCodesMatch()
    {
        // Arrange
        Result.Kind left = Result.Kind.Ref;
        Result.Kind right = Result.Kind.Ref;

        // Act
        int leftCode = left.GetHashCode();
        int rightCode = right.GetHashCode();

        // Assert
        leftCode.ShouldBe(rightCode);
    }

    [Fact]
    public void GivenDifferentValuesThenCodesDiffer()
    {
        // Arrange
        Result.Kind left = Result.Kind.Ref;
        Result.Kind right = Result.Kind.Unsafe;

        // Act
        int leftCode = left.GetHashCode();
        int rightCode = right.GetHashCode();

        // Assert
        leftCode.ShouldNotBe(rightCode);
    }
}
