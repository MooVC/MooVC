namespace MooVC.Syntax.CSharp.Elements.ResultTests;

public sealed class WhenEqualityOperatorResultResultIsCalled
{
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

    [Test]
    public async Task GivenDifferentResultsThenReturnsFalse()
    {
        // Arrange
        Result left = ResultTestsData.Create();
        Result right = ResultTestsData.Create(modifier: Result.Kind.Ref);

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}