namespace MooVC.Syntax.CSharp.BaseTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenEquivalentValuesThenHashCodesMatch()
    {
        // Arrange
        Base left = BaseTestsData.Create();
        Base right = BaseTestsData.Create();

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        _ = await Assert.That(leftHash).IsEqualTo(rightHash);
    }
}