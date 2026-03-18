namespace MooVC.Syntax.CSharp.ParameterTests.OptionsTests;

public sealed class WhenEqualsOptionsIsCalled
{
    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Parameter.Options();
        var right = new Parameter.Options();

        // Act
        bool resultLeftRight = left.Equals(right);
        bool resultRightLeft = right.Equals(left);

        // Assert
        _ = await Assert.That(resultLeftRight).IsTrue();
        _ = await Assert.That(resultRightLeft).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Parameter.Options();
        var right = new Parameter.Options();

        // Act
        bool resultLeftRight = left.Equals(right.WithNaming(Variable.Options.Pascal));
        bool resultRightLeft = right.WithNaming(Variable.Options.Pascal).Equals(left);

        // Assert
        _ = await Assert.That(resultLeftRight).IsFalse();
        _ = await Assert.That(resultRightLeft).IsFalse();
    }
}