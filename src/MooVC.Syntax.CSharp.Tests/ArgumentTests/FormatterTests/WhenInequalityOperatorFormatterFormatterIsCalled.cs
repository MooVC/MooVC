namespace MooVC.Syntax.CSharp.ArgumentTests.FormatterTests;

public sealed class WhenInequalityOperatorFormatterFormatterIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Argument.Formatter? left = default;
        Argument.Formatter? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Argument.Formatter left = Argument.Formatter.Call;
        Argument.Formatter right = Argument.Formatter.Declaration;

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsTrue();
        _ = await Assert.That(resultRightLeft).IsTrue();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Argument.Formatter left = Argument.Formatter.Call;
        Argument.Formatter right = Argument.Formatter.Call;

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsFalse();
        _ = await Assert.That(resultRightLeft).IsFalse();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Argument.Formatter? left = default;
        Argument.Formatter right = Argument.Formatter.Call;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        Argument.Formatter left = Argument.Formatter.Call;
        Argument.Formatter? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsFalse()
    {
        // Arrange
        Argument.Formatter first = Argument.Formatter.Declaration;
        Argument.Formatter second = first;

        // Act
        bool result = first != second;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}