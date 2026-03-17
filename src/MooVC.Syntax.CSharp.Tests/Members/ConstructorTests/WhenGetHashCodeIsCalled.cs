namespace MooVC.Syntax.CSharp.Members.ConstructorTests;

using MooVC.Syntax.Elements;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public void GivenEqualConstructorsThenHashCodesAreEqual()
    {
        // Arrange
        Constructor first = ConstructorTestsData.Create();
        Constructor second = ConstructorTestsData.Create();

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldBe(secondHash);
    }

    [Test]
    public void GivenDifferentConstructorsThenHashCodesAreDifferent()
    {
        // Arrange
        Constructor first = ConstructorTestsData.Create();
        Constructor second = ConstructorTestsData.Create(body: Snippet.From("Shutdown();"));

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }
}