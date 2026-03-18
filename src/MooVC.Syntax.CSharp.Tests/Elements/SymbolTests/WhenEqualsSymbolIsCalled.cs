namespace MooVC.Syntax.CSharp.Elements.SymbolTests;

public sealed class WhenEqualsSymbolIsCalled
{
    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        Symbol subject = SymbolTestsData.Create();
        Symbol? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Symbol subject = SymbolTestsData.CreateWithArgumentNames(argumentNames: "Inner");
        Symbol other = subject;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Symbol left = SymbolTestsData.CreateWithArgumentNames(argumentNames: "Inner");
        Symbol right = SymbolTestsData.CreateWithArgumentNames(argumentNames: "Inner");

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentArgumentsThenReturnsFalse()
    {
        // Arrange
        Symbol left = SymbolTestsData.CreateWithArgumentNames(argumentNames: "Inner");
        Symbol right = SymbolTestsData.CreateWithArgumentNames(argumentNames: "Other");

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}