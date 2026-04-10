namespace MooVC.Syntax.CSharp.ResultTests;

public sealed class WhenEqualityOperatorResultResultIsCalled
{
    [Test]
    public async Task GivenDifferentResultsThenReturnsFalse()
    {
        // Arrange
        Result left = ResultTestsData.Create();
        Result right = ResultTestsData.Create(modifier: Result.Modifiers.Ref);

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEquivalentResultsThenReturnsTrue()
    {
        // Arrange
        Result left = ResultTestsData.Create();
        Result right = ResultTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}