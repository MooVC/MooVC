namespace MooVC.Syntax.CSharp.Members.PropertyTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

public sealed class WhenNamedIsCalled
{
    [Fact]
    public void GivenNameThenReturnsUpdatedInstance()
    {
        // Arrange
        Property original = PropertyTestsData.Create();
        var name = new Identifier("Alternative");

        // Act
        Property result = original.Named(name);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Behaviours.ShouldBe(original.Behaviours);
        result.Default.ShouldBe(original.Default);
        result.Name.ShouldBe(name);
        result.Scope.ShouldBe(original.Scope);
        result.Type.ShouldBe(original.Type);

        original.Name.ShouldBe((Identifier)PropertyTestsData.DefaultName);
    }
}