namespace MooVC.Syntax.CSharp.Elements.ResultTests;

public sealed class WhenInequalityOperatorResultResultIsCalled
{
    [Test]
    public void GivenEquivalentResultsThenReturnsFalse()
    {
        // Arrange
        Result left = ResultTestsData.Create();
        Result right = ResultTestsData.Create();

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenDifferentResultsThenReturnsTrue()
    {
        // Arrange
        Result left = ResultTestsData.Create();
        Result right = ResultTestsData.Create(mode: Result.Modality.Synchronous);

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}