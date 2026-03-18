namespace MooVC.Syntax.CSharp.Members.ConstructorTests;

using MooVC.Syntax.Elements;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenEqualConstructorsThenHashCodesAreEqual()
    {
        // Arrange
        Constructor first = ConstructorTestsData.Create();
        Constructor second = ConstructorTestsData.Create();

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsEqualTo(secondHash);
    }

    [Test]
    public async Task GivenDifferentConstructorsThenHashCodesAreDifferent()
    {
        // Arrange
        Constructor first = ConstructorTestsData.Create();
        Constructor second = ConstructorTestsData.Create(body: Snippet.From("Shutdown();"));

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsNotEqualTo(secondHash);
    }
}