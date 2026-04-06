namespace MooVC.Syntax.CSharp.StructTests;

public sealed class WhenWithPropertiesIsCalled
{
    [Test]
    public async Task GivenPropertiesThenReturnsUpdatedInstance()
    {
        // Arrange
        var property = new Property { Name = new("Value"), Type = typeof(string) };
        Struct original = StructTestsData.Create();

        // Act
        Struct result = original.WithProperties(property);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Properties).Contains(property);
        _ = await Assert.That(original.Properties).IsEmpty();
    }
}