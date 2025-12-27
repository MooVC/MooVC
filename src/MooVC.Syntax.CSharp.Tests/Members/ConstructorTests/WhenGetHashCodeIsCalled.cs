namespace MooVC.Syntax.CSharp.Members.ConstructorTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
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

    [Fact]
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