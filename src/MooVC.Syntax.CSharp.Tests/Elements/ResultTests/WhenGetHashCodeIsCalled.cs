namespace MooVC.Syntax.CSharp.Elements.ResultTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public void GivenEqualResultsThenHashCodesAreEqual()
    {
        // Arrange
        Result first = ResultTestsData.Create();
        Result second = ResultTestsData.Create();

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldBe(secondHash);
    }

    [Test]
    public void GivenDifferentResultsThenHashCodesDiffer()
    {
        // Arrange
        Result first = ResultTestsData.Create();
        Result second = ResultTestsData.Create(modifier: Result.Kind.Ref);

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }
}