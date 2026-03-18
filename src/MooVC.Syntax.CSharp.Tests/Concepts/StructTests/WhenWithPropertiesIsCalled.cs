namespace MooVC.Syntax.CSharp.Concepts.StructTests;

using MooVC.Syntax.CSharp.Members;
using MooVC.Syntax.Elements;

public sealed class WhenWithPropertiesIsCalled
{
    [Test]
    public async Task GivenPropertiesThenReturnsUpdatedInstance()
    {
        // Arrange
        var property = new Property { Name = new Name("Value"), Type = typeof(string) };
        Struct original = StructTestsData.Create();

        // Act
        Struct result = original.WithProperties(property);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Properties).Contains(property);
        await Assert.That(original.Properties).IsEmpty();
    }
}