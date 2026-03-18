namespace MooVC.Syntax.CSharp.Concepts.StructTests;

public sealed class WhenNamedIsCalled
{
    [Test]
    public async Task GivenNameThenReturnsUpdatedInstance()
    {
        // Arrange
        Struct original = StructTestsData.Create(name: new Declaration { Name = "Original" });
        var name = new Declaration { Name = "Updated" };

        // Act
        Struct result = original.Named(name);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Declaration).IsEqualTo(name);
        _ = await Assert.That(original.Declaration).IsEqualTo(new Declaration { Name = "Original" });
    }
}