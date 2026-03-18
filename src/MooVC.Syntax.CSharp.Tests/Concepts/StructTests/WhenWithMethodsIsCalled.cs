namespace MooVC.Syntax.CSharp.Concepts.StructTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithMethodsIsCalled
{
    [Test]
    public async Task GivenMethodsThenReturnsUpdatedInstance()
    {
        // Arrange
        var method = new Method { Name = new Declaration { Name = "Execute" } };
        Struct original = StructTestsData.Create();

        // Act
        Struct result = original.WithMethods(method);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Methods).Contains(method);
        _ = await Assert.That(original.Methods).IsEmpty();
    }
}