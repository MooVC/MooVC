namespace MooVC.Syntax.CSharp.BaseTests;

public sealed class WhenInequalityOperatorBaseBaseIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Base left = BaseTestsData.Create(name: (Qualification)"Comparable");
        Base right = BaseTestsData.Create(name: (Qualification)"IComparable");

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}