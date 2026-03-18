namespace MooVC.Syntax.CSharp.Elements.ResultTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenEqualResultsThenHashCodesAreEqual()
    {
        // Arrange
        Result first = ResultTestsData.Create();
        Result second = ResultTestsData.Create();

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsEqualTo(secondHash);
    }

    [Test]
    public async Task GivenDifferentResultsThenHashCodesDiffer()
    {
        // Arrange
        Result first = ResultTestsData.Create();
        Result second = ResultTestsData.Create(modifier: Result.Kind.Ref);

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsNotEqualTo(secondHash);
    }
}