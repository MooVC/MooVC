namespace MooVC.Syntax.CSharp.GenericTests;

using MooVC.Syntax.CSharp.SymbolTests;

public sealed class WhenInequalityOperatorArgumentArgumentIsCalled
{
    private const string DefaultName = "TValue";

    [Test]
    public async Task GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Generic? left = default;
        Generic? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Generic left = Create();
        Generic right = Create(name: DefaultName + "Alt");

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
        Generic left = Create();
        Generic right = Create();

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Generic? left = default;
        Generic right = Create();

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        Generic left = Create();
        Generic? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    private static Generic Create(string name = DefaultName)
    {
        return new Generic
        {
            Name = new(name),
            Constraints = [new() { Base = new(SymbolTestsData.CreateWithArgumentNames()) }],
        };
    }
}