namespace MooVC.Syntax.CSharp.Elements.SymbolTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Symbol subject = SymbolTestsData.Create();
        object? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Symbol subject = SymbolTestsData.Create();
        object other = subject;

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
        object right = SymbolTestsData.CreateWithArgumentNames(argumentNames: "Inner");

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Symbol left = SymbolTestsData.CreateWithArgumentNames(argumentNames: "Inner");
        object right = SymbolTestsData.CreateWithArgumentNames(argumentNames: "Other");

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenNonSymbolThenReturnsFalse()
    {
        // Arrange
        Symbol subject = SymbolTestsData.Create();
        object other = SymbolTestsData.DefaultName;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}