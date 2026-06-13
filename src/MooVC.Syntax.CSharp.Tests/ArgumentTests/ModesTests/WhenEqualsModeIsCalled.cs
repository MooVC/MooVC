namespace MooVC.Syntax.CSharp.ArgumentTests.ModesTests;

public sealed class WhenEqualsModeIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Argument.Modes left = Argument.Modes.Ref;
        Argument.Modes right = Argument.Modes.Out;

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
        Argument.Modes left = Argument.Modes.Ref;
        Argument.Modes right = Argument.Modes.Ref;

        // Act
        bool resultLeftRight = left.Equals(right);
        bool resultRightLeft = right.Equals(left);

        // Assert
        _ = await Assert.That(resultLeftRight).IsTrue();
        _ = await Assert.That(resultRightLeft).IsTrue();
    }
}