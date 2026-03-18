namespace MooVC.Syntax.CSharp.Elements.SymbolTests;

public sealed class WhenEqualityOperatorSymbolSymbolIsCalled
{
    private const string AlternativeName = "Alternate";
    private static readonly string[] arguments = ["Inner", "Outer"];

    [Test]
    public async Task GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Symbol? left = default;
        Symbol? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Symbol? left = default;
        Symbol right = SymbolTestsData.CreateWithArgumentNames(argumentNames: arguments);

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Symbol left = SymbolTestsData.CreateWithArgumentNames(argumentNames: arguments);
        Symbol? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Symbol first = SymbolTestsData.CreateWithArgumentNames(argumentNames: arguments);
        Symbol second = first;

        // Act
        bool result = first == second;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Symbol left = SymbolTestsData.CreateWithArgumentNames(argumentNames: arguments);
        Symbol right = SymbolTestsData.CreateWithArgumentNames(argumentNames: arguments);

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsTrue();
        _ = await Assert.That(resultRightLeft).IsTrue();
    }

    [Test]
    public async Task GivenDifferentNamesThenReturnsFalse()
    {
        // Arrange
        Symbol left = SymbolTestsData.CreateWithArgumentNames(argumentNames: arguments);
        Symbol right = SymbolTestsData.CreateWithArgumentNames(AlternativeName, arguments);

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentArgumentsThenReturnsFalse()
    {
        // Arrange
        Symbol left = SymbolTestsData.CreateWithArgumentNames(argumentNames: arguments);
        Symbol right = SymbolTestsData.CreateWithArgumentNames(argumentNames: arguments[0]);

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsFalse();
        _ = await Assert.That(resultRightLeft).IsFalse();
    }
}