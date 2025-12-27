namespace MooVC.Syntax.CSharp.Members.ResultTests;

public sealed class WhenInequalityOperatorResultResultIsCalled
{
    [Fact]
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

    [Fact]
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