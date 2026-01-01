namespace MooVC.Syntax.CSharp.Concepts.InterfaceTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithPropertiesIsCalled
{
    [Fact]
    public void GivenPropertiesThenReturnsUpdatedInstance()
    {
        // Arrange
        var property = new Property { Name = new Variable("Value"), Type = typeof(string) };
        Interface original = InterfaceTestsData.Create();

        // Act
        Interface result = original.WithProperties(property);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Properties.ShouldContain(property);
        original.Properties.ShouldBeEmpty();
    }
}