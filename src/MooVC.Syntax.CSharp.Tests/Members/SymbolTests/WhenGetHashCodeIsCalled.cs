namespace MooVC.Syntax.CSharp.Members.SymbolTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
    public void GivenEqualValuesThenHashesMatch()
    {
        // Arrange
        Symbol left = SymbolTestsData.CreateWithArgumentNames(argumentNames: "Inner");
        Symbol right = SymbolTestsData.CreateWithArgumentNames(argumentNames: "Inner");

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldBe(rightHash);
    }

    [Fact]
    public void GivenDifferentValuesThenHashesDiffer()
    {
        // Arrange
        Symbol left = SymbolTestsData.CreateWithArgumentNames(argumentNames: "Inner");
        Symbol right = SymbolTestsData.CreateWithArgumentNames("Alternate", "Inner");

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldNotBe(rightHash);
    }
}