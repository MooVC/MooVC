namespace MooVC.Syntax.CSharp.Elements.ArgumentTests.ModeTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Argument.Mode left = Argument.Mode.In;
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
        Argument.Mode first = Argument.Mode.In;
        object second = first;

        // Act
        bool result = first.Equals(second);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Argument.Mode left = Argument.Mode.Out;
        object right = Argument.Mode.Out;

        // Act
        bool resultLeftRight = left.Equals(right);
        bool resultRightLeft = ((Argument.Mode)right).Equals(left);

        // Assert
        _ = await Assert.That(resultLeftRight).IsTrue();
        _ = await Assert.That(resultRightLeft).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Argument.Mode left = Argument.Mode.Out;
        object right = Argument.Mode.Ref;

        // Act
        bool resultLeftRight = left.Equals(right);
        bool resultRightLeft = ((Argument.Mode)right).Equals(left);

        // Assert
        _ = await Assert.That(resultLeftRight).IsFalse();
        _ = await Assert.That(resultRightLeft).IsFalse();
    }

    [Test]
    public async Task GivenDifferentTypeThenReturnsFalse()
    {
        // Arrange
        Argument.Mode left = Argument.Mode.Out;
        object right = "out";

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}