namespace MooVC.Syntax.CSharp.Concepts.StructTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
    public void GivenEqualValuesThenReturnsSameHash()
    {
        // Arrange
        Struct left = StructTestsData.Create(scope: Scope.Internal);
        Struct right = StructTestsData.Create(scope: Scope.Internal);

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        rightHash.ShouldBe(leftHash);
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsDifferentHashes()
    {
        // Arrange
        Struct left = StructTestsData.Create(behavior: Struct.Kind.ReadOnly);
        Struct right = StructTestsData.Create(behavior: Struct.Kind.Record);

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        rightHash.ShouldNotBe(leftHash);
    }
}