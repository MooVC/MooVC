namespace MooVC.Syntax.CSharp.Concepts.ClassTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
    public void GivenEqualValuesThenHashesMatch()
    {
        // Arrange
        Class left = ClassTestsData.Create(extensibility: Extensibility.Implicit);
        Class right = ClassTestsData.Create(extensibility: Extensibility.Implicit);

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
        Class left = ClassTestsData.Create(scope: Scope.Internal);
        Class right = ClassTestsData.Create(scope: Scope.Private);

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldNotBe(rightHash);
    }
}