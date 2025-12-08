namespace MooVC.Syntax.CSharp.Members.MethodTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
    public void GivenEqualMethodsThenHashCodesAreEqual()
    {
        // Arrange
        Method first = MethodTestsData.Create();
        Method second = MethodTestsData.Create();

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldBe(secondHash);
    }

    [Fact]
    public void GivenDifferentMethodsThenHashCodesAreDifferent()
    {
        // Arrange
        Method first = MethodTestsData.Create();
        Method second = MethodTestsData.Create(body: Snippet.From("return other;"));

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }
}
