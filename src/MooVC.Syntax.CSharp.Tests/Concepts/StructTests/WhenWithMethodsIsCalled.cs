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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Methods).Contains(method);
        await Assert.That(original.Methods).IsEmpty();
    }
}