namespace MooVC.Syntax.CSharp.Elements.ParameterTests.OptionsTests;

public sealed class WhenEqualsOptionsIsCalled
{
    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Parameter.Options();
        var right = new Parameter.Options();

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
        var left = new Parameter.Options();
        var right = new Parameter.Options();

        // Act
        bool resultLeftRight = left.Equals(right.WithNaming(Variable.Options.Pascal));
        bool resultRightLeft = right.WithNaming(Variable.Options.Pascal).Equals(left);

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }
}