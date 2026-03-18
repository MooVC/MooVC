namespace MooVC.Syntax.CSharp.Members.PropertyTests;

using MooVC.Syntax.CSharp.Elements;

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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Behaviours).IsEqualTo(original.Behaviours);
        await Assert.That(result.Default).IsEqualTo(original.Default);
        await Assert.That(result.Name).IsEqualTo(original.Name);
        await Assert.That(result.Scope).IsEqualTo(original.Scope);
        await Assert.That(result.Type).IsEqualTo(type);

        await Assert.That(original.Type).IsEqualTo(PropertyTestsData.DefaultType);
    }
}