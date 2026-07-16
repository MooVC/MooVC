namespace MooVC.Syntax.CSharp.BaseTests;

public sealed class WhenEqualityOperatorBaseBaseIsCalled
{
    [Test]
    public async Task GivenEquivalentValuesThenReturnsTrue()
    {
        // Arrange
        Base left = BaseTestsData.Create();
        Base right = BaseTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}