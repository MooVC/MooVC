namespace MooVC.Syntax.CSharp.Elements.ResultTests;

public sealed class WhenOfTypeIsCalled
{
    [Fact]
    public void GivenTypeThenReturnsUpdatedInstance()
    {
        // Arrange
        Result original = ResultTestsData.Create();
        var type = new Symbol { Name = new Variable("Updated") };

        // Act
        Result result = original.OfType(type);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Type.ShouldBe(type);
        result.Modifier.ShouldBe(original.Modifier);
        result.Mode.ShouldBe(original.Mode);
        original.Type.Name.ShouldBe(new Variable(ResultTestsData.DefaultTypeName));
    }
}