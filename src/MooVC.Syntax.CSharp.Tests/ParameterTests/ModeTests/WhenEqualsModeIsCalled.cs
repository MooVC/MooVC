namespace MooVC.Syntax.CSharp.ParameterTests.ModeTests;

public sealed class WhenEqualsModeIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Parameter.Mode left = Parameter.Mode.In;
        Parameter.Mode right = Parameter.Mode.RefReadonly;

        // Act
        bool resultLeftRight = left.Equals(right);
        bool resultRightLeft = right.Equals(left);

        // Assert
        _ = await Assert.That(resultLeftRight).IsFalse();
        _ = await Assert.That(resultRightLeft).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Parameter.Mode left = Parameter.Mode.In;
        Parameter.Mode right = Parameter.Mode.In;

        // Act
        bool resultLeftRight = left.Equals(right);
        bool resultRightLeft = right.Equals(left);

        // Assert
        _ = await Assert.That(resultLeftRight).IsTrue();
        _ = await Assert.That(resultRightLeft).IsTrue();
    }
}