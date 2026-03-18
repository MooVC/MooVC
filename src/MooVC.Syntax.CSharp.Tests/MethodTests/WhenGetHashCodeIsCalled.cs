namespace MooVC.Syntax.CSharp.MethodTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenEqualMethodsThenHashCodesAreEqual()
    {
        // Arrange
        Method first = MethodTestsData.Create();
        Method second = MethodTestsData.Create();

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsEqualTo(secondHash);
    }

    [Test]
    public async Task GivenDifferentMethodsThenHashCodesAreDifferent()
    {
        // Arrange
        Method first = MethodTestsData.Create();
        Method second = MethodTestsData.Create(body: Snippet.From("return other;"));

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsNotEqualTo(secondHash);
    }
}