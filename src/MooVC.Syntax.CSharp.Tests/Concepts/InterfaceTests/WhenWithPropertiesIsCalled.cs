namespace MooVC.Syntax.CSharp.Concepts.InterfaceTests;

using MooVC.Syntax.CSharp.Members;
using MooVC.Syntax.Elements;

public sealed class WhenWithPropertiesIsCalled
{
    [Test]
    public async Task GivenPropertiesThenReturnsUpdatedInstance()
    {
        // Arrange
        var property = new Property { Name = new Name("Value"), Type = typeof(string) };
        Interface original = InterfaceTestsData.Create();

        // Act
        Interface result = original.WithProperties(property);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Properties).Contains(property);
        _ = await Assert.That(original.Properties).IsEmpty();
    }
}