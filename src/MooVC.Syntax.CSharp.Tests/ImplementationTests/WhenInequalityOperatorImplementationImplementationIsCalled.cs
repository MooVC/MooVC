namespace MooVC.Syntax.CSharp.ImplementationTests;

public sealed class WhenInequalityOperatorImplementationImplementationIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Implementation left = ImplementationTestsData.Create(name: (Qualification)"IComparable");
        Implementation right = ImplementationTestsData.Create(name: (Qualification)"IDisposable");

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}