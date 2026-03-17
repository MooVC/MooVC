namespace MooVC.Syntax.CSharp.Elements.SymbolTests;

public sealed class WhenInequalityOperatorSymbolSymbolIsCalled
{
    [Test]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Symbol? left = default;
        Symbol? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Symbol? left = default;
        Symbol right = SymbolTestsData.Create();

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        Symbol left = SymbolTestsData.Create();
        Symbol? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Symbol left = SymbolTestsData.Create();
        Symbol right = SymbolTestsData.Create();

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }

    [Test]
    public void GivenDifferentNamesThenReturnsTrue()
    {
        // Arrange
        Symbol left = SymbolTestsData.Create();
        Symbol right = SymbolTestsData.Create("Alternate");

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}