namespace MooVC.Syntax.CSharp.Concepts.InterfaceTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
    public void GivenEqualValuesThenHashesMatch()
    {
        // Arrange
        Interface left = InterfaceTestsData.Create(scope: Scope.Internal);
        Interface right = InterfaceTestsData.Create(scope: Scope.Internal);

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
        Interface left = InterfaceTestsData.Create(isPartial: true);
        Interface right = InterfaceTestsData.Create(isPartial: false);

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldNotBe(rightHash);
    }
}
