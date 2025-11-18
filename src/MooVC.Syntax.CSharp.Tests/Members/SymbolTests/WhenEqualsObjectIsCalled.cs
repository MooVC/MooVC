namespace MooVC.Syntax.CSharp.Members.SymbolTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Fact]
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

    [Fact]
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

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Symbol left = SymbolTestsData.CreateWithArgumentNames(argumentNames: new[] { "Inner" });
        object right = SymbolTestsData.CreateWithArgumentNames(argumentNames: new[] { "Inner" });

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Symbol left = SymbolTestsData.CreateWithArgumentNames(argumentNames: new[] { "Inner" });
        object right = SymbolTestsData.CreateWithArgumentNames(argumentNames: new[] { "Other" });

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
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
