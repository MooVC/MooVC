namespace MooVC.Syntax.CSharp.PropertyTests;

public sealed class WhenOfTypeIsCalled
{
    [Test]
    public async Task GivenTypeThenReturnsUpdatedInstance()
    {
        // Arrange
        Property original = PropertyTestsData.Create();
        var type = new Symbol { Name = "int" };

        // Act
        Property result = original.OfType(type);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Behaviours).IsEqualTo(original.Behaviours);
        _ = await Assert.That(result.Default).IsEqualTo(original.Default);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
        _ = await Assert.That(result.Scope).IsEqualTo(original.Scope);
        _ = await Assert.That(result.Type).IsEqualTo(type);

        _ = await Assert.That(original.Type).IsEqualTo(PropertyTestsData.DefaultType);
    }
}