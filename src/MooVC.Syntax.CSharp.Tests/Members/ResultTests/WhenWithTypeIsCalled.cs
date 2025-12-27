namespace MooVC.Syntax.CSharp.Members.ResultTests;

public sealed class WhenWithTypeIsCalled
{
    [Fact]
    public void GivenTypeThenReturnsUpdatedInstance()
    {
        // Arrange
        Result original = ResultTestsData.Create();
        var type = new Symbol { Name = new Identifier("Updated") };

        // Act
        Result result = original.WithType(type);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Type.ShouldBe(type);
        result.Modifier.ShouldBe(original.Modifier);
        result.Mode.ShouldBe(original.Mode);
        original.Type.Name.ShouldBe(new Identifier(ResultTestsData.DefaultTypeName));
    }
}