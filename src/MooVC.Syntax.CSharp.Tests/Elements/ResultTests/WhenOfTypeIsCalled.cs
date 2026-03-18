namespace MooVC.Syntax.CSharp.Elements.ResultTests;

public sealed class WhenOfTypeIsCalled
{
    [Test]
    public async Task GivenTypeThenReturnsUpdatedInstance()
    {
        // Arrange
        Result original = ResultTestsData.Create();
        var type = new Symbol { Name = "Updated" };

        // Act
        Result result = original.OfType(type);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Type).IsEqualTo(type);
        await Assert.That(result.Modifier).IsEqualTo(original.Modifier);
        await Assert.That(result.Mode).IsEqualTo(original.Mode);
        await Assert.That(original.Type.Name).IsEqualTo(new Symbol.Moniker(ResultTestsData.DefaultTypeName));
    }
}