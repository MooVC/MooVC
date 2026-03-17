namespace MooVC.Syntax.CSharp.Elements.SymbolTests;

public sealed class WhenEqualsSymbolIsCalled
{
    [Test]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Symbol subject = SymbolTestsData.Create();
        Symbol? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Symbol subject = SymbolTestsData.CreateWithArgumentNames(argumentNames: "Inner");
        Symbol other = subject;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Symbol left = SymbolTestsData.CreateWithArgumentNames(argumentNames: "Inner");
        Symbol right = SymbolTestsData.CreateWithArgumentNames(argumentNames: "Inner");

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentArgumentsThenReturnsFalse()
    {
        // Arrange
        Symbol left = SymbolTestsData.CreateWithArgumentNames(argumentNames: "Inner");
        Symbol right = SymbolTestsData.CreateWithArgumentNames(argumentNames: "Other");

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeFalse();
    }
}