namespace MooVC.Syntax.CSharp.ResultTests;

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
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Type).IsEqualTo(type);
        _ = await Assert.That(result.Modifier).IsEqualTo(original.Modifier);
        _ = await Assert.That(result.Mode).IsEqualTo(original.Mode);
        _ = await Assert.That(original.Type.Name).IsEqualTo(new Moniker(ResultTestsData.DefaultTypeName));
    }
}