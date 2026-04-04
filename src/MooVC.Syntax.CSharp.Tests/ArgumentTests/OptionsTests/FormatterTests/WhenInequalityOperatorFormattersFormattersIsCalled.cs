namespace MooVC.Syntax.CSharp.ArgumentTests.OptionsTests.FormattersTests;

public sealed class WhenInequalityOperatorFormattersFormattersIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Argument.Options.Formatters? left = default;
        Argument.Options.Formatters? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Argument.Options.Formatters left = Argument.Options.Formatters.Call;
        Argument.Options.Formatters right = Argument.Options.Formatters.Declaration;

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
        Argument.Options.Formatters left = Argument.Options.Formatters.Call;
        Argument.Options.Formatters right = Argument.Options.Formatters.Call;

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
        Argument.Options.Formatters? left = default;
        Argument.Options.Formatters right = Argument.Options.Formatters.Call;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        Argument.Options.Formatters left = Argument.Options.Formatters.Call;
        Argument.Options.Formatters? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsFalse()
    {
        // Arrange
        Argument.Options.Formatters first = Argument.Options.Formatters.Declaration;
        Argument.Options.Formatters second = first;

        // Act
        bool result = first != second;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}