namespace MooVC.Syntax.CSharp.ArgumentTests.ModesTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenDifferentTypeThenReturnsFalse()
    {
        // Arrange
        Argument.Modes left = Argument.Modes.Out;
        object right = "out";

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Argument.Modes left = Argument.Modes.Out;
        object right = Argument.Modes.Ref;

        // Act
        bool resultLeftRight = left.Equals(right);
        bool resultRightLeft = ((Argument.Modes)right).Equals(left);

        // Assert
        _ = await Assert.That(resultLeftRight).IsFalse();
        _ = await Assert.That(resultRightLeft).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Argument.Modes left = Argument.Modes.Out;
        object right = Argument.Modes.Out;

        // Act
        bool resultLeftRight = left.Equals(right);
        bool resultRightLeft = ((Argument.Modes)right).Equals(left);

        // Assert
        _ = await Assert.That(resultLeftRight).IsTrue();
        _ = await Assert.That(resultRightLeft).IsTrue();
    }

    [Test]
    public async Task GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Argument.Modes left = Argument.Modes.In;
        object? right = default;

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Argument.Modes first = Argument.Modes.In;
        object second = first;

        // Act
        bool result = first.Equals(second);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}