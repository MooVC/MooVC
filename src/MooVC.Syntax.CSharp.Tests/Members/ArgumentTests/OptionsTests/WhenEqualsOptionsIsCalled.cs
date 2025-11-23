namespace MooVC.Syntax.CSharp.Members.ArgumentTests.OptionsTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenEqualsOptionsIsCalled
{
    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Argument.Options();
        var right = new Argument.Options();

        // Act
        bool resultLeftRight = left.Equals(right);
        bool resultRightLeft = right.Equals(left);

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Argument.Options();

        Argument.Options right = new Argument.Options()
            .WithNaming(Identifier.Options.Pascal);

        // Act
        bool resultLeftRight = left.Equals(right);
        bool resultRightLeft = right.Equals(left);

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }
}
