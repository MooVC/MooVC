namespace MooVC.Syntax.CSharp.ResultTests;

public sealed class WhenInequalityOperatorResultResultIsCalled
{
    [Test]
    public async Task GivenDifferentResultsThenReturnsTrue()
    {
        // Arrange
        Result left = ResultTestsData.Create();
        Result right = ResultTestsData.Create(mode: Result.Modality.Synchronous);

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEquivalentResultsThenReturnsFalse()
    {
        // Arrange
        Result left = ResultTestsData.Create();
        Result right = ResultTestsData.Create();

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}