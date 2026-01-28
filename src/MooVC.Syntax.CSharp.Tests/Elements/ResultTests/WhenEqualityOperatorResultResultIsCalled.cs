namespace MooVC.Syntax.CSharp.Elements.ResultTests;

public sealed class WhenEqualityOperatorResultResultIsCalled
{
    [Fact]
    public void GivenEquivalentResultsThenReturnsTrue()
    {
        // Arrange
        Result left = ResultTestsData.Create();
        Result right = ResultTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentResultsThenReturnsFalse()
    {
        // Arrange
        Result left = ResultTestsData.Create();
        Result right = ResultTestsData.Create(modifier: Result.Kind.Ref);

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}