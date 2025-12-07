namespace MooVC.Syntax.CSharp.Members.PropertyTests;

public sealed class WhenWithTypeIsCalled
{
    [Fact]
    public void GivenTypeThenReturnsUpdatedInstance()
    {
        // Arrange
        Property original = PropertyTestsData.Create();
        var type = new Symbol { Name = new Identifier("int") };

        // Act
        Property result = original.WithType(type);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Behaviours.ShouldBe(original.Behaviours);
        result.Default.ShouldBe(original.Default);
        result.Name.ShouldBe(original.Name);
        result.Scope.ShouldBe(original.Scope);
        result.Type.ShouldBe(type);

        original.Type.ShouldBe(PropertyTestsData.DefaultType);
    }
}
