namespace MooVC.Syntax.CSharp.Concepts.InterfaceTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenNamedIsCalled
{
    [Test]
    public async Task GivenNameThenReturnsUpdatedInstance()
    {
        // Arrange
        Interface original = InterfaceTestsData.Create(name: new Declaration { Name = "Original" });
        var name = new Declaration { Name = "Updated" };

        // Act
        Interface result = original.Named(name);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Declaration).IsEqualTo(name);
        _ = await Assert.That(original.Declaration).IsEqualTo(new Declaration { Name = "Original" });
    }
}