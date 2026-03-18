namespace MooVC.Syntax.CSharp.Elements.ResultTests;

public sealed class WhenInequalityOperatorResultResultIsCalled
{
    [Test]
    public async Task GivenEquivalentResultsThenReturnsFalse()
    {
        // Arrange
        Result left = ResultTestsData.Create();
        Result right = ResultTestsData.Create();

        // Act
        bool result = left != right;

        // Assert
        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentResultsThenReturnsTrue()
    {
        // Arrange
        Result left = ResultTestsData.Create();
        Result right = ResultTestsData.Create(mode: Result.Modality.Synchronous);

        // Act
        bool result = left != right;

        // Assert
        await Assert.That(result).IsTrue();
    }
}