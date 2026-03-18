namespace MooVC.Syntax.CSharp.Members.DeclarationTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenEqualValuesThenHashesMatch()
    {
        // Arrange
        Declaration left = DeclarationTestsData.Create(parameterNames: "T");
        Declaration right = DeclarationTestsData.Create(parameterNames: "T");

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        _ = await Assert.That(leftHash).IsEqualTo(rightHash);
    }

    [Test]
    public async Task GivenDifferentValuesThenHashesDiffer()
    {
        // Arrange
        Declaration left = DeclarationTestsData.Create();
        Declaration right = DeclarationTestsData.Create("Alternative", "T");

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        _ = await Assert.That(leftHash).IsNotEqualTo(rightHash);
    }
}