namespace MooVC.Syntax.CSharp.Concepts.StructTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithPropertiesIsCalled
{
    [Fact]
    public void GivenPropertiesThenReturnsUpdatedInstance()
    {
        // Arrange
        var property = new Property { Name = new Identifier("Value"), Type = typeof(string) };
        Struct original = StructTestsData.Create();

        // Act
        Struct result = original.WithProperties(property);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Properties.ShouldContain(property);
        original.Properties.ShouldBeEmpty();
    }
}
