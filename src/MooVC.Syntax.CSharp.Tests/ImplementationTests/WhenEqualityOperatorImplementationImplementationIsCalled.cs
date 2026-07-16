namespace MooVC.Syntax.CSharp.ImplementationTests;

public sealed class WhenEqualityOperatorImplementationImplementationIsCalled
{
    [Test]
    public async Task GivenEquivalentValuesThenReturnsTrue()
    {
        // Arrange
        Implementation left = ImplementationTestsData.Create();
        Implementation right = ImplementationTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}